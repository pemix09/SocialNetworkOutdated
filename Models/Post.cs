using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Post
    {
        public Post() { }
        public Post(int PostID, string Name, string StringContent, DateTime Date, string Base64Photo, int UserID)
        {
            postID = PostID;
            name = Name;
            stringContent = StringContent;
            date = Date;
            base64Photo = Base64Photo;
            userID = UserID;
        }
        //powyższe nawala błędami jak jest, konstruktor chyba powinien być zamieniony na jakas funkcje w get w jednej ze stron
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //zakomentuj, jesli id ma byc generowane automatycznie
        public int postID { get; set; }
        [Display(Name = "Nazwa Posta")]
        [MinLength(2)]
        [StringLength(100)]//varchar(100)
        [Required]
        public string name { get; set; }
        [Display(Name = "Opis Posta")]//opis posta? czy zawartość posta?
        [MinLength(10)]
        [Required]//chyba post jednak powinien cos zawierac
        public string stringContent { get; set; }
        //Data posta, która jest ważna z powodu tego, kiedy został on zrobiony
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [DataType(DataType.Text)]
        public string? base64Photo { get; set; }
        public float? posX { get; set; }
        public float? posY { get; set; }
        [Required]//FK
        public int userID { get; set; }
        [Required]//to jest chyba zbedne, ale poki co zostawiam
        public User User { get; set; }//AUTOR
        public ICollection<Comment> Comments { get; set; }
    }
}
