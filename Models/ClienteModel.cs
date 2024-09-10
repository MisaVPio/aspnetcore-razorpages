using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AspNetCoreWebApp.Models
{
    public class ClienteModel
    {
        public enum SituacaoCliente
        {
            Bloqueado,
            Cadastrado,
            Aprovado,
            Especial
        }

        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo \"{0}\" deve conter uma data válida.")]
        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório")]
        [MaxLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [MinLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [RegularExpression(@"[0-9]{11}$", ErrorMessage = "O campo \"{0}\" deve ser preenchido com 11 números.")]
        [UIHint("_CpfTemplate")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório")]
        [MaxLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [MinLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [RegularExpression(@"[0-9]{11}$", ErrorMessage = "O campo \"{0}\" deve ser preenchido com 11 números.")]
        [UIHint("_TelefoneTemplate")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "O campo \"{0}\" deve conter um endereço de e-mail válido")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name = "Situação")]
        public SituacaoCliente Situacao { get; set; }

        public EnderecoModel Endereco { get; set; }

        //ICollection<PedidoModel>? Pedidos { get; set; }
    }
}
