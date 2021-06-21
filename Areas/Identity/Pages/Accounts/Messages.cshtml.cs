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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class MessagesModel : PageModel
    {
        /*Powinno byæ 
         public Message message = db.GetMessages(ID);*/


        public List<Message> messages;
        string userId;
        public LocalDB db;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public SocialNetworkContext _context;
        public IHttpContextAccessor _httpContextAccessor;

        public MessagesModel(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, SocialNetworkContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            db = new LocalDB(userManager, signInManager, _context);
            userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        }
        //komparator do dat
        public int CompareDates(DateTime x, DateTime y)
        {
            if (x > y) return -1;
            else if (x == y) return 0;
            else return 1;
        }
        public void OnGet()
        {

            messages = db.GetMessages(userId);
            
            //czytamy wszystkie wiadomoœci
            foreach(Message message in messages)
            {
                message.isRead = true;
            }
            //posortuj wiadomoœci tak, by najnowsze by³y na górze
            messages.Sort(delegate (Message x, Message y)
                {
                    return CompareDates(x.date, y.date);
                });

        }
        public void OnPost()
        {

        }
    }
}
