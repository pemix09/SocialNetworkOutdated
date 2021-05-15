using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;

namespace SocialNetwork.Pages
{
    public class AddPostModel : PageModel
    {
        [BindProperty]
        public Post post { get; set; }
        public void OnGet()
        {
        }
    }
}
