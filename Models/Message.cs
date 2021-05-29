using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialNetwork.Models
{
    public class Message
    {
        [Key]
        public int messageID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]//zbędne czy nie? pusta wiadomość jest bez sensu
        public string messageContent { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public int userID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public int recevingUserID { get; set; }
        [Required]
        public Boolean isRead { get; set; }
        public User User { get; set; }//nie mam pewności, ale chyba warto przypisac wiadomość do wysyłającego
    }
}
