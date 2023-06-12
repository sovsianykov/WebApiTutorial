using System;
using apiTutorial.Interfaces;
using apiTutorial.Models;
namespace apiTutorial.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;
        private int _nextId;

        public PostService()
        {
            _posts = new List<Post>
        {
            new Post
            {
                PostId = 100,
                Title = "Default post 100",
                Content = "Lorem Lorem",
                Img = "img address"
            },
            new Post
            {
                PostId = 101,
                Title = "Default post 101",
                Content = "Lorem Lorem",
                Img = "img address"
            }
        };
            _nextId = 102;
        }

        public List<Post> GetAll() => _posts;

        public Post Get(int id) => _posts.FirstOrDefault(p => p.PostId == id);

        public void Add(Post post)
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

        public void Update(Post post)
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