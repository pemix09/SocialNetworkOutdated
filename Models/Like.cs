using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialNetwork.Models
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }
        public string likedBy { get; set; }
        public string likedUser { get; set; }
        public AppUser AppUser { get; set; }
    }
}
