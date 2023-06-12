using System;
using apiTutorial.Controllers;
using apiTutorial.Models;
using apiTutorial.Services;
using apiTutorial.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace apiUnitTestingTutorial.Conrollers.Test
{
    public class PostsControllerTests
    {
        private readonly PostsController _controller;
        private readonly IPostService _postService;

        public PostsControllerTests()
        {
            _postService = Substitute.For<IPostService>();
            _controller = new PostsController(_postService);
        }

        [Fact]
        public void GetAll_ReturnsListOfPosts()
        {
            // Arrange
            var expectedPosts = new List<Post>
        {
            new Post
            {
                    PostId = 100,
                    Title = "Default post 100",
                    Content = "Lorem Lorem",
                    Img = "img adress"
            },
            new Post
            {
               
                    PostId = 101,
                    Title = "Default post 101",
                    Content = "Lorem Lorem",
                    Img = "img adress"
            }
         
        };
            _postService.GetAll().Returns(expectedPosts);
            
            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = result.Should().BeAssignableTo<ActionResult<List<Post>>>().Subject;
            var actualPosts = okResult.Value.Should().BeAssignableTo<List<Post>>().Subject;

            actualPosts.Should().BeEquivalentTo(expectedPosts);
        }

        [Fact]
        public void Get_ExistingId_ReturnsPost()
        {
            // Arrange
            int postId = 100;
            var expectedPost = new Post
            {
                PostId = postId,
                Title = "Default post 100",
                Content = "Lorem Lorem",
                Img = "img adress"
            };
            _postService.Get(postId).Returns(expectedPost);

            // Act
            var result = _controller.Get(postId);

            // Assert
            result.Should().BeEquivalentTo(expectedPost);
        }

    }

}

