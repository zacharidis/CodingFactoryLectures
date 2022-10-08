using CodingFactoryBlog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodingFactoryBlog.DATA
{



    public class CodingFactoryBlogDbContext : DbContext
    {
        public CodingFactoryBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        // DbContext to create the Lectures table
        public DbSet<Lecture> Lectures { get; set; }

        // tags
        public DbSet<Tag> Tags {get; set; }


    }
}
