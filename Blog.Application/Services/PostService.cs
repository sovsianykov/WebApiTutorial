using System;
using Blog.DTOs;
namespace Blog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly List<PostDto> _posts;
        private int _nextId;

        public PostService()
        {
            _posts = new List<PostDto>
        {
            new PostDto
            {
                PostId = 100,
                Title = "Default post 100",
                Content = "Lorem Lorem",
                Img = "img address"
            },
            new PostDto
            {
                PostId = 101,
                Title = "Default post 101",
                Content = "Lorem Lorem",
                Img = "img address"
            }
        };
            _nextId = 102;
        }

        public List<PostDto> GetAll() => _posts;

        public PostDto Get(int id) => _posts.FirstOrDefault(p => p.PostId == id);

        public void Add(PostDto post)
        {
            post.PostId = _nextId++;
            _posts.Add(post);
        }

        public void Delete(int id)
        {
            var post = Get(id);
            if (post == null)
                return;

            _posts.Remove(post);
        }

        public void Update(PostDto post)
        {
            var existingPost = Get(post.PostId);
            if (existingPost == null)
                return;

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.Img = post.Img;
        }
    }

}