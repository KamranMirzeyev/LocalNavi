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
        public DbSet<Country> Countries { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
    }
}