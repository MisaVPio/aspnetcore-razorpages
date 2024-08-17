using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApp.Pages.ClienteCRUD
{
    public class ListarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IList<ClienteModel> Clientes { get; set; } = default!;

        public ListarModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync();
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
