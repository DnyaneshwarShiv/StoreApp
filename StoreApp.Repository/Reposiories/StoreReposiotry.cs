using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.CustomEntities;
using StoreApp.Repository.interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using StoreApp.Repository.CustomEntities;
using Microsoft.Extensions.Caching.Memory;

namespace StoreApp.Repository.Reposiories
{
    public class StoreReposiotry : IStoreRepository
    {
        private readonly ExtraEdgeStoreDBContext _extraEdgeStoreDBContext;
        private readonly ClientDBContext _clientDBContext;
        private readonly IMemoryCache _memoryCache;
        public StoreReposiotry(ExtraEdgeStoreDBContext extraEdgeStoreDBContext,ClientDBContext clientDBContext,IMemoryCache memoryCache)
        {
            _extraEdgeStoreDBContext = extraEdgeStoreDBContext;
            _clientDBContext = clientDBContext;
            _memoryCache = memoryCache;
        }
        public dynamic GetFilteredOrdersBasedOnExclusion(CustomEntity customEntity)
        {
            throw new NotImplementedException();
        }

        public dynamic GetFilteredOrdersBasedOnMobile(Mobile mobileDto)
        {
            var clientId = _memoryCache.Get("ClientId");
            if (clientId != null)
            {
                var dbContext = GetDBContextBasedOnClientId((long)clientId);
                var mobileOrders = (from order in _extraEdgeStoreDBContext.UserMobileOrder
                                    join
                                    mobile in _extraEdgeStoreDBContext.Mobile
                                        on order.MobileId equals mobile.Id
                                    join userOrder in _extraEdgeStoreDBContext.UserOrder
                                        on order.UserOrderId equals userOrder.Id
                                    select order);

                dynamic response = mobileOrders.BuildPredicate<Mobile>(mobileDto);
                return response;
            }
            return null;
        }

        private string GetDBContextBasedOnClientId(long clientId)
        {
           return _clientDBContext.Client.Where(w => w.Id == clientId).FirstOrDefault().StoreDbname;
        }

        public dynamic GetFilteredOrdersBasedOnPaymentMode(PaymentModeMaster paymentMode)
        {
            var paymentBasedOrder = (from order in _extraEdgeStoreDBContext.UserMobileOrder
                                join
                                payment in _extraEdgeStoreDBContext.PaymentModeMaster
                                    on order.PaymentId equals payment.Id
                                join userOrder in _extraEdgeStoreDBContext.UserOrder
                                    on order.UserOrderId equals userOrder.Id
                                select order);

            dynamic response = paymentBasedOrder.BuildPredicate<PaymentModeMaster>(paymentMode);
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnUser(Users users)
        {
            var paymentBasedOrder = (from order in _extraEdgeStoreDBContext.UserMobileOrder
                                     join
                                     payment in _extraEdgeStoreDBContext.PaymentModeMaster
                                         on order.PaymentId equals payment.Id
                                     join userOrder in _extraEdgeStoreDBContext.UserOrder
                                         on order.UserOrderId equals userOrder.Id
                                     select order);

            dynamic response = paymentBasedOrder.BuildPredicate<PaymentModeMaster>(paymentMode);
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnUserorder(UserOrder userOrder)
        {
            throw new NotImplementedException();
        }
     
    }
}
