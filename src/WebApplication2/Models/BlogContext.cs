using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Klog.Models {
    public class BlogContext : IdentityDbContext<BlogUser> {

        public BlogContext(DbContextOptions<BlogContext> options) : base (options){
            Database.EnsureCreated();
        }

        public DbSet<Blogpost> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

         //   var connectionString = config["Data:BlogContextCon"];
           // optionsBuilder.UseSqlServer(connectionString);
           // base.OnConfiguring(optionsBuilder);
        }
    }
}
