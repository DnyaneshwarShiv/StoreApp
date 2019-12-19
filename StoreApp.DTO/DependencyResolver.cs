using Microsoft.Extensions.DependencyInjection;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.interfaces;
using StoreApp.Repository.Reposiories;

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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStoreRepository, StoreReposiotry>();
        }
    }
}
