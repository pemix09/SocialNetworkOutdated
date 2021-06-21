using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Data.DAL;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class AddFriendModel : PageModel
    {
        public LocalDB db;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public SocialNetworkContext _context;
        public IHttpContextAccessor _httpContextAccessor;
        public AddFriendModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, SocialNetworkContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            db = new LocalDB(userManager, signInManager, _context);
        }
        public async Task<IActionResult> OnGet(string id)
        {
            string userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await db.AddFriend(id,userID);
            return RedirectToPage("/Index");
        }
    }
}
