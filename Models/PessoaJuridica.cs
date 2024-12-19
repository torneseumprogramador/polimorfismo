using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CadastroCliente.Interfaces;

namespace CadastroCliente.Models
{
    public class PessoaJuridica : IPessoa
    {
        public int Id { get; set; }


        [NotMapped]
        public string Documento
        {
            get => CNPJ;
            set => CNPJ = value;
        }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18, ErrorMessage = "O CNPJ deve conter exatamente 18 caracteres numéricos.", MinimumLength = 18)]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O CNPJ deve estar no formato 00.000.000/0000-00.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
