using Microsoft.AspNetCore.Mvc;
using apiTutorial.Services;
using apiTutorial.Models;
using apiTutorial.Interfaces;

namespace apiTutorial.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public ActionResult<List<Post>> GetAll() =>
        _postService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
        var post = _postService.Get(id);

        if (post == null)
            return NotFound();

        return post;
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
        _postService.Add(post);
        return CreatedAtAction(nameof(Get), new { id = post.PostId }, post);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Post post)
    {
        if (id != post.PostId)
            return BadRequest();

        var existingPost = _postService.Get(id);
        if (existingPost is null)
            return NotFound();

        _postService.Update(post);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var post = _postService.Get(id);

        if (post is null)
            return NotFound();

        _postService.Delete(id);

        return NoContent();
    }
}

