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
        public ProdutoModel ProdutoModel { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public IFormFile ImagemProduto { get; set; }

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

        public async Task<IActionResult> OnPostCriarAsync()
        {
            if (ImagemProduto == null)
            {                
                return Page();
            }
            var produto = new ProdutoModel();
            if (await TryUpdateModelAsync(produto,ProdutoModel.GetType(), nameof(produto)))
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                //await AppUtils.ProcessarArquivoDeImagem(produto.IdProduto, ImagemProduto,
                //    _webHostEnvironment);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
