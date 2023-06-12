using System;
using apiTutorial.Models;

namespace apiTutorial.Interfaces
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post? Get(int id);
        void Add(Post post);
        void Delete(int id);
        void Update(Post post);
    }

}

