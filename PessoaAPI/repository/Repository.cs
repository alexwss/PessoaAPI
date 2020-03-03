using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PessoaAPI.Repository
{
    public class Repository
    {
        public class BloggingContext : DbContext
        {

            public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
            {

            }

            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }

        }

        public class Blog
        {

            [Key]
            public int id { get; set; }
            public string description { get; set; }

            //public List<Post> Posts { get; } = new List<Post>();
        }

        public class Post
        {
            [Key]
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }

        }
    }
}