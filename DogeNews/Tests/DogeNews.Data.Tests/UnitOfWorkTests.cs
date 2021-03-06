﻿using System;
using System.Reflection;

using DogeNews.Data.Contracts;
using DogeNews.Data.Migrations;

using Moq;
using NUnit.Framework;

namespace DogeNews.Data.Tests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NewsData(null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenContextIsCorrect()
        {
            Mock<INewsDbContext> mockContext = new Mock<INewsDbContext>();

            Assert.DoesNotThrow(() => new NewsData(mockContext.Object));
        }

        [Test]
        public void Commit_SouldCall_ContextSaveChanges()
        {
            Mock<INewsDbContext> mockContext = new Mock<INewsDbContext>();
            NewsData newsData = new NewsData(mockContext.Object);

            newsData.Commit();

            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void Dispose_SouldCall_ContextDispose()
        {
            Mock<INewsDbContext> mockContext = new Mock<INewsDbContext>();
            NewsData newsData = new NewsData(mockContext.Object);

            newsData.Dispose();
            mockContext.Verify(x => x.Dispose(), Times.Once);
        }

        [Test, Ignore("Integration tests are not needed for now.")]
        public void Configuration_SeedShouldNotThrow()
        {
            Configuration config = new Configuration();
            NewsDbContext context = new NewsDbContext();
            Assert.DoesNotThrow(() => config
                .GetType()
                .GetMethod("Seed", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(config, new object[] { context }));
        }
    }
}