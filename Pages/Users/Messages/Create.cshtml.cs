using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.Users.Messages
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
        ViewData["userID"] = new SelectList(_context.Users, "ID", "email");
            return Page();
        }

        [BindProperty]
        public Message Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Messages.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
