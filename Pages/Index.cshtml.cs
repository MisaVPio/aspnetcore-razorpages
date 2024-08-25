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
        private const int tamanhoPagina = 12;

        public int PaginaAtual {  get; set; }
        public int QuantidadePaginas { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


    
        public async void OnGetAsync([FromQuery(Name = "q")] string termoBusca,
            [FromQuery(Name = "o")] int? ordem = 1, [FromQuery(Name ="p")] int? pagina = 1)
        {
            this.PaginaAtual = pagina.Value;
            var query = _context.Produtos.AsQueryable();
            if (!string.IsNullOrEmpty(termoBusca))
            {
                query = query.Where(
                    p => p.Nome.ToUpper().Contains(
                        termoBusca.ToUpper()));

            }
           
            if (ordem.HasValue)
            {
                switch (ordem.Value)
                {
                    case 1:

                        query = query.OrderBy(p => p.Nome.ToUpper());
                        break;
                    case 2:
                        query = query.OrderBy(p => p.Preco);
                        break;
                    case 3:
                        query = query.OrderByDescending(p => p.Preco);
                        break;

                }
            }

            var queryCount = query;
            int qtdeProdutos = queryCount.Count();
            this.QuantidadePaginas = Convert.ToInt32(Math.Ceiling(qtdeProdutos*1M/tamanhoPagina));

            query = query.Skip(tamanhoPagina * (this.PaginaAtual - 1)).Take(tamanhoPagina);

            Produtos = await query.ToListAsync();

        }
    }
}
