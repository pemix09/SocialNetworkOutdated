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
        private readonly SocialNetworkContext _context;

        public LocalDB(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, SocialNetworkContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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
        public List<Message> GetMessages(string userID)
        {
            Message message = new Message();
            message.messageID = 12;
            message.messageContent = "coś tutaj wpisałem";
            message.date = DateTime.Now;
            message.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            Message message2 = new Message();
            message2.messageID = 14;
            message2.messageContent = "Kurde robi się grubo";
            message2.date = DateTime.Now;
            message2.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message2.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            Message message3 = new Message();
            message3.messageID = 15;
            message3.messageContent = "dsadas";
            message3.date = DateTime.Now;
            message3.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message3.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            Message message4 = new Message();
            message4.messageID = 12;
            message4.messageContent = "Rogelio Chávez (ur. 28 października 1984 w Tula de Allende) – meksykański piłkarz występujący głównie na pozycji prawego obrońcy, reprezentant kraju. Jest wychowankiem klubu Cruz Azul, w którym spędził większość swojej kariery. Zdobył z nim cztery wicemistrzostwa Meksyku. Na arenie międzynarodowej wygrał Ligę Mistrzów CONCACAF oraz dwukrotnie dotarł do finału tych rozgrywek. Wziął również udział w klubowych mistrzostwach świata. W barwach Cruz Azul przez 11 lat wystąpił w 304 spotkaniach. W lidze meksykańskiej przez krótki czas występował także w klubach CF Pachuca oraz Atlas FC. Następnie grał w FBC Melgar, z którym wywalczył wicemistrzostwo Peru. Pod koniec kariery został piłkarzem Arki Gdynia, na mocy umowy partnerskiej tego klubu z jednym z meksykańskich miast. Dla gdyńskiego zespołu nie zagrał jednak w żadnym oficjalnym meczu. Rozegrał jedno towarzyskie spotkanie w reprezentacji Meksyku, w kwietniu 2014 roku przeciwko Stanom Zjednoczonym (2:2). Czytaj więcej…";
            message4.date = DateTime.Now;
            message4.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message4.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            List<Message> messages = new List<Message>();
            messages.Add(message);
            messages.Add(message2);
            messages.Add(message3);
            messages.Add(message4);

            return messages;
        }

        public async Task<List<Message>> GetMessagesAsync(string userID, SocialNetworkContext context)
        {
            Message message = new Message();
            message.messageID = 12;
            message.messageContent = "coś tutaj wpisałem";
            message.date = DateTime.Now;
            message.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            Message message2 = new Message();
            message2.messageID = 14;
            message2.messageContent = "Kurde robi się grubo";
            message2.date = DateTime.Now;
            message2.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message2.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            Message message3 = new Message();
            message3.messageID = 15;
            message3.messageContent = "dsadas";
            message3.date = DateTime.Now;
            message3.recevingUserID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";
            message3.userID = "12b7fec3-4d08-4958-bcc6-84f3f8b4baad";

            List<Message> messages = new List<Message>();
            messages.Add(message);
            messages.Add(message2);
            messages.Add(message3);

            return messages;
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
            IQueryable<string> sourceFriendList = _context.Friends.Where(x => x.userID == userSourceID).Select(x => x.friendUserID);
            //możesz powyższe wykorzystać przy metodzie GetFriends
            //wybiera pola friendUserID, gdzie userID == userSourceID
            foreach(var friend in sourceFriendList)
            {
                if(friend.CompareTo(userTargetID) == 0)
                {
                    return true;//dana osoba wystepuje na liscie znajomych
                }
            }
            return false;//pudło
        }

        public async void AddFriend(string userSourceID, string userTargetID)
        {
            Friend x = await _context.Friends.SingleAsync(x => x.userID == userSourceID && x.friendUserID == userTargetID);
            if(x != null)
            {
                return;//jeśli taki znajomy istnieje to nie dodajemy go ponownie, bo inaczej poniższe metody się wywalą
            }
            Friend f = new Friend();
            f.userID = userSourceID;
            f.friendUserID = userTargetID;
            _context.Friends.Add(f);
            await _context.SaveChangesAsync();
        }
        public async void RemoveFriend(string userSourceID, string userTargetID)
        {
            Friend f = await _context.Friends.SingleAsync(x => x.userID == userSourceID && x.friendUserID == userTargetID);
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
