using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Pages.UserInfos
{
    public class DetailsModel : PageModel
    {
        private readonly SocialNetwork.Data.SocialNetworkContext _context;

        public DetailsModel(SocialNetwork.Data.SocialNetworkContext context)
        {
            _context = context;
        }

        public UserInfo UserInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserInfo = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            if (UserInfo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
