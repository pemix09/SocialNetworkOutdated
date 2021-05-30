using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialNetwork.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }
        public int postID { get; set; }
        public int? userID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string stringContent { get; set; }
        [DataType(DataType.Text)]
        public string base64Image { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [Range(0, 10)]
        public float score { get; set; }//tak myslałem, by dać to jako enum, ale enum bierze tylko wartości stałe... 
        //jeden komentarz należy do jednego postu i autora
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
