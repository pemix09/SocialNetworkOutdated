using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using Microsoft.AspNetCore.Identity;



namespace SocialNetwork.Data.DAL
{
    public class LocalDB : IDBContext
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LocalDB(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async void AddPostAsync(Post post, SocialNetworkContext context)
        {
            context.Posts.Add(post);
            //await context.SaveChangesAsync();
        }

        public void AddUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async void DeletePostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context)
        {
            Post Post = await context.Posts.FindAsync(postID);

            if (Post != null)
            {
                context.Posts.Remove(Post);
                await context.SaveChangesAsync();
            }

        }

        public void DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public async void EditPostAsync(Post editedPost, SocialNetwork.Data.SocialNetworkContext context)
        {
            context.Attach(editedPost).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            //jeśli postu nie znajdziesz w bazie, to nic z nim nie rób
            catch (DbUpdateConcurrencyException)
            {
                return;
            }
        }

        public void EditUser(string userID, AppUser editedUser)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetFollowedUsers(int userID)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetFriends(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessages(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostAsync(int id, SocialNetworkContext context)
        {
            Post Post = await context.Posts.FirstOrDefaultAsync(m => m.postID == id);
            return Post;
        }

        public List<Comment> GetPostComments(int postID, SocialNetworkContext context)
        {
            List<Comment> comments = context.Comments.ToList();
            List<Comment> result = new List<Comment>();
            foreach(Comment comment in comments)
            {
                if(comment.postID == postID)
                {
                    result.Add(comment);
                }
            }
            return result;
        }

        public List<Post> GetPosts(string userID, SocialNetworkContext context)
        {
            List<Post> posts = context.Posts.ToList();
            List<Post> result = new List<Post>();

            foreach(Post post in posts)
            {
                if(post.userID.CompareTo(userID) == 0)
                {
                    result.Add(post);
                }
            }
            return result;
        }

        public List<AppUser> GetSearchResults(string searchQuery, SocialNetworkContext context)
        {
            List<AppUser> users = context.Users.ToList();
            List<AppUser> result = new List<AppUser>();

            foreach(AppUser user in users)
            {
                string fullName = user.FirstName + " " + user.LastName;
                fullName = fullName.ToLower();
                if(fullName.Contains(searchQuery.ToLower()))
                {
                    //jeśli pełna nazwa czyli imię+nazwisko
                    //zawiera szukaną frazę, to dodaj użytkownika do
                    //listy wynikowej
                    result.Add(user);
                }
            }

            return result;
        }

        public async Task<AppUser> GetUser(string userID)
        {
            AppUser user = await _userManager.FindByIdAsync(userID);
            return user;
        }
    }
}
