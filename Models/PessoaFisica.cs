using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CadastroCliente.Interfaces;

namespace CadastroCliente.Models
{
    public class PessoaFisica : IPessoa
    {
        public int Id { get; set; }

        [NotMapped]
        public string Documento
        {
            get => CPF;
            set => CPF = value;
        }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF deve ter 11 dígitos.", MinimumLength = 11)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00.")]
        public string CPF { get;set; }


        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
