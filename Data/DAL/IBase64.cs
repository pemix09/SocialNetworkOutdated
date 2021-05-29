using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace SocialNetwork.Models
{
    public interface IBase64
    {
        public string GetBase64FromPicture(string filePath);
        public Image GetPictureFromBase64(string base64Image);
    }
}
