using System;
using AutoMapper;
using Blog.DTOs;
using Blog.Infra.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blog.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}

