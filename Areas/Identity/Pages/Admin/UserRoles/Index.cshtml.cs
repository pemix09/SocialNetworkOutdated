using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Admin.UserRoles
{
    [Authorize(Roles = "MasterAdmin")]
    public class IndexModel : PageModel
    {
        public IEnumerable<AppUser> Users { get; set; }
                           = Enumerable.Empty<AppUser>();
        public SocialNetworkContext _context;
        private readonly UserManager<AppUser> _userManager;


        public IndexModel(SocialNetworkContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}
