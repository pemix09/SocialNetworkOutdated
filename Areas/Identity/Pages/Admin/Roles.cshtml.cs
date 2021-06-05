using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    public class RolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SocialNetworkContext _context;

        public void OnGet()
        {
        }
        public RolesModel(RoleManager<IdentityRole> roleManager, SocialNetworkContext context, UserManager<AppUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
            _config = config;
        }
        private async Task CreateRolesandUsers()
        {
            bool x = await _roleManager.RoleExistsAsync("MasterAdmin");
            if (!x)
            {
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "MasterAdmin";
                await _roleManager.CreateAsync(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new AppUser();
                user.UserName = _config.GetValue<string>("MasterAdminInformation:Name");
                user.Email = _config.GetValue<string>("MasterAdminInformation:Email");
                string userPWD = _config.GetValue<string>("MasterAdminInformation:Password");

                IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

                  
                if (chkUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "MasterAdmin");
                }
            }

              
            x = await _roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);

                var user = new AppUser();
                user.UserName = _config.GetValue<string>("AdminInformation:Name1");
                user.Email = _config.GetValue<string>("AdminInformation:Email1");
                string userPWD = _config.GetValue<string>("AdminInformation:Password1");

                IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

                var user2 = new AppUser();
                user2.UserName = _config.GetValue<string>("AdminInformation:Name2");
                user2.Email = _config.GetValue<string>("AdminInformation:Email2");
                string userPWD2 = _config.GetValue<string>("AdminInformation:Password2");

                IdentityResult chkUser2 = await _userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                if (chkUser2.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }

            // creating Creating Employee role     
            x = await _roleManager.RoleExistsAsync("User");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "User";
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
