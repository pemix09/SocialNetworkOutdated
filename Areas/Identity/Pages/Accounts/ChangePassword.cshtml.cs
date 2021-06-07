using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class ChangePasswordModel : PageModel
    {
        private SocialNetworkContext _context;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        [Display(Name = "Wpisz nowe has³o")]
        [DataType(DataType.Password)]
        //[MinLength(3)]
        //[MaxLength(16)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{3,16}$",ErrorMessage = 
            "Conajmniej 1 ma³a litera, 1 du¿a litera, 1 znak specjalny oraz 1 cyfra, od 3 do 16 znaków")]
        [Required]
        [BindProperty]
        public string newPassword { get; set; }
        public ChangePasswordModel(UserManager<AppUser> userManager)
        {
            
            _userManager = userManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string userID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.FindByIdAsync(userID);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, newPassword);
            return RedirectToPage("./UserPageEdit");
        }
    }
}
