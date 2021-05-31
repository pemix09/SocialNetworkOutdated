using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SocialNetwork.Models;

namespace SocialNetwork.Pages
{
    public class AddPostModel : PageModel
    {
        [BindProperty]
        public Post post { get; set; }
        public IBase64 converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string userID;

        public AddPostModel(IBase64 Base64Converter, IHttpContextAccessor httpContextAccessor)
        {
            converter = Base64Converter;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
            userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public IActionResult OnPost(IFormFile file)
        {
            // Extract file name from whatever was posted by browser
            var fileName = System.IO.Path.GetFileName(file.FileName);

            string base64Photo;

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
            base64Photo = converter.GetBase64FromPicture(fileName);
            DateTime now = DateTime.Now;

            System.IO.File.Delete(fileName);

            //Dobra mamy userID, zdjêcie w formacie Base64 itd. teraz wywo³aæ metodê dodawania tego postu
            //DodajPost(...)

            return RedirectToPage("Index");
        }
    }
}
