using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialNetwork.Areas.Identity.Pages.Admin.Roles
{
    public class AddModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;

        [DataType(DataType.Text)]
        [Display(Name = "Nazwa nowej roli")]
        [BindProperty]
        public string roleName { get; set; }
        public AddModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var v = await _roleManager.RoleExistsAsync(roleName);
            if (v == false)
            {

                var role = new IdentityRole();
                role.Name = roleName;
                await _roleManager.CreateAsync(role);
                return RedirectToPage("./Index");
            }
            return Page();
        }

    }
}
