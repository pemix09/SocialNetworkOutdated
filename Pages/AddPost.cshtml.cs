using System;
using System.Collections.Generic;
using System.Linq;
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

        public AddPostModel(IBase64 Base64Converter)
        {
            converter = Base64Converter;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(IFormFile file)
        {
            // Extract file name from whatever was posted by browser
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
            

            return RedirectToPage("Index");
        }
    }
}
