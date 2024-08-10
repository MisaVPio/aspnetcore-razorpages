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
    public class DetailsModel : PageModel
    {
        private readonly AspNetCoreWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(AspNetCoreWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ProdutoModel ProdutoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtomodel = await _context.ProdutoModel.FirstOrDefaultAsync(m => m.IdProduto == id);
            if (produtomodel == null)
            {
                return NotFound();
            }
            else
            {
                ProdutoModel = produtomodel;
            }
            return Page();
        }
    }
}
