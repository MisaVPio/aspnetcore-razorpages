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
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProdutoModel> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produtos.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }
            var verProduto = await _context.Produtos.FindAsync(id);
            if (verProduto != null)
            {
                _context.Produtos.Remove(verProduto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
