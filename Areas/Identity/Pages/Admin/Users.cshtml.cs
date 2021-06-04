using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    public class UsersModel : PageModel
    {

        public IEnumerable<AppUser> Users { get; set; }
                        = Enumerable.Empty<AppUser>();
        public SocialNetworkContext _context;

        

        public UsersModel(SocialNetworkContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetDeleteUserAsync(string stringID)
        {

            AppUser AppUser = new AppUser();
            AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
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

            AppUser AppUser = new AppUser();
            AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
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

            AppUser AppUser = new AppUser();
            AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
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

