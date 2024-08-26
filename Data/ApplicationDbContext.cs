using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetCoreWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
