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
        public Post(int PostID, string Name, string StringContent, DateTime Date, string Base64Photo, string UserID)
        {
            postID = PostID;
            name = Name;
            stringContent = StringContent;
            date = Date;
            base64Photo = Base64Photo;
            userID = UserID;
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //zakomentuj, jesli id ma byc generowane automatycznie
        public int postID { get; set; }
        
        [Display(Name = "Nazwa Posta")]
        [MinLength(2,ErrorMessage ="Minimalna długość posta to 2")]
        [StringLength(100, ErrorMessage ="Maksymalna długość nazwy postu to 100")]//varchar(100)
        [Required(ErrorMessage ="Nazwa posta jest wymagana")]
        public string name { get; set; }
        [Display(Name = "Opis Posta")]//opis posta? czy zawartość posta?
        [MinLength(10,ErrorMessage ="Długość opisu posta musi wynosić conajmniej 10")]
        [Required(ErrorMessage ="Opis posta jest wymagany")]//chyba post jednak powinien cos zawierac
        public string stringContent { get; set; }
        //Data posta, która jest ważna z powodu tego, kiedy został on zrobiony
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [DataType(DataType.Text)]
        #nullable enable
        public string? base64Photo { get; set; }
        public float? posX { get; set; }
        public float? posY { get; set; }
        public string? userID { get; set; }
        #nullable disable
        public AppUser AppUser { get; set; }//AUTOR
        public ICollection<Comment> Comments { get; set; }
    }
}
