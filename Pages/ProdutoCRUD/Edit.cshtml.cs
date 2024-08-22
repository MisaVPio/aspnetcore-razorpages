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
        public ProdutoModel Produto { get; set; }

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

            Produto =  await _context.Produtos.FirstOrDefaultAsync(m => m.IdProduto == id);
            if (Produto == null)
            {
                return NotFound();
            }
            CaminhoImagem = $"~/img/produto/{Produto.IdProduto:D5}"+".jpg";
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                if (ImagemProduto != null)
                {
                    await AppUtils.ProcessarArquivoDeImagem(Produto.IdProduto, 
                        ImagemProduto, _webHostEnvironment);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoModelExists(Produto.IdProduto))
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
