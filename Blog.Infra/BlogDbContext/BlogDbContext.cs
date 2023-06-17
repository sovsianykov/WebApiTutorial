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

        public DbSet<PostDto> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships
            modelBuilder.Entity<PostDto>().ToTable("Posts");
            modelBuilder.Entity<PostDto>().HasKey(p => p.PostId);

            // Add more configurations as needed
        }
    }
}

