﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models;

public class Post
{
	[Key]
	public int PostId { get; set; }

	[Required]
	[MaxLength(100)]

	public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100000)]

        public string Content { get; set; } = string.Empty;

	[Required]
	[MaxLength(100000)]
	public string Img { get; set; } = string.Empty;

	public Post()
	{
	}
}

