using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using SocialNetwork.Data;
using System;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    //[Authorize(Policy = "RequireAdministratorRole")]
    public class ClaimsModel : PageModel
    {
        public ApplicationClaimsTypes ApplicationClaimsTypes = new();
        public List<String> AppClaimTypes;
        IHttpContextAccessor httpAccessor;
        public AppUser User = new();
        public SocialNetwork.Data.SocialNetworkContext _context;
        public ClaimsModel(UserManager<AppUser> mgr, IHttpContextAccessor httpContextAccessor,
            SocialNetwork.Data.SocialNetworkContext context)
        {
            UserManager = mgr;
            httpAccessor = httpContextAccessor;
            AppClaimTypes = ApplicationClaimsTypes.AppClaimTypes;

            //tutaj przypisujemy ID u¿ytkownika w postaci string do Id
            Id = httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context = context;
        }


        public UserManager<AppUser> UserManager { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, string stringID)
        {
            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
            if (string.IsNullOrEmpty(Id))
            {
                //Redirect to NotFound
                return RedirectToPage("Index");
            }
            if(id>0)
            {
                Id = User.Id;
            }
            AppUser user = await UserManager.FindByIdAsync(Id);
            Claims = await UserManager.GetClaimsAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAddClaimAsync([Required] string type,
                                                             [Required] string value,
                                                             int id, string stringID,
                                                             string hiddenStringID)
        {

            AppUser user = await UserManager.FindByIdAsync(hiddenStringID);

            if (ModelState.IsValid)
            {
                var claim = new Claim(type, value);
                var result = await UserManager.AddClaimAsync(user, claim);
                if (!result.Succeeded)
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                }
            }
            Claims = await UserManager.GetClaimsAsync(user);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditClaimAsync([Required] string type,
                                                              [Required] string value,
                                                              [Required] string oldValue,
                                                              int id, string stringID)
        {
            AppUser user;
            if (id > 0)
            {
                User = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
                user = await UserManager.FindByIdAsync(User.Id);
            }
            else
            {
                string ID = httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                user = await UserManager.FindByIdAsync(ID);
            }
            if (ModelState.IsValid)
            {
                var claimNew = new Claim(type, value);
                var claimOld = new Claim(type, oldValue);
                var result = await UserManager.ReplaceClaimAsync(user, claimOld, claimNew);
            }
            Claims = await UserManager.GetClaimsAsync(user);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteClaimAsync([Required] string type,
                                                                [Required] string value,
                                                                int id, string stringID)
        {
            AppUser user;
            if (id>0)
            {
                User = await _context.Users.FirstOrDefaultAsync(m => m.Id == stringID);
                user = await UserManager.FindByIdAsync(User.Id);
            }
            else
            {
                string ID = httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); 
                user = await UserManager.FindByIdAsync(ID);
            }
            if (ModelState.IsValid)
            {
                var claim = new Claim(type, value);
                var result = await UserManager.RemoveClaimAsync(user, claim);
            }
            Claims = await UserManager.GetClaimsAsync(user);
            return RedirectToPage();

        }
    }
}
