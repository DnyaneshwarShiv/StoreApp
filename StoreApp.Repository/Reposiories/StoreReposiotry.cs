using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.CustomEntities;
using StoreApp.Repository.interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using StoreApp.Repository.CustomEntities;

namespace StoreApp.Repository.Reposiories
{
    public class StoreReposiotry : IStoreRepository
    {
        private readonly ExtraEdgeStoreDBContext _extraEdgeStoreDBContext;
        public StoreReposiotry(ExtraEdgeStoreDBContext extraEdgeStoreDBContext)
        {
            _extraEdgeStoreDBContext = extraEdgeStoreDBContext;
        }
        public dynamic GetFilteredOrdersBasedOnExclusion(CustomEntity customEntity)
        {
            throw new NotImplementedException();
        }

        public dynamic GetFilteredOrdersBasedOnMobile(Mobile mobileDto)
        {

            var mobileOrders = (from order in _extraEdgeStoreDBContext.UserMobileOrder
                                join 
                                mobile in _extraEdgeStoreDBContext.Mobile
                                    on order.MobileId equals mobile.Id
                                join userOrder in _extraEdgeStoreDBContext.UserOrder
                                    on order.UserOrderId equals userOrder.Id
                                select order);
                                
           dynamic response=mobileOrders.BuildPredicate<Mobile>();
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnPaymentMode(PaymentModeMaster mobileDto)
        {
            throw new NotImplementedException();
        }

        public dynamic GetFilteredOrdersBasedOnUser(Users mobileDto)
        {
            throw new NotImplementedException();
        }

        public dynamic GetFilteredOrdersBasedOnUserorder(UserOrder mobileDto)
        {
            throw new NotImplementedException();
        }
     
    }
}
