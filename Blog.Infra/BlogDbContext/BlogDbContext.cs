using Microsoft.EntityFrameworkCore;
using Blog.DTOs;
using Blog.Infra.Models;

namespace Blog.Infra.BlogDbContext
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships

            modelBuilder.Entity<Post>().ToTable("Posts");
            //modelBuilder.Entity<Post>().HasKey(p => p.PostId);

            // Add more configurations as needed
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=blog.db", b => b.MigrationsAssembly("Blog.Web"));
            }
        }
    }
}

