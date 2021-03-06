﻿using DogeNews.Common.Enums;
using NUnit.Framework;

using DogeNews.Web.Mvp.News.Add.EventArguments;

namespace DogeNews.Web.Mvp.Tests.EventArgsTests.News
{
    [TestFixture]
    public class AddNewsEventArgsTests
    {
        [Test]
        public void TitleShouldReturnTheSetValue()
        {
            AddNewsEventArgs eventArgs = new AddNewsEventArgs();
            string title = "title";

            eventArgs.Title = title;
            Assert.AreEqual(title, eventArgs.Title);
        }

        [Test]
        public void FileNameShouldReturnTheSetValue()
        {
            AddNewsEventArgs eventArgs = new AddNewsEventArgs();
            string fileName = "fileName";

            eventArgs.FileName = fileName;
            Assert.AreEqual(fileName, eventArgs.FileName);
        }

        [Test]
        public void ContentShouldReturnTheSetValue()
        {
            AddNewsEventArgs eventArgs = new AddNewsEventArgs();
            string content = "content";

            eventArgs.Content = content;
            Assert.AreEqual(content, eventArgs.Content);
        }

        [Test]
        public void NewscategoryShouldReturnTheSetValue()
        {
            AddNewsEventArgs eventArgs = new AddNewsEventArgs();
            NewsCategoryType category = NewsCategoryType.Breaking;

            eventArgs.Category = category;
            Assert.AreEqual(category, eventArgs.Category);
        }
    }
}
