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
        public LocalDB db = new LocalDB();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            newMessages = false;
        }

        public void OnGet(string searchQuery)
        {
            if(HttpContext != null)
            {
                //user.nickname = HttpContext.User.Identity.Name;
                posts = db.GetPosts(1);
            }

        }
    }
}
