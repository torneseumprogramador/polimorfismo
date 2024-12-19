using System.ComponentModel.DataAnnotations;
using CadastroCliente.Interfaces;

namespace CadastroCliente.Models
{
    public class PessoaJuridica : IPessoa
    {
        public int Id { get; set; }

        [MaxLength(14)]
        public string Documento { get; set; }

        public string Cnpj {
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
