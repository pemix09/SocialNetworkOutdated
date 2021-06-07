using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Data.DAL
{
    public class LocalDB : IDBContext
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly SocialNetworkContext _context;

        public LocalDB(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<bool> AddMessageAsync(Message message)
        {
            
            return true;
        }
        public Wrapper LoadDB(IHttpContextAccessor httpContextAccessor)
        {
            string jsonPostsAndMessages = httpContextAccessor.HttpContext.Session.GetString("jsonPostsAndMessages");
            Wrapper wrapped;
            if (jsonPostsAndMessages != null )
            {
                wrapped = JsonSerializer.Deserialize<Wrapper>(jsonPostsAndMessages);

            }
            else
            {
                wrapped = new Wrapper();
            }
            return wrapped;
        }
        public void SaveDB(Wrapper wrapped, IHttpContextAccessor httpContextAccessor)
        {
            string jsonPostsAndMessages = JsonSerializer.Serialize(wrapped);
            httpContextAccessor.HttpContext.Session.SetString("jsonPostsAndMessages",jsonPostsAndMessages);
        }


        public void AddUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePostAsync(int postID, SocialNetwork.Data.SocialNetworkContext context)
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

        public async Task EditPostAsync(Post editedPost, SocialNetwork.Data.SocialNetworkContext context)
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

        public List<AppUser> GetFriends(string userID, SocialNetworkContext context)
        {
            
            List<Friend> friends = new List<Friend>();
            List<AppUser> result = new List<AppUser>();
            friends = context.Friends.ToList(); 
            foreach(Friend friend in friends)
            {
                if(friend.friendUserID == userID)
                {
                    result.Add(GetUser(friend.userID).Result);
                }
            }
            return result;
        }
        public List<Message> GetMessages(string userID, SocialNetworkContext context, IHttpContextAccessor httpContextAccessor)
        {
            Wrapper wrapper = this.LoadDB(httpContextAccessor);
            List<Message> messages = new List<Message>();
            if(wrapper._messages != null)
            {
                messages.AddRange(wrapper._messages);
                messages = messages.Distinct().ToList();
            }
            
            List<Message> result = new List<Message>();
            messages = context.Messages.ToList();

            foreach (Message message in messages)
            {
                if (message.recevingUserID == userID)
                {
                    result.Add(message);
                }
            }
            return result;
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
        public async Task AddComment(Comment comment, SocialNetworkContext context)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
        }

        public List<Post> GetPosts(string userID, SocialNetworkContext context)
        {
            List<AppUser> friends = this.GetFriends(userID, context);
            List<Post> friendsPosts = new List<Post>();
            foreach(AppUser user in friends)
            {
                if (user == null) continue;
                List<Post> friendPosts = this.GetOwnPosts(user.Id, context);
                foreach(Post post in friendPosts)
                {
                    friendsPosts.Add(post);
                }
            }
            return friendsPosts;
        }

        public List<Post> GetOwnPosts(string userID, SocialNetworkContext context)
        {
            List<Post> posts = context.Posts.ToList();
            List<Post> result = new List<Post>();
            foreach(Post post in posts)
            {
                if(post.userID == userID)
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
                string userName = user.UserName;
                userName = userName.ToLower();
                if(fullName.Contains(searchQuery.ToLower()))
                {
                    //jeśli pełna nazwa czyli imię+nazwisko
                    //zawiera szukaną frazę, to dodaj użytkownika do
                    //listy wynikowej
                    result.Add(user);
                }
                else if(userName.Contains(searchQuery.ToLower()))
                {
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

        public bool isTargetFriendOfSource(string userSourceID, string userTargetID, SocialNetworkContext context)
        {
            //AppUser user1 = GetUser(userSourceID).Result;
            //AppUser user2 = GetUser(userTargetID).Result;
            //IQueryable<string> sourceFriendList = context.Friends.Where(x => x.userID == userSourceID).Select(x => x.friendUserID);

            List<Friend> friends = context.Friends.ToList();

            //możesz powyższe wykorzystać przy metodzie GetFriends
            //wybiera pola friendUserID, gdzie userID == userSourceID
            foreach(Friend friend in friends)
            {
                if(friend.userID == userTargetID)
                {
                    if (friend.friendUserID == userSourceID) return true;
                }
            }
            return false;//pudło
        }

        //1 -> znajomy który sprawdza wysłał zapro
        //2 -> obustronne dodanie do znajomych
        //3 -> spradzany znjaomy wysłał zapro
        public int GetFriendsStatus(string userSourceID, string userTargetID, SocialNetworkContext context)
        {
            bool oneWay = isTargetFriendOfSource(userSourceID, userTargetID, context);
            bool secondWay = isTargetFriendOfSource(userTargetID, userSourceID, context);
            if(oneWay && secondWay) return 2;  
            if (oneWay) return 1;
            if (secondWay) return 3;
            return 0;
        }

        public async Task AddFriend(string userSourceID, string userTargetID, SocialNetworkContext context)
        {
            //poniższa walidacja nie jest potrzebna, bo ja już to wcześniej sprawdzam
            /*Friend x = await _context.Friends.SingleAsync(x => x.userID == userSourceID && x.friendUserID == userTargetID);
            if(x != null)
            {
                return;//jeśli taki znajomy istnieje to nie dodajemy go ponownie, bo inaczej poniższe metody się wywalą
            }*/
            Friend f = new Friend();
            f.userID = userSourceID;
            f.friendUserID = userTargetID;
            context.Friends.Add(f);
            await context.SaveChangesAsync();
        }
        public async Task RemoveFriend(string userSourceID, string userTargetID, SocialNetworkContext context)
        {
            List<Friend> friends = context.Friends.ToList();
            Friend f = new Friend();
            foreach (Friend friend in friends)
            {
                if (friend.userID == userSourceID) f = friend;
            }
            //zwraca pojedyńczy element
            if(f == null)
            {
                //Console.WriteLine("error");
                return;//nie powinno tutaj nigdy wejść, ale to znaczy, że nic nie znalazło, chociaż powinno
            }
            
            _context.Friends.Remove(f);
            await _context.SaveChangesAsync();
        }
        
    }
}
