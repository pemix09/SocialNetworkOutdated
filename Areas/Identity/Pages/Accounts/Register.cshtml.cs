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
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public User user { get; set; }
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Adres Email jest wymagany")]
            [EmailAddress]
            [Display(Name = "Adres Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Has�o jest wymagane")]
            [StringLength(100, ErrorMessage = "Has�o musi sk�ada� si� z od 6 do 100 znak�w", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Has�o")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Powt�rz has�o")]
            [Compare("Password", ErrorMessage = "Has�a s� r�ne")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                
                var userD = new IdentityUser { UserName = user.nickname, Email = user.email };
                var result = await _userManager.CreateAsync(userD, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("U�ytkownik poprawnie stworzy� swoje konto");

                    await _signInManager.SignInAsync(userD, isPersistent: false);
                    return Redirect("~/");
                }
                foreach (var error in result.Errors)
                {
                    //ModelState.AddModelError("EmailTaken", "Podany adres Email jest ju� u�ywany");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
