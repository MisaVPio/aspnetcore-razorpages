using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp.Pages.ProdutoCRUD
{
    public class EditModel : PageModel
    {
        private readonly AspNetCoreWebApp.Data.ApplicationDbContext _context;

        public EditModel(AspNetCoreWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdutoModel ProdutoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtomodel =  await _context.Produtos.FirstOrDefaultAsync(m => m.IdProduto == id);
            if (produtomodel == null)
            {
                return NotFound();
            }
            ProdutoModel = produtomodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProdutoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoModelExists(ProdutoModel.IdProduto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdutoModelExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProduto == id);
        }
    }
}
