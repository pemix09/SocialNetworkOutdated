using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.Posts.Comments
{
    public class CreateModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public CreateModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["postID"] = new SelectList(_context.Posts, "postID", "name");
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
