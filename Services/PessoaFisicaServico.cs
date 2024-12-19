using CadastroCliente.Data;
using CadastroCliente.Interfaces;
using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Services
{
    public class PessoaFisicaService : PessoaService
    {
        public PessoaFisicaService(ApplicationDbContext context) : base(context) {}

        public new Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id, TipoPessoa.Fisica);
        }

        public new Task<IPessoa> GetByWithParamAsync(int id)
        {
            return base.GetByWithParamAsync(id, TipoPessoa.Fisica);
        }

        public new Task<IPessoa> GetByWithParamAsync(string nome)
        {
            return base.GetByWithParamAsync(nome, TipoPessoa.Fisica);
        }
    }
}
