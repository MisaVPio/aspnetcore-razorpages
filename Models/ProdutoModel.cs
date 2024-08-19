using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApp.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }
        [Required(ErrorMessage ="O campo {0} é de preenchimento obrigatório")]
        [MaxLength(100)]
        public String Nome { get; set; } = "Unknown";
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [MaxLength (1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = "Unknown";
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [Column(TypeName ="decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        public int? Estoque { get; set; }
    }
}
