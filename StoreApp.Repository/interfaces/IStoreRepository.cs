using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.Repository.interfaces
{
    public interface IStoreRepository
    {
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnMobile(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnUser(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnUserorder(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnPaymentMode(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnExclusion(long clientId);
    }
}
