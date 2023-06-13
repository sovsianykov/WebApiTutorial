using System;
using Blog.DTOs;
namespace Blog.Application.Services
{
    public interface IPostService
    {
        List<PostDto> GetAll();
        PostDto? Get(int id);
        void Add(PostDto post);
        void Delete(int id);
        void Update(PostDto post);
    }

}

