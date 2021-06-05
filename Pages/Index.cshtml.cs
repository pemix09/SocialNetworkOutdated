using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;
using SocialNetwork.Data.DAL;
using SocialNetwork.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SocialNetwork.Data;

namespace SocialNetwork.Pages
{
    //Wywołaj metody filtra, tam będą metody dziennika zdarzeń
    [CustomFilter]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public bool newMessages { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public AppUser user=new AppUser();
        public List<Post> posts;
        public List<AppUser> users;
        public LocalDB db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        SocialNetworkContext _context;
        string currentUserID;


        public IndexModel(ILogger<IndexModel> logger, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _logger = logger;
            newMessages = false;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            db = new LocalDB(_userManager,_signInManager, _context);
        }

        public void OnGet(string searchQuery)
        {
            currentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // tutaj pójdzie metoda zwracająca posty pasujące do wyszukiwania
            //i wtedy sobie posts null robimy i pokazujemy wyniki wyszukiwania
            if (searchQuery!=null)
            {
                posts = null;
                users = db.GetSearchResults(searchQuery, _context);
            }
            else if(searchQuery == null && HttpContext != null)
            {
                //user.nickname = HttpContext.User.Identity.Name;
                users = null;

                //tutaj powinna być iteracja po znajomych, żeby brać ich posty!
                posts = db.GetPosts(currentUserID,_context);
            }

        }
    }
}
