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
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    [Authorize(Policy = "AllDefaultRoles")]
    public class FriendsModel : PageModel
    {
        public List<AppUser> friends;
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
        public void OnGet(string userID)
        {
            UserID = userID;
            friends = db.GetFriends(userID,_context);
        }
       
        public async Task<IActionResult> OnGetRemoveFriendAsync(string RemovedStringID, string userID)
        {
            await db.RemoveFriend(RemovedStringID, userID, _context);
            friends = db.GetFriends(userID, _context);
            return Page();
        }
        public async Task<IActionResult> OnGetAddFriendPostsAsync(string AddedStringID, string userID)
        {
            await db.AddFriend(AddedStringID, userID, _context);
            friends = db.GetFriends(userID, _context);
            return Page();
        }
    }
}
