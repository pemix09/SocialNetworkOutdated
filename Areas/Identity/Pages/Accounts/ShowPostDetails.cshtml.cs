using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SocialNetwork.Data;
using SocialNetwork.Data.DAL;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    public class ShowPostDetailsModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public SocialNetworkContext _context;
        public LocalDB db { get; set; }
        public Post post { get; set; }
        public List<Comment> comments = new List<Comment>();
        [BindProperty]
        public Comment commentModel { get; set; }
        public AppUser user = new AppUser();
        public ShowPostDetailsModel(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            db = new LocalDB(_userManager, _signInManager, _context);
        }
        public async void OnGet(int id)
        {
            //mamy nasz post
            post = db.GetPostAsync(id, _context).Result;
            comments = db.GetPostComments(id, _context);
            if (Request.Cookies["PostID"] == null)
            {
                Response.Cookies.Append("PostID", id.ToString());
            }
        }
        public async Task<IActionResult> OnPost()
        {
            commentModel.date = DateTime.Now;
            string postID = Request.Cookies["PostID"];
            //za drugim razem dodawania komentarza siê wypierdala wszystko
            int postIntID = Int16.Parse(postID);
            Response.Cookies.Delete("PostID");
            Post postD = await db.GetPostAsync(postIntID, _context);
            commentModel.postID = postD.postID;

            var user = await _userManager.GetUserAsync(User);

            commentModel.userID = user.Id;

            if (ModelState.IsValid)
            {
                await db.AddComment(commentModel,_context);
                post = db.GetPostAsync(commentModel.postID, _context).Result;
                comments = db.GetPostComments(commentModel.postID, _context);
                Response.Cookies.Append("PostID", commentModel.postID.ToString());
                commentModel = new Comment();
                return Page();
            }
            else
            {
                post = db.GetPostAsync(postIntID, _context).Result;
                comments = db.GetPostComments(postIntID, _context);
                return Page();
            }
            //jeœli model nie jest dobry, nie pozwól przejœæ dalej
            
        }
    }
}
