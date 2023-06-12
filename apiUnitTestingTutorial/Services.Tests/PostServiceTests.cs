using Xunit;
using NSubstitute;
using apiTutorial.Interfaces;
using FluentAssertions;
using apiTutorial.Models;
using apiTutorial.Services;
using System.Collections.Generic;
using System.Linq;

namespace apiTutorial.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public void GetAll_ShouldReturnAllPosts()
        {
            // Arrange
            var expectedPosts = new List<Post>
            {
                 new Post
            {
                    PostId = 1,
                    Title = "Post 1",
                    Content = "Lorem Lorem",
                    Img = "img adress"
            },
            new Post
            {

                    PostId = 2,
                    Title = "Post 2",
                    Content = "Lorem Lorem",
                    Img = "img adress"
            }

            };
            var postService = Substitute.For<IPostService>();
            postService.GetAll().Returns(expectedPosts);

            // Act
            var result = postService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(expectedPosts);
        }

        [Fact]
        public void Get_WithExistingId_ShouldReturnPost()
        {
            // Arrange
            var postId = 3;
            var expectedPost = new Post
            {

                PostId = postId,
                Title = "Post 3",
                Content = "Lorem Lorem",
                Img = "img adress"
            };
            var postService = Substitute.For<IPostService>();
            postService.Get(postId).Returns(expectedPost);

            // Act
            var result = postService.Get(postId);

            // Assert
            result.Should().BeEquivalentTo(expectedPost);
        }

        [Fact]
        public void Get_WithNonExistingId_ShouldReturnNull()
        {
            // Arrange
            var postId = 99;
            var postService = Substitute.For<IPostService>();
            postService.Get(postId).Returns((Post)null);
            // Act
            var result = postService.Get(postId);

            // Assert
            result.Should().BeNull();
        }


        [Fact]
        public void Add_ValidPost_PostAddedSuccessfully()
        {
            // Arrange
            var post = new Post
            {
                PostId = 1,
                Title = "New Post 1",
                Content = "Lorem Lorem",
                Img = "img adress"
            };

            var postService = Substitute.For<IPostService>();

            // Act
            postService.Add(post);

            // Assert
            postService.Received(1).Add(post);
        }

        [Fact]
        public void Add_ShouldIncreasePostCount()
        {
            // Arrange
            var postService = new PostService();
            var initialCount = postService.GetAll().Count;
            var newPost = new Post
            {
                PostId = 3,
                Title = "New Post",
                Content = "Lorem Lorem",
                Img = "img adress"
            };

            // Act
            postService.Add(newPost);
            var updatedCount = postService.GetAll().Count;

            // Assert
            updatedCount.Should().Be(initialCount + 1);
        }

        [Fact]
        public void Delete_WithExistingId_ShouldRemovePost()
        {
            // Arrange
            var postId = 100;
            var postService = new PostService();

            // Act
            postService.Delete(postId);
            var deletedPost = postService.Get(postId);

            // Assert
            deletedPost.Should().BeNull();
        }

        [Fact]
        public void Update_WithExistingPost_ShouldModifyPost()
        {
            // Arrange
            var postId = 101;
            var postService = new PostService();
            var updatedPost = new Post
            {
                PostId = postId,
                Title = "Updated Post",
                Content = "Lorem Lorem",
                Img = "img adress"
            };

            // Act
            postService.Update(updatedPost);
            var modifiedPost = postService.Get(postId);

            // Assert
            modifiedPost.Should().BeEquivalentTo(updatedPost);
        }
    }
}
     


