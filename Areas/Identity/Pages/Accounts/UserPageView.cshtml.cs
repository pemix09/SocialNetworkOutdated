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
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    [Authorize(Roles = "User")]
    public class UserPageViewModel : PageModel
    {
        public class InputModel
        {
            [Display(Name = "Imi�")]
            public string FirstName { get; set; }
            [Display(Name = "Nazwisko")]
            public string LastName { get; set; }
            [Display(Name = "Nazwa u�ytkownika")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Numer telefonu")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Zdj�cie profilowe")]
            public string ProfilePicture { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInManager { get; set; }
        public string Username { get; private set; }
        [TempData]
        public string StatusMessage { get; set; }
        public UserPageViewModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
        }
    }
}
