using AspNetCoreWebApp.Pages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApp.Models
{
    public class ItemPedidoModel
    {
        [Required]
        public int IdPedido  { get; set; }

        [Required]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public float Quantidade { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name = "Valor Unitário")]

        public double ValorUnitario { get; set; }

        [NotMapped]
        public double ValorItem
        {
            get
            {
                return Quantidade * ValorUnitario;
            }
        }

        [ForeignKey("IdPedido")]
        public PedidoModel Pedido { get; set; }

        [ForeignKey("IdProduto")]
        public ProdutoModel Produto { get; set; }   
    }
}
