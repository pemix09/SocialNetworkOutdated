using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    interface IDBContext
    {
        //nie mam pojęcia co z tym zrobić, ale to chyba powinno być w innym folderze? DAL czy cos w tym stylu???
        List<Post> GetPosts(int userID);
        List<Comment> GetPostComments(int postID);
        List<User> GetFriends(int userID);
        List<User> GetFollowedUsers(int userID);
        void AddPost(Post post);
        Post GetPost(int postID);
        void EditPost(int postID, Post editedPost);
        void DeletePost(int postID);
        void AddUser(User user);
        User GetUser(int userID);
        void EditUser(int userID, User editedUser);
        void DelteUser(int userID);
        List<User> GetSearchResults(string searchQuery);
        List<Message> GetMessages(int userID);
    }
}
