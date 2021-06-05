using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;

namespace SocialNetwork.Areas.Identity.Pages.Admin.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly SocialNetworkContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteModel(RoleManager<IdentityRole> roleManager, SocialNetworkContext context)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> OnGetAsync(string stringID)
        {
            var role = await _roleManager.FindByIdAsync(stringID);
            await _roleManager.DeleteAsync(role);
            return RedirectToPage("./Index");
        }
    }
}
