using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApiPrev.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApiPrev.Context
{ // we use our datacontext to name our tables and we use our models to shape our table
    public class DataContext : DbContext
    {

        // The shape of our rows is depending on our models
        // the name of our table is dependent on our DbSet name!
        
        public DbSet<UserModel> Users {get; set;}
        public DbSet<BlogModel> Blogs {get; set;}
        public DbSet<FakeBlogModel> FakeBlog {get; set;}

        public DataContext(DbContextOptions options) : base (options){}
    }
}