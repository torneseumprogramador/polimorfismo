
using CadastroCliente.Data;
using CadastroCliente.Interfaces;
using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

public enum TipoPessoa 
{
    Fisica,
    juridica
}

namespace CadastroCliente.Services
{
    public class PessoaService
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<IPessoa>> GetAllAsync()
        {
            var pessoasFisicas = await _context.PessoasFisicas.ToListAsync<IPessoa>();
            var pessoasJuridicas = await _context.PessoasJuridicas.ToListAsync<IPessoa>();

            return pessoasFisicas.Concat(pessoasJuridicas).ToList();
        }

        public async Task<IPessoa> GetByWithParamAsync(int id, TipoPessoa pessoa)
        {
            if(TipoPessoa.Fisica == pessoa){
                var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
                return pessoaFisica;
            }
            else {
                var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
                return pessoaJuridica;
            }
        }

        public async Task<IPessoa> GetByWithParamAsync(string nome, TipoPessoa pessoa)
        {
            if(TipoPessoa.Fisica == pessoa){
                var pessoaFisica = await _context.PessoasFisicas.Where(c => c.Nome.Contains(nome)).FirstAsync();
                return pessoaFisica;
            }
            else{
                var pessoaJuridica = await _context.PessoasJuridicas.Where(c => c.Nome.Contains(nome)).FirstAsync();
                return pessoaJuridica;
            }
        }

        public async Task AddAsync(IPessoa pessoa)
        {
            if (pessoa is PessoaFisica pessoaFisica)
            {
                await _context.PessoasFisicas.AddAsync(pessoaFisica);
            }
            else if (pessoa is PessoaJuridica pessoaJuridica)
            {
                await _context.PessoasJuridicas.AddAsync(pessoaJuridica);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IPessoa pessoa)
        {
            if (pessoa is PessoaFisica pessoaFisica)
            {
                _context.PessoasFisicas.Update(pessoaFisica);
            }
            else if (pessoa is PessoaJuridica pessoaJuridica)
            {
                _context.PessoasJuridicas.Update(pessoaJuridica);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, TipoPessoa pessoa)
        {   
            if(TipoPessoa.Fisica == pessoa){
                var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
                if (pessoaFisica != null)
                {
                    _context.PessoasFisicas.Remove(pessoaFisica);
                    await _context.SaveChangesAsync();
                    return;
                }
            }
            else{
                var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
                if (pessoaJuridica != null)
                {
                    _context.PessoasJuridicas.Remove(pessoaJuridica);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
