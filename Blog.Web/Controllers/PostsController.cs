using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Services;
using Blog.Web.Models;
using Blog.DTOs;
namespace Blog.Web.Controllers;

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
    public ActionResult<List<PostDto>> GetAll() =>
        _postService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<PostDto> Get(int id)
    {
        var post = _postService.Get(id);

        if (post == null)
            return NotFound();

        return post;
    }

    [HttpPost]
    public IActionResult Create(PostDto post)
    {
        _postService.Add(post);
        return CreatedAtAction(nameof(Get), new { id = post.PostId }, post);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PostDto post)
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

