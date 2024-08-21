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
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApp.Pages.ProdutoCRUD
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public ProdutoModel ProdutoModel { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        public IFormFile ImagemProduto { get; set; }
         
        public string CaminhoImagem { get; set; }

        public EditModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

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
            CaminhoImagem = $"~/img/produto/{ProdutoModel.IdProduto:D5}";
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
                if (ImagemProduto != null)
                {
                    await AppUtils.ProcessarArquivoDeImagem(ProdutoModel.IdProduto, 
                        ImagemProduto, _webHostEnvironment);
                }
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
