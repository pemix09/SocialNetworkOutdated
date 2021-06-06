using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Data;
using SocialNetwork.Data.DAL;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Identity.Pages.Accounts
{
    //[Authorize(Roles = "User")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public class UserPageViewModel : PageModel
    {
        public class InputModel
        {
            [Display(Name = "Imiê")]
            public string FirstName { get; set; }
            [Display(Name = "Nazwisko")]
            public string LastName { get; set; }
            [Display(Name = "Nazwa profilu")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Numer telefonu")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Zdjêcie profilowe")]
            public string ProfilePicture { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public AppUser userD;
        public AppUser lookedUser;
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInManager { get; set; }
        public SocialNetworkContext _context;
        public string Username { get; private set; }
        [TempData]
        public string StatusMessage { get; set; }
        public LocalDB db;
        public List<Post> posts { get; set; }
        public UserPageViewModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            db = new LocalDB(userManager, signInManager, context);

        }

        private async Task LoadAsync(AppUser user)
        {
            userD = user;
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture
            };
        }

        public async Task<IActionResult> OnGetRemovePostAsync(int postID)
        {
            List<Post> posts = _context.Posts.ToList();
            foreach(Post post in posts)
            {
                if(post.postID == postID)
                {
                    _context.Posts.Remove(post);
                    await _context.SaveChangesAsync();
                    var user = db.GetUser(post.userID);
                    var userDD = user.Result;
                    Input = new InputModel
                    {
                        PhoneNumber = userDD.PhoneNumber,
                        Username = userDD.UserName,
                        FirstName = userDD.FirstName,
                        LastName = userDD.LastName,
                        ProfilePicture = userDD.ProfilePicture
                    };
                    userD = userDD;
                    posts = db.GetOwnPosts(userD.Id, _context);
                    return Page();
                }
            }
            posts = db.GetOwnPosts(userD.Id, _context);
            Input = new InputModel
            {
                PhoneNumber = userD.PhoneNumber,
                Username = userD.UserName,
                FirstName = userD.FirstName,
                LastName = userD.LastName,
                ProfilePicture = userD.ProfilePicture
            };
            return Page();
        }


        public async Task<IActionResult> OnGetAsync( string id)
        {
            //wczytaj obecnego u¿ytkownika
            if(id == null)
            {
                
                userD = await _userManager.GetUserAsync(User);
                posts = db.GetOwnPosts(userD.Id, _context);
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                await LoadAsync(user);
                return Page();
            }
            //wczytaj u¿ytkownika, na którego kliknêliœmy
            else
            {
                posts = db.GetOwnPosts(id, _context);
                userD = await _userManager.GetUserAsync(User);
                var user = db.GetUser(id);
                lookedUser = user.Result;

                var userName = lookedUser.UserName;//await _userManager.GetUserNameAsync(userD);
                var phoneNumber = lookedUser.PhoneNumber; //await _userManager.GetPhoneNumberAsync(userD);
                var firstName = lookedUser.FirstName; 
                var lastName = lookedUser.LastName;
                var profilePicture = lookedUser.ProfilePicture;
                Username = userName;

                Input = new InputModel
                {
                    PhoneNumber = phoneNumber,
                    Username = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    ProfilePicture = profilePicture
                };
                return Page();
            }
            
        }
    }
}
