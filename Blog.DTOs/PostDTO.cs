using System.ComponentModel.DataAnnotations;

namespace Blog.DTOs
{
    public class PostDto
    {
        [Key]
        public int PostId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? Img { get; set; }
    }
}

