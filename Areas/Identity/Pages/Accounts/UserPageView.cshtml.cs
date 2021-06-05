using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Data.DAL;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    //[Authorize(Roles = "User")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public class UserPageViewModel : PageModel
    {
        public class InputModel
        {
            [Display(Name = "Imiê")]
            public string FirstName { get; set; }
            [Display(Name = "Nazwisko")]
            public string LastName { get; set; }
            [Display(Name = "Nazwa u¿ytkownika")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Numer telefonu")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Zdjêcie profilowe")]
            public string ProfilePicture { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public AppUser userD;
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInManager { get; set; }
        private SocialNetworkContext _context;
        public string Username { get; private set; }
        [TempData]
        public string StatusMessage { get; set; }
        public LocalDB db;
        public UserPageViewModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            db = new LocalDB(userManager, signInManager, context);

        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture
            };
        }


        public async Task<IActionResult> OnGetAsync( string id)
        {
            //wczytaj obecnego u¿ytkownika
            if(id == null)
            {
                userD = await _userManager.GetUserAsync(User);
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                await LoadAsync(user);
                return Page();
            }
            //wczytaj u¿ytkownika, na którego kliknêliœmy
            else
            {
                var user = db.GetUser(id);
                userD = user.Result;
                var userName = await _userManager.GetUserNameAsync(userD);
                var phoneNumber = await _userManager.GetPhoneNumberAsync(userD);
                var firstName = userD.FirstName;
                var lastName = userD.LastName;
                var profilePicture = userD.ProfilePicture;
                Username = userName;

                Input = new InputModel
                {
                    PhoneNumber = phoneNumber,
                    Username = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    ProfilePicture = profilePicture
                };
                return Page();
            }
            
        }
    }
}
