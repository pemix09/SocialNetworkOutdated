using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Models;




namespace SocialNetwork.Pages
{
    [Authorize(Policy = "AllDefaultRoles")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public class UserPageEditModel : PageModel
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
            [Display(Name = "Profile Picture")]
            public string ProfilePicture { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInManager { get; set; }
        public string Username { get; private set; }
        [TempData]
        public string StatusMessage { get; set; }

        private IBase64 _converter;
        private readonly SocialNetworkContext _context;
        public UserPageEditModel(SocialNetworkContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBase64 converter)
        {
            _converter = converter;
            _context = context;
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
                return NotFound($"Nie znaleziono u¿ytkownika o danym ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nie znaleziono u¿ytkownika o danym ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Wyst¹pi³ problem podczas zmiany numeru telefonu.";
                    return RedirectToPage();
                }
            }
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var userName = user.UserName;
            if (Input.FirstName != firstName)
            {

                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if(Input.Username != userName)
            {
                user.UserName = Input.Username;
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0) // czy coœ zosta³o dodane w za³¹czniku
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                var filepath = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(filepath))
                {
                    await file.CopyToAsync(stream);
                }
                
                var data = _converter.GetBase64FromPicture(filepath);
                user.ProfilePicture = data;
                await _userManager.UpdateAsync(user);
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Zaktualizowano profil";
            return RedirectToPage();
        }
    }
}
