using AspNetCoreWebApp.Data;
using AspNetCoreWebApp.Models;
using AspNetCoreWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace AspNetCoreWebApp.Pages
{
    public class NovoClienteModel : PageModel
    {
        public class Senhas
        {
            [Required(ErrorMessage = "O campo \"{0}\" � de preenchimento obrigat�rio.")]
            [StringLength(16, ErrorMessage = "O campo \"{0}\" deve ter pelo menos {2} e no m�ximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Senha { get; set; }

            [Required(ErrorMessage = "O campo \"{0}\" � de preenchimento obrigat�rio.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirma��o de Senha")]
            [Compare("Senha", ErrorMessage = "As senhas n�o s�o iguais.")]
            public string ConfirmacaoSenha { get; set; }
        }

        private readonly ApplicationDbContext _Context;
        private readonly UserManager<AppUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly IEmailSender _emailSender;

        public NovoClienteModel(ApplicationDbContext context,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _Context = context;
            _UserManager = userManager;
            _RoleManager = roleManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public ClienteModel Cliente { get; set; }
        [BindProperty]
        public Senhas SenhasUsuario { get; set; }

        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var cliente = Cliente;
            cliente.Situacao = ClienteModel.SituacaoCliente.Cadastrado;

            Senhas senhasUsuario = SenhasUsuario;

                if (!await TryUpdateModelAsync(senhasUsuario, senhasUsuario.GetType(), nameof(senhasUsuario)))
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return Page();
                }
            
            if (await TryUpdateModelAsync(cliente, cliente.GetType(), nameof(cliente)))
            {
                if (!await _RoleManager.RoleExistsAsync("cliente"))
                {
                    await _RoleManager.CreateAsync(new IdentityRole("cliente"));
                }

                var usuarioExistente = await _UserManager.FindByEmailAsync(cliente.Email);
                if (usuarioExistente != null)
                {
                    ModelState.AddModelError("Cliente.Email", "J� existe um cliente cadastrado com esse email.");
                    return Page();
                }

                var usuario = new AppUser()
                {
                    UserName = cliente.Email,
                    Email = cliente.Email,
                    PhoneNumber = cliente.Telefone,
                    Nome = cliente.Nome
                };

                var result = await _UserManager.CreateAsync(usuario, senhasUsuario.Senha);
                if (result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(usuario, "cliente");
                    _Context.Clientes.Add(cliente);
                    int afetados = await _Context.SaveChangesAsync();
                    if (afetados > 0)
                    {
                        var token = await _UserManager.GenerateEmailConfirmationTokenAsync(usuario);
                        token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                        var urlConfirmacaoEmail = Url.Page("/ConfirmacaoEmail", null,
                            new { userId = usuario.Id, token }, Request.Scheme);
                        StringBuilder msg = new StringBuilder();
                        msg.Append("<h1>Quitanda Online :: Confirma��o de E-mail</h1>");

                        msg.Append($"<p>Por favor, confirme seu e-mail " +
                            $"<a href='{HtmlEncoder.Default.Encode(urlConfirmacaoEmail)}'>clicando aqui</a>");
                        msg.Append("<p>Atenciosamente,<br>Equipe de Suporte Quitanda Online</p>");
                        await _emailSender.SendEmailAsync(usuario.Email, "Confirma��o de E-mail", "", msg.ToString());
                        return RedirectToPage("/CadastroRealizado");
                    }
                    else
                    {
                        await _UserManager.DeleteAsync(usuario);
                        ModelState.AddModelError("Cliente", "N�o foi poss�vel efetuar o cadastro. Verifique"
                            + "os dados e tente novamente. Se o problema persistir, entre em contato conosco.");
                        return Page();
                    }
                }                                  
                else
                {
                    ModelState.AddModelError("Cliente.Email", "N�o foi poss�vel criar um usuario com este email"
                        + "Use outro endere�o de email ou tente recuperar a senha");
                }
            }
            return Page();
        }
    }
}
