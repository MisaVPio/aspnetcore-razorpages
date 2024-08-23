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
            //var cliente = new ClienteModel();
            //Cliente.Endereco = new EnderecoModel();
            Cliente.Situacao = ClienteModel.SituacaoCliente.Cadastrado;

                _context.Clientes.Add(Cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
                   
            //if (await TryUpdateModelAsync(cliente, typeof(ClienteModel), "Cliente"))
            //{
            //    Cliente.Situacao = ClienteModel.SituacaoCliente.Cadastrado;
            //    _context.Clientes.Add(Cliente);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Listar");
            //}

        }


    }
}
