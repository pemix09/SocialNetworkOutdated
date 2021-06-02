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
    public class DetailsModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public DetailsModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comments
                .Include(c => c.Post).FirstOrDefaultAsync(m => m.commentID == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
