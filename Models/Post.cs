using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Post
    {
        public int id { get; set; }
        [Display(Name = "Nazwa Posta")]
        [MinLength(2)]
        public string name { get; set; }
        [Display(Name="Opis Posta")]
        [MinLength(10)]
        public string stringContent { get; set; }
        //Data posta, która jest ważna z powodu tego, kiedy został on zrobiony
        public DateTime date { get; set; }
        public string base64Photo { get; set; }
        public int authorID { get; set; }
    }
}
