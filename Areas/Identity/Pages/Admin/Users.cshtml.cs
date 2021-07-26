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
using SocialNetwork.Data.DAL;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class UsersModel : PageModel
    {

        public IEnumerable<AppUser> Users { get; set; }
                        = Enumerable.Empty<AppUser>();
        public SocialNetworkContext _context;
        private readonly UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UsersModel(SocialNetworkContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public bool isAdmin()
        {
            var activeUser = _userManager.GetUserId(HttpContext.User);//pobierz aktualnie zalogowanego u¿ytkownika
            Role r = new Role(_context, _userManager);
            return r.HasSpecificRoleAsync(activeUser, "Admin").Result;


        }
        public bool isAdmin(string user)
        {
            //var activeUser = Environment.UserName;
            Role r = new Role(_context, _userManager);
            return r.HasSpecificRoleAsync(user, "Admin").Result;

        }
        public bool isMasterAdmin(string user)
        {
            //var activeUser = Environment.UserName;
            Role r = new Role(_context, _userManager);
            return r.HasSpecificRoleAsync(user, "MasterAdmin").Result;

        }

        public async Task<IActionResult> OnGetDeleteUserAsync(string stringID)
        {
            
            
            AppUser AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
            if (isAdmin())//jak nie jest adminem, to pomiñ, tylko admini/masteradmini maj¹ dostêp i tak
            {
                if (isAdmin(AppUser.Id) || isMasterAdmin(AppUser.Id)){
                    Users = _context.Users.ToList();
                    //admin próbuje pozbyæ siê admina/masteradmina
                    return Page();
                }
            }
            if (AppUser != null)
            {
                _context.Users.Remove(AppUser);
                await _context.SaveChangesAsync();
            }
            Users = _context.Users.ToList();
            
            return Page();
        }
        public async Task<IActionResult> OnGetBanUserAsync(string stringID)
        {

            
            AppUser AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
            if (isAdmin())
            {
                if (isAdmin(AppUser.Id) || isMasterAdmin(AppUser.Id))
                {
                    //admin próbuje pozbyæ siê admina/superadmina
                    Users = _context.Users.ToList();
                    return Page();
                }
            }
            if (AppUser != null)
            {
                AppUser.isEnabled = false;
                await _context.SaveChangesAsync();
            }
            Users = _context.Users.ToList();
            return Page();
        }
        public async Task<IActionResult> OnGetUnBanUserAsync(string stringID)
        {

            
            AppUser AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
            if (AppUser != null)
            {
                AppUser.isEnabled = true;
                await _context.SaveChangesAsync();
            }
            Users = _context.Users.ToList();
            return Page();
        }

        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}

