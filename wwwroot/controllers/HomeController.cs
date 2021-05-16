using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SocialNetwork.wwwroot.controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostingEnvironment hostingEnv;

        public UploadFiles(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        public HomeController(Ilogger<HomeController> logger) => _logger = logger; 

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
                string filename = hostingEnv.WebRootPath + $@"\src\{file.FileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            string message = $"{files.Count} file(s) / {size} bytes uploaded successfully!";
            return Json(message);
        }
    }
}
