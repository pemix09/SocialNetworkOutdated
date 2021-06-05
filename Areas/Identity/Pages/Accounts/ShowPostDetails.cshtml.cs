using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SocialNetwork.Data;
using SocialNetwork.Data.DAL;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class ShowPostDetailsModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public SocialNetworkContext _context;
        public LocalDB db { get; set; }
        public Post post { get; set; }
        public ShowPostDetailsModel(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            db = new LocalDB(_userManager, _signInManager, _context);
        }
        public void OnGet(string id)
        {

        }
    }
}
