using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CadastroCliente.Interfaces;

namespace CadastroCliente.Models
{
    public class PessoaFisica : IPessoa
    {
        public int Id { get; set; }

        [MaxLength(14)]
        public string Documento { get; set; }

       [NotMapped]
        public string CPF
        {
            get => Documento;
            set => Documento = value;
        }

        [Required]
        public string Nome { get; set; }
    }
}
