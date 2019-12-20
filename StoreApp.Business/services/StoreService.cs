using AutoMapper;
using StoreApp.Business.Interfaces;
using StoreApp.Domain.ClientDB;
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

        public dynamic GetFilteredOrdersBasedOnPaymentMode(PaymentModeMasterDto paymentDto)
        {
            PaymentModeMaster paymentModeMaster = _mapper.Map<PaymentModeMaster>(paymentDto);
            dynamic response = _storeRepository.GetFilteredOrdersBasedOnPaymentMode(paymentModeMaster);
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnUser(UsersDto usersDto)
        {
            Users users = _mapper.Map<Users>(usersDto);
            dynamic response = _storeRepository.GetFilteredOrdersBasedOnUser(users);
            return response;
        }

        public dynamic GetFilteredOrdersBasedOnUserorder(UserOrdersDto userOrdersDto)
        {
            UserOrder userOrders = _mapper.Map<UserOrder>(userOrdersDto);
            dynamic response = _storeRepository.GetFilteredOrdersBasedOnUserorder(userOrders);
            return response;
        }
    }
}
