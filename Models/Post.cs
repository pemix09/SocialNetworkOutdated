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
        public Post(int _id, string _name, string content, DateTime _date, string photo64, int autID)
        {
            postID = _id;
            name = _name;
            stringContent = content;
            date = _date;
            base64Photo = photo64;
            userID = autID;
        }
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
        public string base64Photo { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        [Required]//FK
        public int userID { get; set; }
        [Required]//to jest chyba zbedne, ale poki co zostawiam
        public User User { get; set; }//AUTOR
        public ICollection<Comment> Comments { get; set; }
    }
}
