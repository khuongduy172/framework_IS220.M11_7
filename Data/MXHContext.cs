using System;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Social_network.Models;

namespace Social_network.Data
{
    public class MXHContext : DbContext 
    {
        public MXHContext() 
        {

        }
        public MXHContext(DbContextOptions<MXHContext> options) : base(options)
        {

        }

        public DbSet<UserLikePage> UserLikePages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserLikePage>().ToTable("User_like_page");
        }
    }
}