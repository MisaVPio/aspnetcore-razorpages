using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace AspNetCoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ApplicationDbContext _context;
        public IList<ProdutoModel> Produtos;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        //public async Task OnGetAsync([FromQuery]string termoBusca)
        //{
        //    if (string.IsNullOrEmpty(termoBusca))
        //    {
        //        Produtos = await _context.Produtos.ToListAsync();
        //    }
        //    else
        //    {
        //        Produtos = await _context.Produtos.Where(
        //            p => p.Nome.ToUpper().Contains(termoBusca.ToUpper())).ToListAsync();
        //    }

        //}

        public async void OnGetAsync([FromQuery(Name ="q")] string termoBusca, [FromQuery(Name ="o")]int? ordem)
        {
            var query = _context.Produtos.AsQueryable();
            if (!string.IsNullOrEmpty(termoBusca))
            {
                query = query.Where(
                    p => p.Nome.ToUpper().Contains(
                        termoBusca.ToUpper()));
                   
            }
            Produtos = await query.ToListAsync();
            if (ordem.HasValue)
            {
                switch(ordem.Value)
                {
                    case 1:
                        Produtos = Produtos.OrderBy(p => p.Nome).ToList();
                        //query = query.OrderBy(p => p.Nome);
                        break;
                    case 2:
                        Produtos = Produtos.OrderBy(p => p.Preco).ToList();
                        //query = query.OrderBy(p => p.Preco);
                        break;
                    case 3:
                        Produtos = Produtos.OrderBy(p => p.Preco).ToList();
                        //query = query.OrderByDescending(p => p.Preco);
                        break;

                }
            }

            
        }
    }
}
