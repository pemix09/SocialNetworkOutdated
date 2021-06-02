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
        #nullable enable
        public string? userID { get; set; }
        #nullable disable
        [Required]
        [DataType(DataType.Text)]
        public string stringContent { get; set; }
        [DataType(DataType.Text)]
        #nullable enable
        public string? base64Image { get; set; }
        [Range(0, 10)]
        public float? score { get; set; }
        #nullable disable
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        //jeden komentarz należy do jednego postu i autora
        public Post Post { get; set; }
        public AppUser AppUser { get; set; }
    }
}
