using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreApp.Business.services;
using StoreApp.Controllers;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.Reposiories;
using System;
using System.Text.Encodings.Web;

namespace APS.UnitTest.Controller
{
    [TestClass]
    public class StoreClientControllerUnitTest
    {
        private readonly StoreController storeController;
        private readonly Mock<StoreService> storeService;
        private readonly Mock<StoreReposiotry> storeRepository;
        private readonly HtmlEncoder encode;
        private readonly IMemoryCache memoryCache;
        private readonly DbContextOptions<ExtraEdgeStoreDBContext> dbContextOptions;
        private readonly ExtraEdgeStoreDBContext extraEdgeDB;
        private readonly ClientDBContext clientDB;
        private readonly DbContextOptions<ClientDBContext> clientDBContextOption;
        public StoreClientControllerUnitTest()
        {
            // logger = new Mock<ILogger<StoreClientControllerUnitTest>>().Object;
            dbContextOptions = new DbContextOptionsBuilder<ExtraEdgeStoreDBContext>()
            .UseInMemoryDatabase(databaseName: "ExtraEdgeStorOption")
            .Options;
            clientDBContextOption = new DbContextOptionsBuilder<ClientDBContext>()
           .UseInMemoryDatabase(databaseName: "ClientDB")
           .Options;
            extraEdgeDB = new ExtraEdgeStoreDBContext(dbContextOptions);
            clientDB = new ClientDBContext(clientDBContextOption);

            extraEdgeDB.UserMobileOrder.Add(new UserMobileOrder()
            {
              Id=1,
              CreatedBy="Dnyaneshwar",
              CreatedOn=DateTime.UtcNow,
              IsActive=true,
              MobileId=1,
              OrderDate= DateTime.Parse("2019-05-12 00:00:00.000"),
              PaymentId=1,
              UserOrderId=1
            });
            clientDB.Client.Add(new Client()
            {
                Id = 1,
                CreatedBy = "Dnyaneshwar",
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                StoreConnectionString = "Server=DESKTOP-9411J58\\SQLEXPRESS;Database=ExtraEdgeStoreDB;Trusted_Connection=True;",
                StoreDbname = "ExtraEdge"
            });
            clientDB.Users.Add(new Users()
            {
                Id = 1,
                CreatedBy = "Dnyaneshwar",
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                Age = 27,
                City = "Pune",
                ClientId = 1,
                Email = "dnyaneshwar.Shivbhakta@silicus.com",
                Gender = "Male",
                Mobile = "8793113432",
                Name = "Dnyaneshwar",
                Password = "VGVzdEAxMjM0",
                Token = string.Empty
            });
            extraEdgeDB.Mobile.Add(new Mobile()
            {
                Id = 1,
                CreatedBy = "Dnyaneshwar",
                Brand = "Samsung",
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                Model = "M30s",
                Price = 16000,
                Year = 2019
            });
            extraEdgeDB.PaymentModeMaster.Add(new PaymentModeMaster()
            {
                Id = 1,
                CreatedBy = "Dnyaneshwar",
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                PaymentType = "NetBanking"
            });
            extraEdgeDB.Promotion.Add(new Promotion()
            {
                DiscountPercentage = 50,
                PromoCodeName = "BOGO",
                PromoCodeType = "MONSOON",
                Id = 1,
                CreatedBy = "Dnyaneshwar",
                CreatedOn = DateTime.Parse("2019-05-12 00:00:00.000")
            });
            extraEdgeDB.UserOrder.Add(new UserOrder()
            {
                OrderDate = DateTime.Parse("2019-05-12 00:00:00.000"),
                IsActive = true,
                OrderName = "Mobile Purchase",
                UserId = 1,
                Id = 1,
                CreatedBy = "Dnyaneshwar",
                CreatedOn = DateTime.Parse("2019-05-12 00:00:00.000")
            });
            extraEdgeDB.SaveChanges();
            storeService = new Mock<StoreService>();
            encode = new Mock<HtmlEncoder>().Object;
            storeRepository = new Mock<StoreReposiotry>(extraEdgeDB,clientDB);
            memoryCache = Mock.Of<IMemoryCache>();
            storeController = new StoreController(, memoryCache);
        }
      
        #region Test Constructor
        [TestMethod]
        public void Test_ApsClientController()
        {
            StoreController tstController= new StoreController( memoryCache);
            Assert.IsNotNull(tstController);
        }
        [TestMethod]
        public void Test_FilteredData()
        {
            string type = "Mobile";
            memoryCache.Set("ClientId", 1);
            var response =  storeController.GetAllFilteredOrders(type) as OkObjectResult ;
            Assert.AreEqual(200, response.StatusCode );

        }
       
        #endregion
    }
    public static class Cache
    {
        public static TItem Set<TItem>(this IMemoryCache cache, object key, TItem value, MemoryCacheEntryOptions options)
        {
            using (var entry = cache.CreateEntry(key))
            {
                if (options != null)
                {
                    entry.SetOptions(options);
                }

                entry.Value = value;
            }

            return value;
        }
    }
  
}
