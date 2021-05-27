using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;

namespace SocialNetwork.Pages
{
    public class IndexModel : PageModel
    {
        public bool newMessages { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public User user=new User();
        public Post post = new Post();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            newMessages = false;
        }

        public void OnGet(string searchQuery)
        {
            if(HttpContext != null)
            {
                user.nickname = HttpContext.User.Identity.Name;
            }

        }
    }
}
