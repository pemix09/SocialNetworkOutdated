using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;
using SocialNetwork.Data.DAL;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class FriendsModel : PageModel
    {
        public List<Friend> friends = new List<Friend>();
        public LocalDb db = new LocalDb();
        public void OnGet(string id)
        {
        }
    }
}
