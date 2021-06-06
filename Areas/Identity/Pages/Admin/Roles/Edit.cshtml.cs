using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialNetwork.Areas.Identity.Pages.Admin.Roles
{
    public class EditModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty]
        public IdentityRole currRole { get; set; }
        [BindProperty]
        public string roleName { get; set; }
        public EditModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task OnGetAsync(string stringID)
        {
            currRole = await _roleManager.FindByIdAsync(stringID);
            
        }
        public async Task<IActionResult> OnPostAsync(string stringID)
        {
            currRole = await _roleManager.FindByIdAsync(stringID);
            currRole.Name = roleName;
            await _roleManager.UpdateAsync(currRole);
            return RedirectToPage("./Index");
        }
    }
}
