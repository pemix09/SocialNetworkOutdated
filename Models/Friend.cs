using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Friend
    {
        [Key]
        public int ID { get; set; }
        public string userID { get; set; }
        public string friendUserID { get; set; }
    }
}
