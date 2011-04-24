﻿using System.Web.Mvc;
using AutoMapper;
using RavenDbBlog.Core.Models;
using RavenDbBlog.Infrastructure.AutoMapper.Profiles.Resolvers;
using RavenDbBlog.ViewModels;

namespace RavenDbBlog.Infrastructure.AutoMapper.Profiles
{
    public class PostsAdminViewModelMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Post, PostsAdminViewModel.PostSummary>()
                .ForMember(x => x.Id, o => o.MapFrom(m => RavenIdResolver.Resolve(m.Id)))
                .ForMember(x => x.Slug, o => o.MapFrom(m => SlugConverter.TitleToSlag(m.Title)))
                .ForMember(x => x.PublishedAt, o => o.MapFrom(m => m.PublishAt))
                .ForMember(x => x.Title, o => o.MapFrom(m => MvcHtmlString.Create(m.Title)));
        }
    }
}