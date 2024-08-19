using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApp.Pages.ClienteCRUD
{
    public class IncluirModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public ClienteModel Clientes { get; set; }
      
        public IncluirModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cliente = new ClienteModel();
            if (await TryUpdateModelAsync<ClienteModel>(cliente, "Clientes",
                obj => obj.Nome, obj => obj.DataNascimento, o => o.Email))
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            return Page();
        }


    }
}
