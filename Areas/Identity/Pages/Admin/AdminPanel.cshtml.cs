using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AdminPanelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
