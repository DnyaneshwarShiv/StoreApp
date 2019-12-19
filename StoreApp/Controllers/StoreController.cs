using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreApp.DTO.models;
using System.Collections.Generic;

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public StoreController()
        {

        }

        [HttpGet]
        public async IEnumerable<UserMobileOrderDto> GetAllFilteredOrders(string type,string filterJson)
        {
            var result=GetFilteredData(type,filterJson);
            return result;
        }
       private IEnumerable<UserMobileOrderDto> GetFilteredData(string type,string filterJson)
        {
            switch (type)
            {
                case "Mobile":
                   MobileDto mobile = JsonConvert.DeserializeObject<MobileDto>(filterJson);
                    break;
                case "User":
                    UsersDto users = JsonConvert.DeserializeObject<UsersDto>(filterJson);
                    break;
                case "Userorder":
                    UserOrdersDto userOrders = JsonConvert.DeserializeObject<UserOrdersDto>(filterJson);
                    break;
                case "PaymentMode":
                    PaymentModeMasterDto paymentModeMasterDto = JsonConvert.DeserializeObject<PaymentModeMasterDto>(filterJson);
                    break;
                 case "exclusion":

                    break;
                default:
                    return null;
                    
            }
            return null;
        }

    }
}