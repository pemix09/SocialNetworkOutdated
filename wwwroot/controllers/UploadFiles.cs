using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.wwwroot.controllers
{
    public class UploadFiles : Controller
    {
        private IHostingEnvironment hostingEnv;

        public UploadFiles(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFiles()
        {
            long size = 0;
            var files = Request.Form.Files;

            foreach (var file in files)
            {
                string filename = hostingEnv.WebRootPath
                + $@"\uploadedfiles\{file.FileName}";
                size += file.Length;
                using (FileStream fs =
                System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            string message = $"{files.Count} file(s) / 
            { size}
            bytes uploaded successfully!";
    return Json(message);
        }
    }
}
