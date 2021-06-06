using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;
using SocialNetwork.Data.DAL;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Data;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class NewMessageModel : PageModel
    {
        [BindProperty]
        public Message message { get; set; }
        public IHttpContextAccessor _httpContextAccessor;
        UserManager<AppUser> _userManager;
        SocialNetworkContext _context;
        public LocalDB db{get;set;}
      
        public NewMessageModel(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            db = new LocalDB(userManager, signInManager, context);
            message = new Message();
            _userManager = userManager;
            _context = context;
        }
        public  void OnGet(string id)
        {
            if (Request.Cookies["RecID"] == null)
            {
                Response.Cookies.Append("RecID", id);
                
            }
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            message.date = DateTime.Now;
            message.recevingUserID = Request.Cookies["RecID"];
            
            Response.Cookies.Delete("RecID");
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            message.userID = userId;
            message.isRead = false;
            message.AppUser = user;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return RedirectToPage("Messages");
            
        }
    }
}
