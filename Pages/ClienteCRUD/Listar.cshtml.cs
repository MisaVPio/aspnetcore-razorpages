using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApp.Pages.ClienteCRUD
{
    [Authorize(Roles = "admin")]
    public class ListarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IList<ClienteModel> Clientes { get; set; } = default!;

        public ListarModel(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<string> EmailsAdmins { get; set; }

        public async Task OnGetAsync()
        {
            EmailsAdmins = (await _userManager.GetUsersInRoleAsync("admin")).
                Select(x => x.Email).ToList();
            Clientes = await _context.Clientes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                if (await _context.SaveChangesAsync() > 0)
                {
                    AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
                    if (usuario != null) await _userManager.DeleteAsync(usuario);
                }

            }
            return RedirectToPage("./Listar");

        }

        public async Task<IActionResult> OnPostDelAdminAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
                if (usuario != null)
                {
                    await _userManager.RemoveFromRoleAsync(usuario, "admin");

                }
            }

            return RedirectToPage("./Listar");
        }

        public async Task<IActionResult> OnPostSetAdminAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
                if (usuario != null)
                {
                    if (!await _roleManager.RoleExistsAsync("admin")) 
                        {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                    }
                    await _userManager.AddToRoleAsync(usuario, "admin");
                }

            }

            return RedirectToPage("./Listar");
        }
    }
}
