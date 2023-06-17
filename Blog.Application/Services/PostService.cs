using System;
using System.Collections.Generic;
using System.Linq;
using Blog.DTOs;
using Blog.Infra.BlogDbContext;

namespace Blog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext _dbContext;

        public PostService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PostDto> GetAll() => _dbContext.Posts.ToList();

        public PostDto Get(int id) => _dbContext.Posts.FirstOrDefault(p => p.PostId == id);

        public void Add(PostDto post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = Get(id);
            if (post == null)
                return;

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public void Update(PostDto post)
        {
            var existingPost = Get(post.PostId);
            if (existingPost == null)
                return;

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Img = post.Img;

            _dbContext.SaveChanges();
        }
    }
}
