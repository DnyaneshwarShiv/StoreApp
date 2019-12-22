using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StoreApp.Business.Interfaces;
using StoreApp.DTO.models;
using StoreApp.Repository.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMemoryCache _memoryCache;
        public StoreController(IStoreService storeService,IMemoryCache memoryCache)
        {
            _storeService = storeService;
            _memoryCache = memoryCache;
        }
        
        [EnableQuery(PageSize =10)]
        [HttpGet]
        [ODataRoute("GetReports(type={type})")]
        public  IActionResult GetAllFilteredOrders([FromODataUri]string type)
        {
            try
            {
                var clientId = _memoryCache.Get("ClientId");

                if (clientId != null)
                {
                    var result = GetFilteredData(type, (long)clientId);
                    return Ok( result);
                }
                return Unauthorized();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #region private method
        private dynamic GetFilteredData(string type,long clientId)
        {
            IQueryable<CustomEntity> response = null;
            switch (type)
            {
                case "Mobile":
                   
                    response = _storeService.GetFilteredOrdersBasedOnMobile(clientId);
                    break;
                case "User":
                    response=_storeService.GetFilteredOrdersBasedOnUser(clientId);
                    break;
                case "Userorder":
                    response = _storeService.GetFilteredOrdersBasedOnUserorder(clientId);
                    break;
                case "PaymentMode":
                    response = _storeService.GetFilteredOrdersBasedOnPaymentMode(clientId);
                    break;
                case "exclusion":

                    break;
                default:
                    return null;

            }
            return response;
        }
        #endregion
    }
}