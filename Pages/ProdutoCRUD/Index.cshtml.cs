using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp.Pages.ProdutoCRUD
{
    public class IndexModel : PageModel
    {
        private readonly AspNetCoreWebApp.Data.ApplicationDbContext _context;

        public IndexModel(AspNetCoreWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProdutoModel> ProdutoModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProdutoModel = await _context.ProdutoModel.ToListAsync();
        }
    }
}
