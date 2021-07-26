using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;
using SocialNetwork.Services;
using SocialNetwork.Data.DAL;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Pages
{
    [Authorize]
    
    public class AddPostModel : PageModel
    {
        [BindProperty]
        public Post post { get; set; }
        public IBase64 converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string userID;
        public string _returnURL;
        
        private readonly SocialNetwork.Data.SocialNetworkContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private LocalDB db;


        public AddPostModel(IBase64 Base64Converter, IHttpContextAccessor httpContextAccessor
            , SocialNetwork.Data.SocialNetworkContext context, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            converter = Base64Converter;
            _httpContextAccessor = httpContextAccessor;
            userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);//Zwracany ci¹g znaków?
            
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            db = new LocalDB(_userManager,_signInManager, _context);
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(IFormFile file, string returnUrl = null)
        {
            /*            int postID = 
            */
            int max = 0;
            var abc = _context.Posts.ToList();
            foreach(var a in abc)
            {
                if (a.postID > max) max = a.postID;
            }
            max ++;

            _returnURL = returnUrl;
            // Extract file name from whatever was posted by browser
            if(file == null)
            {
                DateTime now = DateTime.Now;
                post.date = now;
                post.postID = max;
                post.userID = this.userID;//userID to userID, a nie identyfikator typu string, potrzebna nowa kolumna?
                if (ModelState.IsValid == true)
                {
                    await db.AddPostAsync(post);
                    if (_returnURL != null)
                    {
                        return RedirectToPage(_returnURL);
                    }
                    else
                    {
                        return RedirectToPage("/Index");

                    }
                }
                return Page();

            }
            else
            {
                
                string base64Photo;
                var fileName = System.IO.Path.GetFileName(file.FileName);
                // If file with same name exists delete it
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                // Create new local file and copy contents of uploaded file
                using (var localFile = System.IO.File.OpenWrite(fileName))
                using (var uploadedFile = file.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }
                if (fileName != null)
                {
                    base64Photo = converter.GetBase64FromPicture(fileName);
                    post.base64Photo = base64Photo;
                }

                DateTime now = DateTime.Now;
                post.date = now;
                post.postID = max;
                post.userID = this.userID;
                System.IO.File.Delete(fileName);
                //Dobra mamy userID, zdjêcie w formacie Base64 itd. teraz wywo³aæ metodê dodawania tego postu
                //DodajPost(...)
                if (ModelState.IsValid == true)
                {
                    //dodajemy post
                    await db.AddPostAsync(post);
                    if (_returnURL != null)
                    {
                        return RedirectToPage(_returnURL);
                    }
                    else
                    {
                        return RedirectToPage("/Index");

                    }
                }
                return Page();
            }

            
        }
    }
}
