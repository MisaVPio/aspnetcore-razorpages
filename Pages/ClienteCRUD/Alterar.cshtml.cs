using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace AspNetCoreWebApp.Pages.ClienteCRUD
{
    [Authorize(Roles = "admin")]
    public class AlterarModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public ClienteModel Cliente { get; set; }

        public AlterarModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.IdCliente == id);
            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid) return Page();
            _context.Attach(Cliente).State = EntityState.Modified;
            
            try
            {
               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ClienteAindaExiste(Cliente.IdCliente))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           
            return RedirectToPage("./Listar");
        }
        
        private bool ClienteAindaExiste(int id)
        {
            return _context.Clientes.Any(m => m.IdCliente == id);
        }
    }
}
