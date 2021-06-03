using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkContext : IdentityDbContext<AppUser>
    {
        public SocialNetworkContext (DbContextOptions<SocialNetworkContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("SocialNetwork");
            /*modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "IdentityUser");
            });*/
            modelBuilder.Entity<AppUser>().ToTable("IdentityUser");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Like>().ToTable("Likes");

        }
    }
}
