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
    public class DeleteModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public DeleteModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.UserInfo).FirstOrDefaultAsync(m => m.commentID == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comments.FindAsync(id);

            if (Comment != null)
            {
                _context.Comments.Remove(Comment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
