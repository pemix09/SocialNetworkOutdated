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
using SocialNetwork.Services;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public IdConverter IDconverter = new();

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            SocialNetwork.Data.SocialNetworkContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        
        public AppUser user { get; set; }
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public async Task OnGetAsync()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(Input.Email);
                if(userCheck!=null)
                {
                    ModelState.AddModelError("Existing Account", "Podany email jest ju¿ przypisany do konta");
                    return Page();
                }
                if (userCheck == null)
                {

                    //create new user
                    var userD = new AppUser
                    {
                        UserName = Input.nickname,
                        Email = Input.Email,
                        FirstName = Input.firstName,
                        LastName = Input.lastName,
                        PhoneNumber = Input.phone,
                    };
                    var result = await _userManager.CreateAsync(userD, Input.Password);
                    if (result.Succeeded)
                    {
                        //powloi trzeba bêdzie od tego odchodziæ, bo chcemy mieæ tylko jedn¹
                        //tabelê na dane u¿ytkownika
                        user.Id = userD.Id;
                        user.FirstName = Input.firstName;
                        user.LastName = Input.lastName;
                        user.UserName = Input.nickname;
                        user.PhoneNumber = Input.phone;
                        user.Email = Input.Email;

                        //logowanie informacji o dodaniu u¿ytkownika
                        _logger.LogInformation("U¿ytkownik poprawnie stworzy³ swoje konto");

                        //zalogowanie u¿ytkownika
                        await _signInManager.SignInAsync(userD, isPersistent: false);

                        //dodanie u¿ytkownika do tabeli
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();


                        return Redirect("~/");
                    }
                    foreach (var error in result.Errors)
                    {
                        //ModelState.AddModelError("EmailTaken", "Podany adres Email jest ju¿ u¿ywany");
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
