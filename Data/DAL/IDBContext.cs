using Microsoft.AspNetCore.Mvc;
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
        List<AppUser> GetFriends(int userID);
        List<AppUser> GetFollowedUsers(int userID);
        void AddPostAsync(Post post, SocialNetwork.Data.SocialNetworkContext context);
        Task<Post> GetPostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context);
        void EditPostAsync(Post editedPost, SocialNetwork.Data.SocialNetworkContext context);
        void DeletePostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context);
        void AddUser(AppUser user);
        Task<AppUser> GetUser(string userID);
        void EditUser(int userID, AppUser editedUser);
        void DeleteUser(int userID);
        List<AppUser> GetSearchResults(string searchQuery);
        List<Message> GetMessages(int userID);
    }
}
