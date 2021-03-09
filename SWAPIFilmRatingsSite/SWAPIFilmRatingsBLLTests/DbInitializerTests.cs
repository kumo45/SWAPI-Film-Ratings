using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SWAPIFilmRatingsBLL.DLL;
using SWAPIFilmRatingsBLL.Helpers;
using SWAPIFilmRatingsBLLTests.FakeDB;
using System;
using System.Collections.Generic;

namespace SWAPIFilmRatingsBLLTests
{
    public class Tests
    {
        private const string EXCEPTION_MESSAGE_API_UNAVAILABLE = "API was not available to get data.";
        private SWAPIFilmRatingsDbContext _validContext;

        [OneTimeSetUp]
        public void Setup()
        {
            Mock<SWAPIFilmRatingsDbContext> mockContext = new Mock<SWAPIFilmRatingsDbContext>();
            
            mockContext.Setup(mc => mc.Database).Returns(new FakeDatabaseFacade());

            _validContext = mockContext.Object;
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _validContext.Dispose();
        }


        [Test]
        public void DB_IsInitialized_API_NotAvailable()
        {
            Mock<ISWAPICSharpHelper> apiHelperMock = new Mock<ISWAPICSharpHelper>();
            apiHelperMock.Setup(ah => ah.CheckAPIAvilability()).Returns(false);

            DbInitializer dbInitializer = new DbInitializer(apiHelperMock.Object);

            Exception testException = Assert.Throws<Exception>(() => dbInitializer.Initialize(_validContext));
            Assert.AreEqual(EXCEPTION_MESSAGE_API_UNAVAILABLE, testException.Message);
        }
    }
}