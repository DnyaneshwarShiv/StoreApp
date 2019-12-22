using AutoMapper;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.DTO.models;
using StoreApp.Repository.CustomEntities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StoreApp.DTO
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            
                CreateMap<MobileDto, Mobile>().IgnoreAllNonExisting();
                CreateMap<UserMobileOrder, UserMobileOrderDto>().IgnoreAllNonExisting();
                CreateMap<UserOrder, UserOrdersDto>().IgnoreAllNonExisting();
                CreateMap<PaymentModeMaster, PaymentModeMasterDto>().IgnoreAllNonExisting();
                CreateMap<Promotion, PromotionDto>().IgnoreAllNonExisting();
                CreateMap<Client, ClientDto>().IgnoreAllNonExisting();
                CreateMap<CustomEntity, CustomDto>().IgnoreAllNonExisting();
                CreateMap<Users, UsersDto>().IgnoreAllNonExisting();

           
        }
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MobileDto, Mobile>().IgnoreAllNonExisting();
                cfg.CreateMap<UserMobileOrder, UserMobileOrderDto>().IgnoreAllNonExisting();
                cfg.CreateMap<UserOrder, UserOrdersDto>().IgnoreAllNonExisting();
                cfg.CreateMap<PaymentModeMaster, PaymentModeMasterDto>().IgnoreAllNonExisting();
                cfg.CreateMap<Promotion, PromotionDto>().IgnoreAllNonExisting();
                cfg.CreateMap<Client, ClientDto>().IgnoreAllNonExisting();
                cfg.CreateMap<Users, UsersDto>().IgnoreAllNonExisting();               

            });

            return config;
        }
    }
    public static class MapperProfile
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
                (this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}
