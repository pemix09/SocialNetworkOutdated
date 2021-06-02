using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.Posts.Comments
{
    public class IndexModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public IndexModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; }

        public async Task OnGetAsync()
        {
            Comment = await _context.Comments
                .Include(c => c.Post).ToListAsync();
        }
    }
}
