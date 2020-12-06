

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfile.Models;

namespace UserProfile.Data
{
    public class UserProfileContext  : DbContext
    {

        public UserProfileContext(DbContextOptions<UserProfileContext> options)
: base(options)
        {

        }


        /*
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<BlogModel>().HasOne<UserDetails>(p=>p.use).WithMany(p=>p.Blogs);
             modelBuilder.Entity<UserDetails>().HasMany<BlogModel>(p=>p.Blogs).WithOne(p=>p.);

         }

        */


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           
           
        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<SocialDetails> SocialDetails{ get; set; }
        public DbSet<BlogModel> BlogDetails { get; set; }
        



    }
}
