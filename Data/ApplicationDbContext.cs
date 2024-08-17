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

        public DbSet<AspNetCoreWebApp.Models.ProdutoModel> ProdutoModel { get; set; } = default!;
        public DbSet<AspNetCoreWebApp.Models.ClienteModel> Clientes { get; set; } = default!;
    }
}
