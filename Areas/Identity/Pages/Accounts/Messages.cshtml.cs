using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;
using SocialNetwork.Data.DAL;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class MessagesModel : PageModel
    {
        public List<Message> messages = new List<Message>();
        public LocalDB db;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public MessagesModel(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            db = new LocalDB(userManager, signInManager);
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
    }
}
