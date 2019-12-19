using StoreApp.DTO.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Interfaces
{
   public interface IStoreService
    {
        dynamic GetFilteredOrdersBasedOnMobile(MobileDto mobileDto);
        dynamic GetFilteredOrdersBasedOnUser(UsersDto mobileDto);
        dynamic GetFilteredOrdersBasedOnUserorder(UserOrdersDto mobileDto);
        dynamic GetFilteredOrdersBasedOnPaymentMode(PaymentModeMasterDto mobileDto);
        dynamic GetFilteredOrdersBasedOnExclusion(CustomDto mobileDto);
    }
}
