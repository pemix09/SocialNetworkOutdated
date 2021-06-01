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
        List<UserInfo> GetFriends(int userID);
        List<UserInfo> GetFollowedUsers(int userID);
        void AddPost(Post post);
        Post GetPost(int postID);
        void EditPost(int postID, Post editedPost);
        void DeletePost(int postID);
        void AddUser(UserInfo user);
        UserInfo GetUser(int userID);
        void EditUser(int userID, UserInfo editedUser);
        void DeleteUser(int userID);
        List<UserInfo> GetSearchResults(string searchQuery);
        List<Message> GetMessages(int userID);
    }
}
