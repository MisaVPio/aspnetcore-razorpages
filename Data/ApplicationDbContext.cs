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
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ItemPedidoModel> ItensPedido { get; set; }
        
    }
}
