using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Message
    {
        public string messageContent { get; set; }
        public DateTime date { get; set; }
        public int sendingUserID { get; set; }
        public int recevingUserID { get; set; }
    }
}
