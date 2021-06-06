using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;
using SocialNetwork.Data.DAL;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class FriendsModel : PageModel
    {
        public List<AppUser> friends;
        public string id;
        string userId;
        public LocalDB db;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public SocialNetworkContext _context;
        public IHttpContextAccessor _httpContextAccessor;
        public string UserID;
        public FriendsModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, SocialNetworkContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            db = new LocalDB(userManager, signInManager, _context);
            userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public void OnGet(string id)
        {
            UserID = id;
            friends = db.GetFriends(id,_context);
        }
        public async Task<IActionResult> OnGetRemoveFriendAsync(string RemovedStringID, string userID)
        {
            await db.RemoveFriend(RemovedStringID, userID, _context);
            friends = db.GetFriends(userID, _context);
            return Page();
        }
        public async Task<IActionResult> OnGetAddFriendPostsAsync(string RemovedStringID, string userID)
        {
            await db.AddFriend(RemovedStringID, userID, _context);
            friends = db.GetFriends(userID, _context);
            return Page();
        }
    }
}
