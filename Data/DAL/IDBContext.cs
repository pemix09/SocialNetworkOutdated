using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;
using SocialNetwork.Data.DAL;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Models
{
    interface IDBContext
    {
        void SaveDB(Wrapper wrapped, IHttpContextAccessor httpContextAccessor);
        Wrapper LoadDB(IHttpContextAccessor httpContextAccessor);
        List<Post> GetOwnPosts(string userID);
        Task AddMessageAsync(Message message);
        List<Post> GetPosts(string userID);
        Task AddPostAsync(Post post);
        Task RemovePostAsync(Post post);
        List<Comment> GetPostComments(int postID);
        Task AddComment(Comment comment);
        List<AppUser> GetFriends(string userID);
        List<AppUser> GetFollowedUsers(int userID);
        public bool isTargetFriendOfSource(string userSourceID, string userTargetID);
        int GetFriendsStatus(string userSourceID, string userTargetID);
        Task AddFriend(string userSourceID, string userTargetID);
        Task RemoveFriend(string userSourceID, string userTargetID);
        Task<Post> GetPostAsync(int postID);
        Task EditPostAsync(Post editedPost);
        Task DeletePostAsync(int postID);
        void AddUser(AppUser user);
        Task<AppUser> GetUser(string userID);
        void EditUser(string userID, AppUser editedUser);
        void DeleteUser(int userID);
        List<AppUser> GetSearchResults(string searchQuery);
        List<Message> GetMessages(string userID);
    }
}
