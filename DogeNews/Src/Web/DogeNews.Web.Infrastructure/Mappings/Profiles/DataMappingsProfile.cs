﻿using AutoMapper;

using DogeNews.Data.Models;
using DogeNews.Web.Models;

namespace DogeNews.Web.Infrastructure.Mappings.Profiles
{
    public class DataMappingsProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<User, UserWebModel>();
            this.CreateMap<UserWebModel, User>();

            this.CreateMap<NewsItem, NewsWebModel>();
            this.CreateMap<NewsWebModel, NewsItem>();

            this.CreateMap<Image, ImageWebModel>();
            this.CreateMap<ImageWebModel, Image>();

            this.CreateMap<Comment, CommentWebModel>();
            this.CreateMap<CommentWebModel, Comment>();

            this.CreateMap<AdminActionLog, AdminActionLogWebModel>();
            this.CreateMap<AdminActionLogWebModel, AdminActionLog>();
        }
    }
}
