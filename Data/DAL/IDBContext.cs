using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    interface IDBContext
    {
        List<Post> GetPosts(string userID, SocialNetworkContext context);
        List<Comment> GetPostComments(int postID, SocialNetworkContext context);
        List<AppUser> GetFriends(int userID);
        List<AppUser> GetFollowedUsers(int userID);
        Task<Post> GetPostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context);
        void EditPostAsync(Post editedPost, SocialNetwork.Data.SocialNetworkContext context);
        void DeletePostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context);
        void AddUser(AppUser user);
        Task<AppUser> GetUser(string userID);
        void EditUser(string userID, AppUser editedUser);
        void DeleteUser(int userID);
        List<AppUser> GetSearchResults(string searchQuery, SocialNetworkContext context);
        List<Message> GetMessages(string userID);
        Task<List<Message>> GetMessagesAsync(string userID, SocialNetworkContext context);
    }
}
