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
        public SocialNetworkContext _DbCtx { get; set; }

        public IEnumerable<UserInfo> Users { get; set; }
                        = Enumerable.Empty<UserInfo>();
        public SocialNetwork.Data.SocialNetworkContext _context;
        public UserInfo User = new();


        public UsersModel(SocialNetworkContext dbCtx, SocialNetwork.Data.SocialNetworkContext context)
        {
            _DbCtx = dbCtx;
            _context = context;
        }
        public async Task<IActionResult> OnPostDeleteUserAsync(int id, string stringID)
        {
            //Null exception!!!
            User = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            Users = _DbCtx.Users.ToList();
            return Page();
        }

        public void OnGet()
        {
            Users = _DbCtx.Users.ToList();
        }
    }
}
