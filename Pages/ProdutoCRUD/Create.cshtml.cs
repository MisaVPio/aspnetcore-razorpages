using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using System.ComponentModel.DataAnnotations;
using NuGet.Configuration;

namespace AspNetCoreWebApp.Pages.ProdutoCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;



        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public IFormFile? ImagemProduto { get; set; }

        public string CaminhoImagem { get; set; }

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            CaminhoImagem = "~/img/produto/sem_imagem.jpg";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProdutoModel ProdutoModel { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (/*ImagemProduto == null || */!ModelState.IsValid)
            {
                return Page();
            }
            
            
            if (await TryUpdateModelAsync(ProdutoModel,ProdutoModel.GetType(), nameof(ProdutoModel)))
            {
                _context.Produtos.Add(ProdutoModel);
                await _context.SaveChangesAsync();
                await AppUtils.ProcessarArquivoDeImagem(ProdutoModel.IdProduto, ImagemProduto,
                    _webHostEnvironment);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
