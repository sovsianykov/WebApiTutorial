using System.Collections.Generic;
using System.Linq;
using Blog.DTOs;
using Blog.Infra;
using Blog.Infra.Models;
using AutoMapper;
using Blog.Infra.BlogDbContext;

namespace Blog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostService(BlogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PostDto> GetAll()
        {
            var posts = _dbContext.Posts.ToList();
            return _mapper.Map<List<PostDto>>(posts);
        }

        public PostDto Get(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.PostId == id);
            return _mapper.Map<PostDto>(post);
        }

        public void Add(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
                return;

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public void Update(PostDto postDto)
        {
            var existingPost = _dbContext.Posts.FirstOrDefault(p => p.PostId == postDto.PostId);
            if (existingPost == null)
                return;

            _mapper.Map(postDto, existingPost);
            _dbContext.SaveChanges();
        }
    }
}
