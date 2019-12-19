using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.CustomEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Repository.interfaces
{
    public interface IStoreRepository
    {
        dynamic GetFilteredOrdersBasedOnMobile(Mobile mobileDto);
        dynamic GetFilteredOrdersBasedOnUser(Users mobileDto);
        dynamic GetFilteredOrdersBasedOnUserorder(UserOrder mobileDto);
        dynamic GetFilteredOrdersBasedOnPaymentMode(PaymentModeMaster mobileDto);
        dynamic GetFilteredOrdersBasedOnExclusion(CustomEntity customEntity);
    }
}
