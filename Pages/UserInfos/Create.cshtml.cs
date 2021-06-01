using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.UserInfos
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
            return Page();
        }

        [BindProperty]
        public UserInfo UserInfo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(UserInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
