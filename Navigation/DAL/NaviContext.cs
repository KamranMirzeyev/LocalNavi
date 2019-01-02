using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Navigation.Models;

namespace Navigation.DAL
{
    public class NaviContext:DbContext
    {
        public NaviContext() : base("NaviContext")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<CategoryService> CategoryServices { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentPhoto> CommentPhotos { get; set; }
        public DbSet<ListPhoto> ListPhotos { get; set; }
        public DbSet<ListService> ListServices { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }

        public DbSet<Photo> Photos { get; set; }
    }
}