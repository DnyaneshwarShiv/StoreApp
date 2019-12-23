using AutoMapper;
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
using StoreApp.DTO;
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
        private readonly IMapper mapperMock;
        private readonly StoreReposiotry storeRepository;
        private readonly HtmlEncoder encode;
        private readonly DbContextOptions<ExtraEdgeStoreDBContext> dbContextOptions;
        private readonly ExtraEdgeStoreDBContext extraEdgeDB;
        private readonly ClientDBContext clientDB;
        private readonly DbContextOptions<ClientDBContext> clientDBContextOption;
        private readonly IMemoryCache cache;
        public StoreClientControllerUnitTest()
        {
            cache = new MemoryCache(new MemoryCacheOptions());
            dbContextOptions = new DbOptionsExtraEdgeDgeFactory("ExtraEdge").ExtraEdgeStoreDBContextOption;
            extraEdgeDB = new ExtraEdgeStoreDBContext(dbContextOptions);
            clientDBContextOption = new DbOptionsExtraEdgeDgeFactory("ClientDB").ClientDBContextOption;
            clientDB = new ClientDBContext(clientDBContextOption);
            encode = new Mock<HtmlEncoder>().Object;
            mapperMock = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            }).CreateMapper();
            storeRepository = new StoreReposiotry(extraEdgeDB,clientDB);
            storeService = new Mock<StoreService>(storeRepository,mapperMock);
            storeController = new StoreController(storeService.Object, cache);
        }
      
        #region Test Constructor
        [TestMethod]
        public void Test_ApsClientController()
        {
            StoreController tstController= new StoreController(storeService.Object, cache);
            Assert.IsNotNull(tstController);
        }
        [TestMethod]
        public void Test_FilteredData()
        {
            string type = "Mobile";
            using (var entry = cache.CreateEntry("ClientId"))
            {
                entry.Value = Convert.ToInt64(1);
                entry.AbsoluteExpiration = DateTime.UtcNow.AddDays(1);
            }
            var response =  storeController.GetAllFilteredOrders(type) as OkObjectResult ;
            Assert.AreEqual(200, response.StatusCode );

        }
        [TestMethod]
        public void Test_UnAuthorizedFilteredData()
        {
            string type = "Mobile";
            using (var entry = cache.CreateEntry("ClientId"))
            {
                entry.Value = null;
                entry.AbsoluteExpiration = DateTime.UtcNow.AddDays(1);
            }
            var response = storeController.GetAllFilteredOrders(type) as UnauthorizedResult;
            Assert.AreEqual(401, response.StatusCode);

        }
        #endregion
    }
    public static class MemoryCacheService
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
        public static bool TryGetValue<TItem>(this IMemoryCache cache, object key, out TItem value)
        {
            object result;
            if (cache.TryGetValue(key, out result))
            {
                value = (TItem)result;
                return true;
            }

            value = default(TItem);
            return false;
        }
        public static IMemoryCache GetMemoryCache(object expectedValue)
        {
            var mockMemoryCache = new Mock<IMemoryCache>();
            mockMemoryCache
                .Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue))
                .Returns(true);
            return mockMemoryCache.Object;
        }
    }
  
}
