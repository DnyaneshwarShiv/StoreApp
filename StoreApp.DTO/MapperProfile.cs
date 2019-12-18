﻿using AutoMapper;
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
        }
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<LoginModel, LoginEntity>().IgnoreAllNonExisting();
                

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
