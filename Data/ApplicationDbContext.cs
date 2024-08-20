using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedidoModel>().HasKey(e => new {e.IdPedido, e.IdProduto});
            modelBuilder.Entity<FavoritoModel>().HasKey(e => new { e.IdCliente, e.IdProduto });
            modelBuilder.Entity<VisitadoModel>().HasKey(e => new { e.IdCliente, e.IdProduto });
        }
        public DbSet<AspNetCoreWebApp.Models.ProdutoModel> Produtos { get; set; }
        public DbSet<AspNetCoreWebApp.Models.ClienteModel> Clientes { get; set; }
        public DbSet<AspNetCoreWebApp.Models.PedidoModel> Pedidos { get; set; }
        public DbSet<AspNetCoreWebApp.Models.ItemPedidoModel> ItensPedido { get; set; }
        public DbSet<AspNetCoreWebApp.Models.FavoritoModel> Favoritos { get; set; }
        public DbSet<AspNetCoreWebApp.Models.VisitadoModel> Visitados { get; set; }
    }
}
