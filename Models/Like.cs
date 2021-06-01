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
        public int likedBy { get; set; }
        public int likedUser { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
