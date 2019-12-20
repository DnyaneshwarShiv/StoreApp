using Microsoft.Extensions.DependencyInjection;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.CustomEntities;
using StoreApp.Repository.interfaces;
using StoreApp.Repository.Reposiories;
using System.Collections.Generic;

namespace StoreApp.DTO
{
    public class DependencyResolver
    {
        protected DependencyResolver()
        {

        }
        public static void RegisterDependency(IServiceCollection services)
        {
            services.AddDbContext<ExtraEdgeStoreDBContext>();
            services.AddDbContext<ClientDBContext>();
            Dictionary<string, string> connStrs = new Dictionary<string, string>();
            connStrs.Add("DB1", Constant.ClientDbConn);
            connStrs.Add("DB2", Constant.ExtraEdgeDbConn);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStoreRepository, StoreReposiotry>();
        }
    }
}
