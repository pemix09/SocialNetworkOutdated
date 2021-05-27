using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;

namespace SocialNetwork.Data.DAL
{
    public class LocalDB : IDBContext
    {
        public void AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int postID)
        {
            throw new NotImplementedException();
        }

        public void DelteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void EditPost(int postID, Post editedPost)
        {
            throw new NotImplementedException();
        }

        public void EditUser(int userID, User editedUser)
        {
            throw new NotImplementedException();
        }

        public List<User> GetFollowedUsers(int userID)
        {
            throw new NotImplementedException();
        }

        public List<User> GetFriends(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessages(int userID)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postID)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetPostComments(int postID)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts(int userID)
        {
            DateTime now = DateTime.Now;
            Post post1 = new Post(1, "nowy post", "Ciekawe co tu się stanie", now, "djęcie", 12),
                post2 = new Post(4, "nowy postXdsadD", "Cidsadsaekawe co tu się stanie", now, "djęcidsae", 13),
                post3 = new Post(4, "nowdd", "Cidsadsaekawe co tu się staniedadas", now, "djęcdasie", 14);
            return new List<Post> { post1,post2,post3 };
        }

        public List<User> GetSearchResults(string searchQuery)
        {
            User user1 = new User();
            user1.nickname = "xs";
            user1.firstName = "Przemek";
            return new List<User> { user1 };
        }

        public User GetUser(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
