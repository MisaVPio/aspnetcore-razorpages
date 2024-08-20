using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AspNetCoreWebApp.Models
{
    public class PedidoModel
    {
        public enum SituacaoPedido 
        {
            Cancelado,
            Realizado,
            Verificado,
            Atendido,
            Entregue
        }

        [Key]
        [Display(Name = "Código")]
        public int IdPedido {  get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name ="Data/Hora")]
        public DateTime? DataHoraPedido { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name = "Valor Total")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal? ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [Display(Name = "Situação")]
        public SituacaoPedido Situacao { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }

        public EnderecoModel Endereco { get; set; }
    
        public ICollection<ItemPedidoModel> ItensPedido { get; set; }    
    }
}
