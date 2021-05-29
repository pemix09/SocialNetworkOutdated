using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public DetailsModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post
                .Include(p => p.User).FirstOrDefaultAsync(m => m.postID == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
