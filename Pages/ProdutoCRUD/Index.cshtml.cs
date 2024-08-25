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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IList<ProdutoModel> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
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
                if (await _context.SaveChangesAsync() > 0)
                {
                    var caminhoArquivoImagem = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "img\\produto",
                    verProduto.IdProduto.ToString("D6") + ".jpg");
                    if(System.IO.File.Exists(caminhoArquivoImagem))
                    {
                        System.IO.File.Delete(caminhoArquivoImagem);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
