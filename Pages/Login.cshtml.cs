using AspNetCoreWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApp.Pages
{
    public class LoginModel : PageModel
    {
        public class DadosLogin
        {
            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [EmailAddress]
            [DataType(DataType.Password)]
            [Display(Name = "E-mail")]
            public string Email { get; set; }
            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Senha { get; set; }
            [Display(Name = "Lembrar de mim")]

            public bool Lembrar { get; set; }
        }

        private readonly SignInManager<AppUser> _signInManager;

        public LoginModel(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public DadosLogin Dados { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string MensagemDeErro { get; set; }
        
        public async Task OnGetAsync(string returnUrl = null)
        {
            if(!string.IsNullOrEmpty(MensagemDeErro))
                {
                ModelState.AddModelError(string.Empty, MensagemDeErro);
            }
            returnUrl = returnUrl ?? Url.Content("~/");
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Dados.Email, Dados.Senha, Dados.Lembrar, lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentativa de Login inválida." +
                        "Verifique seus dados e tente novamente.");
                    return Page();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }



    }
}
