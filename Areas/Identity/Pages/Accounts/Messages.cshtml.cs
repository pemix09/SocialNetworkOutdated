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

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class MessagesModel : PageModel
    {
        /*Powinno byæ 
         public Message message = db.GetMessages(ID);*/


        public List<Message> messages;

        
        
        
        public LocalDB db;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public SocialNetworkContext _context;

        public MessagesModel(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            db = new LocalDB(userManager, signInManager);
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public void OnGet()
        {
            messages = db.GetMessages("XD");
        }
        public void OnPost()
        {

        }
    }
}
