using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class Db : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public Db(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogTag>().HasKey(bt => new {bt.BlogId, bt.TagId });
        }

        //protected override void onconfiguring(dbcontextoptionsbuilder optionsbuilder)
        //{
        //    string connectionstring = "server=.\\sqlexpress;database=myblog;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;";
        //    optionsbuilder.usesqlserver(connectionstring);
        //}
    }


}
