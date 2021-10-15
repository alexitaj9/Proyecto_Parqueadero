using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Parqueadero.App.Dominio;
using Parqueadero.App.Persistencia;

namespace Parqueadero.App.Frontend.Pages
{
    public class CrearPropietarioModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CrearPropietarioModel> _logger;

        private readonly IEmailSender _emailSender;
        //Instancia
        private IRepositorioPropietario repositorioPropietario;

        //Propieades
        public Propietario propietario { get; set; }

        //Constructor
        public CrearPropietarioModel(IRepositorioPropietario repositorioPropietario,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<CrearPropietarioModel> logger,
            IEmailSender emailSender)
        {
            this.repositorioPropietario = repositorioPropietario;
            Propietario propietario = new Propietario();
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> OnPost(Propietario propietario)
        {
            string returnUrl = "/GestorPropietarios/ListaPropietarios";
            if (ModelState.IsValid)
            {
                try
                {
                    string Password = propietario.clave;
                    //Login
                    repositorioPropietario.addPropietario(propietario);

                    var user = new IdentityUser { UserName = propietario.nombre, Email = propietario.correo, EmailConfirmed = true };
                    _logger.LogInformation(Password);
                    var result = await _userManager.CreateAsync(user, Password);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(propietario.correo, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = propietario.correo , returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    //Redireccion
                    return Page();      
                }
                catch
                {
                    //Redireccion
                    return RedirectToPage("../Error");
                }
            }
            else
            {
                return Page();
            }
        }
        
    }
}
