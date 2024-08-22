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
        public ClienteModel Cliente { get; set; }
      
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
            if(!ModelState.IsValid)
            {
                ViewData["Message"] = "Modelo inválido!!!!";
                return Page();
            }
            var cliente = new ClienteModel();
            cliente.Endereco = new EnderecoModel();
            cliente.Situacao = ClienteModel.SituacaoCliente.Cadastrado;

            if (await TryUpdateModelAsync(cliente, Cliente.GetType(),nameof(ClienteModel)))
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            return Page();
        }


    }
}
