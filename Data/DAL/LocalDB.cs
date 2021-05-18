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
            throw new NotImplementedException();
        }

        public List<User> GetSearchResults(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
