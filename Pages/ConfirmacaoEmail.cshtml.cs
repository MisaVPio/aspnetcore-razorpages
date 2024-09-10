using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;


namespace AspNetCoreWebApp.Pages
{
    public class ConfirmacaoEmailModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmacaoEmailModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public string StatusMessage { get; set; }
        public bool EmailConfirmado { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string token)
        {
            if (userId == null || token == null)
            {

                return RedirectToPage("/Index");
            }

            var usuario = await _userManager.FindByIdAsync(userId);
            if (usuario == null)
            {
                return NotFound($"Não foi possível encontrar o usuário com ID '{userId}'.");
            }
            
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(usuario, token);
            EmailConfirmado = result.Succeeded;
            StatusMessage = EmailConfirmado ? "E-mail confirmado com sucesso!" : "Ocorreu um erro" +
                "ao confirmar ser email.";
            return Page();
        }
    }
}
