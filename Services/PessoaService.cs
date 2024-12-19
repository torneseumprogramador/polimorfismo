
using CadastroCliente.Data;
using CadastroCliente.Interfaces;
using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IPessoa> GetByIdAsync(int id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaFisica != null) return pessoaFisica;

            var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
            return pessoaJuridica;
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

        public async Task DeleteAsync(int id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaFisica != null)
            {
                _context.PessoasFisicas.Remove(pessoaFisica);
                await _context.SaveChangesAsync();
                return;
            }

            var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica != null)
            {
                _context.PessoasJuridicas.Remove(pessoaJuridica);
                await _context.SaveChangesAsync();
            }
        }
    }
}
