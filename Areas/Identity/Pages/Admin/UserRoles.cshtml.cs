using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    [Authorize(Roles = "MasterAdmin")]
    public class UserRolesModel : PageModel
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SocialNetworkContext _context;
        [BindProperty]
        public List<IdentityRole> roles { get; set; }
        
        [BindProperty]
        public string currentRoleName { get; set; }
        [BindProperty]
        public string selectedRole { get; set; }
        public UserRolesModel(SocialNetworkContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<string> getCurrentRole(AppUser user)
        {
            string currentRoleName = null;
            var roles = await _userManager.GetRolesAsync(user);

            foreach (string role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role))
                {
                    currentRoleName = role;
                }
            }
            return currentRoleName;
        }
        public void OnGet(string stringID)
        {
            roles = _context.Roles.ToList();
             var res = _userManager.FindByIdAsync(stringID);
            res.Wait();
            var user = res.Result;
             var res2 = getCurrentRole(user);
            res2.Wait();
            currentRoleName = res2.Result;
            if (currentRoleName == null)
            {
                currentRoleName = "Brak przydzielonej roli";
            }
            
        }
        public async Task<IActionResult> OnPost(string stringID)
        {
           
            var user = await _userManager.FindByIdAsync(stringID);
            currentRoleName = await getCurrentRole(user);
            
            if (currentRoleName == null)
            {
                currentRoleName = "User";
                await _userManager.AddToRoleAsync(user, selectedRole);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, currentRoleName);
                await _userManager.AddToRoleAsync(user, selectedRole);
            }


            return RedirectToPage("./Users");
        }
        
    }
}
