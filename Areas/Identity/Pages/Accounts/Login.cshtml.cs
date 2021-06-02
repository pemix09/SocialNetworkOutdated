using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<AppUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="Adres email jest wymagany")]
            [EmailAddress]
            [Display(Name = "Adres Email")]
            public string Email { get; set; }

            [Required(ErrorMessage ="Has這 jest wymagane!")]
            [DataType(DataType.Password)]
            [Display(Name ="Has這")]
            public string Password { get; set; }

            [Display(Name = "Zapami皻aj mnie")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");


            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);

                if(user == null)
                {
                    ModelState.AddModelError("WrongEmailAdress", "Z造 adres email");
                    return Page();
                }
                if (await _userManager.CheckPasswordAsync(user, Input.Password) == false)
                {
                    ModelState.AddModelError("WrongPassword", "Podane has這 jest nieprawid這we");
                    return Page();
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("U篡tkownik zalogowa� si� pomy�lnie");
                    return LocalRedirect(returnUrl);
                }
                else if(result.IsLockedOut)
                {
                    ModelState.AddModelError("AccountBlocked", "Podany u篡tkownik zosta� zablokowany");
                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nieudana pr鏏a logowania");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    
}
}
