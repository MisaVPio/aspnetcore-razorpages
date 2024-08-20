using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApp.Models
{
    public class FavoritoModel
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public DateTime? DataHora { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }
        [ForeignKey("IdProduto")]
        public ProdutoModel Produto { get; set; }
    }
}
