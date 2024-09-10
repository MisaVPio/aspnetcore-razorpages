using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using AspNetCoreWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace AspNetCoreWebApp.Pages
{
    public class RecuperarSenhaModel : PageModel
    {
        private UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;

        public class DadosEmail
        {
            [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
            [EmailAddress]
            [Display(Name = "E-mail")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
        }

        [BindProperty] public DadosEmail Dados { get; set; }

        public RecuperarSenhaModel(ApplicationDbContext context, UserManager<AppUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;

        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                AppUser usuario = await _userManager.FindByNameAsync(Dados.Email);
                if (usuario != null)
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    var urlResetarSenha = Url.Page("/RedefinirSenha", null, new { token }, Request.Scheme);

                    StringBuilder msg = new StringBuilder();
                    msg.Append("<h1>QuitandaOnline :: Recuperação de Senha</h1>");
                    msg.Append($"<p>Por favor, redefina sua senha<a href='{HtmlEncoder.Default.Encode(urlResetarSenha)}'> Clicando aqui.</a></p>");
                    msg.Append("<p>Atenciosamente <br> Equipe de Suporte Quitanda Online</p>");
                    await _emailSender.SendEmailAsync(usuario.Email, "Recuperação de Senha", "", msg.ToString());
                    return RedirectToPage("/EmailRecuperacaoEnviado");
                }
                else
                {
                    return RedirectToPage("/EmailRecuperacaoEnviado");
                }
                
            }
            return Page();
        }
    }
}
