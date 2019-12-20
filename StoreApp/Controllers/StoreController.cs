using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreApp.Business.Interfaces;
using StoreApp.DTO.models;
using System.Collections.Generic;

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public  dynamic GetAllFilteredOrders(string type,string filterJson)
        {
            var result= GetFilteredData(type,filterJson);
            return result;
        }
       private dynamic GetFilteredData(string type,string filterJson)
        {
            dynamic response=null;
            switch (type)
            {
                case "Mobile":
                   MobileDto mobile = JsonConvert.DeserializeObject<MobileDto>(filterJson);
                   response= _storeService.GetFilteredOrdersBasedOnMobile(mobile);
                    break;
                case "User":
                    UsersDto users = JsonConvert.DeserializeObject<UsersDto>(filterJson);
                    _storeService.GetFilteredOrdersBasedOnUser(users);
                    break;
                case "Userorder":
                    UserOrdersDto userOrders = JsonConvert.DeserializeObject<UserOrdersDto>(filterJson);
                    response=_storeService.GetFilteredOrdersBasedOnUserorder(userOrders);
                    break;
                case "PaymentMode":
                    PaymentModeMasterDto paymentModeMasterDto = JsonConvert.DeserializeObject<PaymentModeMasterDto>(filterJson);
                   response= _storeService.GetFilteredOrdersBasedOnPaymentMode(paymentModeMasterDto);
                    break;
                 case "exclusion":

                    break;
                default:
                    return null;
                    
            }
            return response;
        }

    }
}