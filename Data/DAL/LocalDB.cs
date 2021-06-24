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

        public async Task AddMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        
        }
        public async Task AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
        public async Task RemovePostAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
       


        public void AddUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePostAsync(int postID)
        {
            Post Post = await _context.Posts.FindAsync(postID);

            if (Post != null)
            {
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }

        }

        public void DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task EditPostAsync(Post editedPost)
        {
            _context.Attach(editedPost).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
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

        public List<AppUser> GetFriends(string userID)
        {

            List<Friend> friends;
            List<AppUser> result = new List<AppUser>();
            friends = _context.Friends.ToList(); 
            foreach(Friend friend in friends)
            {
                if(friend.friendUserID == userID)
                {
                    result.Add(GetUser(friend.userID).Result);
                }
            }
            return result;
        }

        
        //Zwróć wszystkie wiadomości, zarówno wysłane jak i odebrane
        public List<Message> GetMessages(string userID)
        {
            List<Message> messages;
            List<Message> result = new List<Message>();
            messages = _context.Messages.ToList();

            //Znajdź wszystkie wiadomości, wysłane oraz otrzymane
            messages = messages.FindAll(item => item.recevingUserID == userID || item.userID == userID);
     

            //Dodaj do listy wszystkie wiadomości, zarówno te otrzymane jak i wysłane
            result.AddRange(messages.GroupBy(x => x.recevingUserID).Select(y => y.First()).ToList());

            //posortuj wiadomości tak, by najnowsze były na górze
            result.Sort(delegate (Message x, Message y)
            {
                return CompareDates(x.date, y.date);
            });


            return result;
        }
        public List<Message> GetConversation(string firstUserID, string SecondUserID)
        {
            List<Message> result;
            List<Message> messages;

            messages = _context.Messages.ToList();

            //znajdź te wiadomości, których odbiorą jest firstUserID a nadawcą SecondUserID
            result = messages.FindAll(item => item.recevingUserID == firstUserID && item.userID == SecondUserID);

            //dodaj również te wiadomości, ktorych odbiorą jest secondUserID a nadawcą firstUserID
            result.AddRange(messages.FindAll(item => item.recevingUserID == SecondUserID && item.userID == firstUserID));

            //posortuj według daty
            result.Sort(delegate (Message x, Message y)
            {
                return CompareDates(x.date, y.date); 
            });

            return result;
        }
        //komparator do dat
        private int CompareDates(DateTime x, DateTime y)
        {
            if (x > y) return -1;
            else if (x == y) return 0;
            else return 1;
        }



        public async Task<Post> GetPostAsync(int id)
        {
            Post Post = await _context.Posts.FirstOrDefaultAsync(m => m.postID == id);
            return Post;
        }

        public List<Comment> GetPostComments(int postID)
        {
            List<Comment> comments = _context.Comments.ToList();
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
        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public List<Post> GetPosts(string userID)
        {            
            List<AppUser> friends = this.GetFriends(userID);
            List<Post> friendsPosts = new List<Post>();
        
            foreach (AppUser user in friends)
            {
                if (user == null) continue;
                List<Post> friendPosts = this.GetOwnPosts(user.Id);
                foreach(Post post in friendPosts)
                {
                    friendsPosts.Add(post);
                }
            }
            friendsPosts = friendsPosts.Distinct().ToList();
            return friendsPosts;
        }

        public List<Post> GetOwnPosts(string userID)
        {
            List<Post> posts = _context.Posts.ToList();
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

        public List<AppUser> GetSearchResults(string searchQuery)
        {
            List<AppUser> users = _context.Users.ToList();
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

        public bool isTargetFriendOfSource(string userSourceID, string userTargetID)
        {
            //AppUser user1 = GetUser(userSourceID).Result;
            //AppUser user2 = GetUser(userTargetID).Result;
            //IQueryable<string> sourceFriendList = context.Friends.Where(x => x.userID == userSourceID).Select(x => x.friendUserID);

            List<Friend> friends = _context.Friends.ToList();

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
        public int GetFriendsStatus(string userSourceID, string userTargetID)
        {
            bool oneWay = isTargetFriendOfSource(userSourceID, userTargetID);
            bool secondWay = isTargetFriendOfSource(userTargetID, userSourceID);
            if(oneWay && secondWay) return 2;  
            if (oneWay) return 1;
            if (secondWay) return 3;
            return 0;
        }

        public async Task AddFriend(string userSourceID, string userTargetID)
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
            _context.Friends.Add(f);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveFriend(string userSourceID, string userTargetID)
        {
            List<Friend> friends = _context.Friends.ToList();
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
