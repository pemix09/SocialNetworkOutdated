using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Base64Converter : IBase64
    {
        public IConfiguration _config;
        public Base64Converter(IConfiguration config)
        {
            _config = config;
        }
        public string GetBase64FromPicture(string filePath)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }

        public Image GetPictureFromBase64(string base64Image)
        {
            Image img = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64Image)));
            return img;
        }
    }
}
