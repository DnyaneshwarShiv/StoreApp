using StoreApp.DTO.models;
using StoreApp.Repository.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.Business.Interfaces
{
   public interface IStoreService
    {
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnMobile(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnUser(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnUserorder(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnPaymentMode(long clientId);
        IQueryable<CustomEntity> GetFilteredOrdersBasedOnExclusion(long clientId);
    }
}
