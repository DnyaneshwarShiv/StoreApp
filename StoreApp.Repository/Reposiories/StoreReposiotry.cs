using Microsoft.Extensions.Caching.Memory;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.CustomEntities;
using StoreApp.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace StoreApp.Repository.Reposiories
{
    public class StoreReposiotry : IStoreRepository
    {
        private readonly ExtraEdgeStoreDBContext _extraEdgeStoreDBContext;
        private readonly ClientDBContext _clientDBContext;
        public StoreReposiotry(ExtraEdgeStoreDBContext extraEdgeStoreDBContext,ClientDBContext clientDBContext)
        {
            _extraEdgeStoreDBContext = extraEdgeStoreDBContext;
            _clientDBContext = clientDBContext;
        }
        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnExclusion(long clientId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnMobile(long clientId)
        {
            
                var dbContext = GetDBContextBasedOnClientId(Convert.ToInt64(clientId));
                var mobileOrders = (from order in _extraEdgeStoreDBContext.UserMobileOrder
                                    join
                                    mobile in _extraEdgeStoreDBContext.Mobile
                                        on order.MobileId equals mobile.Id
                                    join userOrder in _extraEdgeStoreDBContext.UserOrder
                                        on order.UserOrderId equals userOrder.Id
                                    
                                    select new CustomEntity { UserMobileOrder = order, Mobile = mobile, UserOrder = userOrder });

                //dynamic response = mobileOrders.Where("mobile.Brand ==@0 and mobile.Price ==@1", mobileData.Brand, mobileData.Price);
               // dynamic response = mobileOrders.ToList();
                return mobileOrders;
        }

        
        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnPaymentMode(long clientId)
        {
            var paymentBasedOrder = (from order in _extraEdgeStoreDBContext.UserMobileOrder
                                join
                                payment in _extraEdgeStoreDBContext.PaymentModeMaster
                                    on order.PaymentId equals payment.Id
                                join userOrder in _extraEdgeStoreDBContext.UserOrder
                                    on order.UserOrderId equals userOrder.Id
                                select new CustomEntity { PaymentModeMaster=payment, UserMobileOrder = order, UserOrder = userOrder });

            
                //= paymentBasedOrder.BuildPredicate<PaymentModeMaster>(paymentMode);
            return paymentBasedOrder;
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnUser(long clientId)
        {
            var userOrderList = _extraEdgeStoreDBContext.UserOrder;
            var users = _clientDBContext.Users.Where(w=>w.ClientId==clientId).ToList();
            var userOrders = (from userOrder in userOrderList
                                join  user in  users
                                    on userOrder.UserId equals user.Id
                                     select new CustomEntity {  Users = user, UserOrder = userOrder });

            
                //= userOrders.BuildPredicate<Users>(users);
            return userOrders;
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnUserorder(long clientId)
        {
            var userOrders = (from order in _extraEdgeStoreDBContext.UserOrder select new CustomEntity{UserOrder=order });
            return userOrders;
        }


        #region private method
        private ExtraEdgeStoreDBContext GetDBContextBasedOnClientId(long clientId)
        {
            var client = _clientDBContext.Client.Where(w => w.Id == clientId).FirstOrDefault();
            Dictionary<string, string> connectionStrings = new Dictionary<string, string>();

            connectionStrings.Add(client.StoreDbname, client.StoreConnectionString);
            DbContextFactory<ExtraEdgeStoreDBContext>.SetConnectionString(connectionStrings);
            return new ExtraEdgeStoreDBContext(DbContextFactory<ExtraEdgeStoreDBContext>.Create(client.StoreDbname).Options);

        }

        #endregion
    }
}
