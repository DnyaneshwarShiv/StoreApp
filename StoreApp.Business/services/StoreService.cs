using AutoMapper;
using StoreApp.Business.Interfaces;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.DTO.models;
using StoreApp.Repository.CustomEntities;
using StoreApp.Repository.interfaces;
using System;

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
        public dynamic GetFilteredOrdersBasedOnExclusion(CustomDto mobileDto)
        {
            CustomEntity mobile = _mapper.Map<CustomEntity>(mobileDto);
            dynamic response = _storeRepository.GetFilteredOrdersBasedOnExclusion(mobile);
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnMobile(MobileDto mobileDto)
        {
            Mobile mobile = _mapper.Map<Mobile>(mobileDto);
            dynamic response = _storeRepository.GetFilteredOrdersBasedOnMobile(mobile);
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnPaymentMode(PaymentModeMasterDto mobileDto)
        {
            throw new NotImplementedException();
        }

        public dynamic GetFilteredOrdersBasedOnUser(UsersDto mobileDto)
        {
            throw new NotImplementedException();
        }

        public dynamic GetFilteredOrdersBasedOnUserorder(UserOrdersDto mobileDto)
        {
            throw new NotImplementedException();
        }
    }
}
