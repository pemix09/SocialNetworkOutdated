using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public DetailsModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
