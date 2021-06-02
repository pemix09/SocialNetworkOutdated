using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;

namespace SocialNetwork.Data.DAL
{
    public class LocalDB : IDBContext
    {
        public async void AddPostAsync(Post post, SocialNetwork.Data.SocialNetworkContext context)
        {
            context.Posts.Add(post);
            await context.SaveChangesAsync();
        }

        public void AddUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int postID)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void EditPost(int postID, Post editedPost)
        {
            throw new NotImplementedException();
        }

        public void EditUser(int userID, UserInfo editedUser)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetFollowedUsers(int userID)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetFriends(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessages(int userID)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postID)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetPostComments(int postID)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts(int userID)
        {
            DateTime now = DateTime.Now;
            
            Post post1 = new Post(1, "nowy post", "Ciekawe co tu się stanie", now, "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0zIDI0aDE5di0yM2gtMXYyMmgtMTh2MXptMTctMjRoLTE4djIyaDE4di0yMnptLTEgMWgtMTZ2MjBoMTZ2LTIwem0tMiAxNmgtMTJ2MWgxMnYtMXptMC0zaC0xMnYxaDEydi0xem0wLTNoLTEydjFoMTJ2LTF6bS03LjM0OC0zLjg2M2wuOTQ4LjNjLS4xNDUuNTI5LS4zODcuOTIyLS43MjUgMS4xNzgtLjMzOC4yNTctLjc2Ny4zODUtMS4yODcuMzg1LS42NDMgMC0xLjE3MS0uMjItMS41ODUtLjY1OS0uNDE0LS40MzktLjYyMS0xLjA0LS42MjEtMS44MDIgMC0uODA2LjIwOC0xLjQzMi42MjQtMS44NzguNDE2LS40NDYuOTYzLS42NjkgMS42NDItLjY2OS41OTIgMCAxLjA3My4xNzUgMS40NDMuNTI1LjIyMS4yMDcuMzg2LjUwNS40OTYuODkybC0uOTY4LjIzMWMtLjA1Ny0uMjUxLS4xNzctLjQ0OS0uMzU4LS41OTQtLjE4Mi0uMTQ2LS40MDMtLjIxOC0uNjYzLS4yMTgtLjM1OSAwLS42NS4xMjktLjg3NC4zODYtLjIyMy4yNTgtLjMzNS42NzUtLjMzNSAxLjI1MiAwIC42MTMuMTEgMS4wNDkuMzMxIDEuMzA4LjIyLjI2LjUwNi4zOS44NTguMzkuMjYgMCAuNDg0LS4wODIuNjcxLS4yNDguMTg3LS4xNjUuMzIyLS40MjUuNDAzLS43Nzl6bTMuMDIzIDEuNzhsLTEuNzMxLTQuODQyaDEuMDZsMS4yMjYgMy41ODQgMS4xODYtMy41ODRoMS4wMzdsLTEuNzM0IDQuODQyaC0xLjA0NHoiLz48L3N2Zz4=", 5),
                post2 = new Post(4, "nowy postXdsadD", "Cidsadsaekawe co tu się stanie", now, "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0yMiAwaC0yMHYyNGgxNGw2LTZ2LTE4em0tNyAyM2gtMTJ2LTIyaDE4djE2aC02djZ6bTEtNWg0LjU4NmwtNC41ODYgNC41ODZ2LTQuNTg2em0tMyAxaC04djFoOHYtMXptMC0zaC04djFoOHYtMXptNi0ydi0xaC0xNHYxaDE0em0wLTRoLTR2MWg0di0xem0tNi4wMDYgMWgtNy45OTFsLS4wMDMtLjc4OWMtLjAwMy0uNzItLjAwNi0xLjYxNSAxLjMxNC0xLjkyIDEuNDgzLS4zNDEgMS4yMzYtLjQxOCAxLjE1OC0uNTYzLTEuMDc4LTEuOTg4LS43MS0zLjE3My0uMzk1LTMuNzAzLjM4OC0uNjUxIDEuMDg5LTEuMDI1IDEuOTIzLTEuMDI1LjgyNyAwIDEuNTIzLjM2OCAxLjkxIDEuMDExLjU0NS45MDQuNDA5IDIuMjIyLS4zNzkgMy43MTMtLjEwNS4xOTYtLjE5NS4yNTUgMS4xMTkuNTU5IDEuMzU1LjMxMiAxLjM1MiAxLjIxMiAxLjM1IDEuOTM2bC0uMDA2Ljc4MXptLTYuOTk0LTFoNmMtLjAwNy0uNTQ3LS4wNy0uNjI2LS41NC0uNzM0LS44NTUtLjE5OC0xLjYyOS0uMzc2LTEuOTAxLS45NzItLjE0Mi0uMzExLS4xMTMtLjY2LjA4Ny0xLjAzOS42MS0xLjE1MS43NTgtMi4xNDYuNDA3LTIuNzI5LS4yNzYtLjQ1OC0uNzc4LS41MjYtMS4wNTMtLjUyNi0uNDggMC0uODU3LjE5LTEuMDYzLjUzNy0uMzUyLjU5LS4yMDEgMS41OC40MTQgMi43MTQuMjA0LjM3Ny4yMzYuNzI3LjA5NSAxLjAzOS0uMjY5LjU5OC0xLjAzNi43NzQtMS44NDcuOTYyLS41MjUuMTIxLS41OTMuMjAyLS41OTkuNzQ4em0xMy0ydi0xaC00djFoNHptMC00aC00djFoNHYtMXoiLz48L3N2Zz4=", 6),
                post3 = new Post(4, "nowdd", "Cidsadsaekawe co tu się staniedadas", now, "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik00Ljg2MSA5LjcxM2MtLjEzMS0uMTQ2LS4yNDItLjI5OS0uMzMtLjQ1OXYtMy4xODFsNy4xMDcgMy44MDQgNy44NTItMy4yOTh2Mi42NzVjLS4wNzQuMTUtLjE2OS4yOTQtLjI4NC40MzEuMzQyLjk0OC4zOTIgMi4wNzMuMzk5IDIuNjIzIDEuMjI5LS40MzcgMi4zOTguNTkzIDIuMzk4IDIuNDkyIDAgMy4yMDgtMi40NjIgNC4wMTctMi41NjEgNC4wNTMtMi40MTQgNC43NzYtNi4yNzYgNS4xNDctNy40MDQgNS4xNDctMS4xMjggMC00Ljk5LS4zNzItNy40MDMtNS4xNDctLjEtLjAzNi0yLjU2My0uODQ1LTIuNTYzLTQuMDYxIDAtMi4wMDMgMS4yODktMi45MTcgMi40LTIuNDguMDA3LS41NTEuMDU2LTEuNjU5LjM4OS0yLjU5OXptMTMuNTIuNjY5Yy0xLjYyIDEuMDMyLTQuNDMxIDEuNTI0LTYuMzcxIDEuNTI0LTIuMTA3IDAtNC43MzYtLjUwMS02LjMxOS0xLjUwOC0uMTU2LjYyMS0uMjQxIDEuMjk4LS4yNDEgMi4wMzMgMCAuNTI4LS40MjUuOTE4LS44OTcuOTE4LS4xMjEgMC0uMjQ0LS4wMjYtLjM2NS0uMDgtLjA2LS4wMjktLjE1Mi0uMDUxLS4yNTYtLjA1MS0uMTEyIDAtLjIzNi4wMjYtLjM0NC4wOTktLjg5OC41OTUtLjgwNCAzLjgzOCAxLjM5MyA0LjU5OC4yMTkuMDc2LjQwMy4yMzguNTA5LjQ1MSAyLjE2IDQuMjk5IDUuNTU3IDQuNjM0IDYuNTQ4IDQuNjM0Ljk5IDAgNC4zODktLjMzNSA2LjU0Ny00LjYzNC4xMDgtLjIxMy4yOTEtLjM3NS41MS0uNDUxIDIuMTk3LS43NiAyLjI5MS00LjAwMyAxLjM5My00LjU5OC0uMzY1LS4yNDUtLjYzMi4wMzItLjk2NC4wMzItLjQ3MiAwLS44OTgtLjM4OC0uODk4LS45MTggMC0uNzQxLS4wODUtMS40MjQtLjI0NS0yLjA0OXptNC42MTktLjM3M2gtMi45OWwxLjAxMi0yLjAwMi0uMDE1LTMuMTQyLTkuMzE2IDMuOTA3LTkuNjkxLTUuMTIgMTAuNDUxLTMuNjUxIDkuNTUyIDQuNDQ2djMuNTZsLjk5NyAyLjAwMnoiLz48L3N2Zz4=", 7);
            return new List<Post> { post1,post2,post3 };
        }

        public List<UserInfo> GetSearchResults(string searchQuery)
        {
            UserInfo user1 = new UserInfo(), user2=new UserInfo(), user3=new UserInfo();
            user1.nickname = "xs";
            user1.firstName = "Przemek";
            user2.nickname = "kozak";
            user2.firstName = "Damian";
            user3.nickname = "dasdas";
            user3.firstName = "Ola";
            return new List<UserInfo> { user1, user2, user3 };
        }

        public UserInfo GetUser(int userID)
        {
            UserInfo user = new UserInfo();
            user.nickname = "lol";
            user.firstName = "Damian";
            return user;
        }
    }
}
