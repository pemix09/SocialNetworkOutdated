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

namespace SocialNetwork.Areas.Identity.Pages.Admin.Roles
{
    [Authorize(Roles = "MasterAdmin")]
    public class IndexModel : PageModel
    {
        //private readonly RoleManager<IdentityRole> _roleManager;
       // private readonly UserManager<AppUser> _userManager;
        private readonly SocialNetworkContext _context;
        public IEnumerable<IdentityRole> Roles { get; set; }
                        = Enumerable.Empty<IdentityRole>();
        public IndexModel(SocialNetworkContext context/*, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager*/)
        {
           // _roleManager = roleManager;
            //_userManager = userManager;
            _context = context;
        }
        public void OnGet()
        {
            Roles = _context.Roles.ToList();
        }
    }
}
