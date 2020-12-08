using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFriendsSite.Models;

namespace MvcFriendsSite.Data
{
    public class MvcFriendsSiteContext : DbContext
    {
        public MvcFriendsSiteContext (DbContextOptions<MvcFriendsSiteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BlogModel>().HasOne<UserModel>(p => p.Author).WithMany(p => p.Blogs);
            modelBuilder.Entity<UserModel>().HasMany<BlogModel>(p => p.Blogs).WithOne(p => p.Author);

        }



        public DbSet<MvcFriendsSite.Models.UserModel> UserModel { get; set; }

        public DbSet<MvcFriendsSite.Models.SocialModel> SocialModel { get; set; }
        public DbSet<MvcFriendsSite.Models.BlogModel> Blogs { get; set; }
    }
}
