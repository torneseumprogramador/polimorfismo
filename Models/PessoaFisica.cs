using System.ComponentModel.DataAnnotations;
using CadastroCliente.Interfaces;

namespace CadastroCliente.Models
{
    public class PessoaFisica : IPessoa
    {
        public int Id { get; set; }

        [MaxLength(14)]
        public string Documento { get; set; }

        public string CPF {
            get {
                return this.Documento;
            }
            set {
                this.Documento = value;
            }
        }

        [Required]
        public string Nome { get; set; }
    }
}
