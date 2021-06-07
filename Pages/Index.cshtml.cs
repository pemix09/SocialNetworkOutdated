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
using Microsoft.AspNetCore.Http;

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
        public SocialNetworkContext _context;
        IHttpContextAccessor _httpContextAccessor;
        string currentUserID;
        public string SearchQuery;


        public IndexModel(ILogger<IndexModel> logger, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, SocialNetworkContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            newMessages = false ;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            db = new LocalDB(_userManager,_signInManager, _context);
        }

        public void OnGet(string searchQuery)
        {
            SearchQuery = searchQuery;
            currentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Message> messages = db.GetMessages(currentUserID, _context);

            foreach(Message message in messages)
            {
                if(message.isRead == false)
                {
                    newMessages = true;
                }
            }
          

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

                //dodajemy posty z sesji, jeśli jakieś są oczywiście
                /*Wrapper wrapper = db.LoadDB(_httpContextAccessor);
                posts.AddRange(wrapper._posts);
                posts = posts.Distinct().ToList();
                wrapper._posts = posts;
                db.SaveDB(wrapper, _httpContextAccessor);*/

                posts = db.GetPosts(currentUserID, _context);

                posts.Sort(delegate (Post x, Post y)
                 {
                     return CompareDates(x.date, y.date);
                 });
            }

        }
        //komparator do dat
        public int CompareDates(DateTime x, DateTime y)
        {
            if (x > y) return -1;
            else if (x == y) return 0;
            else return 1;
        }
        public async Task<IActionResult> OnGetAddFriendSearchAsync(string stringID, string searchQuery)
        {
            SearchQuery = searchQuery;
            string userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await db.AddFriend(stringID, userID, _context);
            users = db.GetSearchResults(searchQuery, _context);
            return Page();
        }
        public async Task<IActionResult> OnGetRemoveFriendSearchAsync(string stringID, string searchQuery)
        {
            SearchQuery = searchQuery;
            string userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await db.RemoveFriend(stringID, userID, _context);
            users = db.GetSearchResults(searchQuery, _context);
            return Page();
        }
        public async Task<IActionResult> OnGetAddFriendPostsAsync(string stringID)
        {
            string userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await db.AddFriend(stringID, userID, _context);
            posts = db.GetPosts(userID, _context);

            posts.Sort(delegate (Post x, Post y)
            {
                return CompareDates(x.date, y.date);
            });
            return Page();
        }
        public async Task<IActionResult> OnGetRemoveFriendPostsAsync(string stringID)
        {

            string userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await db.RemoveFriend(stringID, userID, _context);
            posts = db.GetPosts(userID, _context);

            posts.Sort(delegate (Post x, Post y)
            {
                return CompareDates(x.date, y.date);
            });
            return Page();
        }
    }
}
