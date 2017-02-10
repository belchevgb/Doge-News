﻿using System;
using System.Collections.Generic;
using System.Linq;

using DogeNews.Common.Enums;
using DogeNews.Web.Models;
using DogeNews.Web.Services.Contracts;
using DogeNews.Data.Models;
using DogeNews.Data.Contracts;
using DogeNews.Web.Providers.Contracts;
using DogeNews.Common.Validators;

namespace DogeNews.Web.Services
{
    public class NewsService : INewsService
    {
        private const int SliderNewsCount = 3;

        private readonly IRepository<User> userRepository;
        private readonly IRepository<NewsItem> newsRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly INewsData newsData;
        private readonly IMapperProvider mapperProvider;
        private readonly IDateTimeProvider dateTimeProvider;

        public NewsService(
            IRepository<User> userRepository,
            IRepository<NewsItem> newsRepository,
            INewsData newsData,
            IMapperProvider mapperProvider,
            IRepository<Image> imageRepository,
            IDateTimeProvider dateTimeProvider)
        {
            Validator.ValidateThatObjectIsNotNull(userRepository, nameof(userRepository));
            Validator.ValidateThatObjectIsNotNull(newsRepository, nameof(newsRepository));
            Validator.ValidateThatObjectIsNotNull(newsData, nameof(newsData));
            Validator.ValidateThatObjectIsNotNull(mapperProvider, nameof(mapperProvider));
            Validator.ValidateThatObjectIsNotNull(imageRepository, nameof(imageRepository));
            Validator.ValidateThatObjectIsNotNull(dateTimeProvider, nameof(dateTimeProvider));

            this.userRepository = userRepository;
            this.newsRepository = newsRepository;
            this.imageRepository = imageRepository;
            this.newsData = newsData;
            this.mapperProvider = mapperProvider;
            this.dateTimeProvider = dateTimeProvider;
        }

        public NewsWebModel GetItemByTitle(string title)
        {
            var foundNewsItem = this.newsRepository.GetFirst(x => x.Title == title);
            var newsWebModel = this.mapperProvider.Instance.Map<NewsWebModel>(foundNewsItem);

            return newsWebModel;
        }

        public NewsWebModel GetItemById(string id)
        {
            int parsedId = int.Parse(id);
            var foundNewsItem = this.newsRepository.GetFirst(x => x.Id == parsedId);
            var newsWebModel = this.mapperProvider.Instance.Map<NewsWebModel>(foundNewsItem);

            return newsWebModel;
        }

        public IEnumerable<NewsWebModel> GetSliderNews()
        {
            var news = this.newsRepository
                .All
                .OrderByDescending(x => x.CreatedOn)
                .Take(SliderNewsCount)
                .ToList()
                .Select(x => this.mapperProvider.Instance.Map<NewsWebModel>(x));

            return news;
        }

        public IEnumerable<NewsWebModel> GetNewsItemsByCategory(string category)
        {
            var enumeration = (NewsCategoryType)Enum.Parse(typeof(NewsCategoryType), category);
            var news = this.newsRepository
                .GetAll(x => x.Category == enumeration)
                .Select(x => this.mapperProvider.Instance.Map<NewsWebModel>(x))
                .ToList();

            return news;
        }
    }
}
