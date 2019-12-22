using AutoMapper;
using StoreApp.Business.Interfaces;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.DTO.models;
using StoreApp.Repository.CustomEntities;
using StoreApp.Repository.interfaces;
using System;
using System.Linq;

namespace StoreApp.Business.services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        private readonly IMapper _mapper;
        public StoreService(IStoreRepository storeRepository,IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;

        }
        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnExclusion(long clientId)
        {
            IQueryable<CustomEntity> response = _storeRepository.GetFilteredOrdersBasedOnExclusion(clientId);
            return response;
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnMobile(long clientId)
        {
           IQueryable<CustomEntity> response = _storeRepository.GetFilteredOrdersBasedOnMobile( clientId);

            return response;
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnPaymentMode(long clientId)
        {
            IQueryable<CustomEntity> response = _storeRepository.GetFilteredOrdersBasedOnPaymentMode(clientId);
            return response;
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnUser(long clientId)
        {
            IQueryable<CustomEntity> response = _storeRepository.GetFilteredOrdersBasedOnUser(clientId);
            return response;
        }

        public IQueryable<CustomEntity> GetFilteredOrdersBasedOnUserorder(long clientId)
        {
            IQueryable<CustomEntity> response = _storeRepository.GetFilteredOrdersBasedOnUserorder(clientId);
            return response;
        }
    }
}
