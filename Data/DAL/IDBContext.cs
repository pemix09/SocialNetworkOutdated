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
        List<Post> GetOwnPosts(string userID, SocialNetworkContext context);
        Task<bool> AddMessageAsync(Message message);
        List<Post> GetPosts(string userID, SocialNetworkContext context);
        List<Comment> GetPostComments(int postID, SocialNetworkContext context);
        Task AddComment(Comment comment, SocialNetworkContext context);
        List<AppUser> GetFriends(string userID, SocialNetworkContext context);
        List<AppUser> GetFollowedUsers(int userID);
        public bool isTargetFriendOfSource(string userSourceID, string userTargetID, SocialNetworkContext context);
        int GetFriendsStatus(string userSourceID, string userTargetID, SocialNetworkContext context);
        Task AddFriend(string userSourceID, string userTargetID, SocialNetworkContext context);
        Task RemoveFriend(string userSourceID, string userTargetID, SocialNetworkContext context);
        Task<Post> GetPostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context);
        Task EditPostAsync(Post editedPost, SocialNetwork.Data.SocialNetworkContext context);
        Task DeletePostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context);
        void AddUser(AppUser user);
        Task<AppUser> GetUser(string userID);
        void EditUser(string userID, AppUser editedUser);
        void DeleteUser(int userID);
        List<AppUser> GetSearchResults(string searchQuery, SocialNetworkContext context);
        List<Message> GetMessages(string userID, SocialNetworkContext context);
        Task<List<Message>> GetMessagesAsync(string userID, SocialNetworkContext context);
    }
}
