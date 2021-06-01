using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Admin
{
    public class UsersModel : PageModel
    {
        public SocialNetworkContext _DbCtx { get; set; }

        public IEnumerable<User> Users { get; set; }
                        = Enumerable.Empty<User>();

        public UsersModel(SocialNetworkContext dbCtx)
        {
            _DbCtx = dbCtx;
        }

        public void OnGet()
        {
            Users = _DbCtx.Users.ToList();
        }
    }
}
