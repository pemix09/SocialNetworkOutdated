using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;

namespace SocialNetwork.Data.DAL
{
    public class Wrapper
    {
        //struktura do trzymania danych w sesji
        public Wrapper(List<Message> messages, List<Post> posts)
        {
            _messages = messages;
            _posts = posts;
        }
        public List<Message> _messages;
        public List<Post> _posts;
    }
}
