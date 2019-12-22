
using Microsoft.Extensions.Caching.Memory;
using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;
using StoreApp.Repository.interfaces;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace StoreApp.Repository.Reposiories
{
    public class UserRepository:IUserRepository
    {
        private readonly ExtraEdgeStoreDBContext _extraEdgeStoreDBContext;
        private readonly ClientDBContext _clientDBContext;
        private readonly IMemoryCache _memoryCache;
        public UserRepository(ExtraEdgeStoreDBContext extraEdgeStoreDBContext, ClientDBContext clientDB,
            IMemoryCache memoryCache)
        {
            _extraEdgeStoreDBContext = extraEdgeStoreDBContext;
            _clientDBContext = clientDB;
            _memoryCache = memoryCache;
        }
        public Users Authenticate(string userName,string password)
        {
            Users user = null;
            if (_clientDBContext.Users.Any("w => w.Name.Equals(@0, StringComparison.CurrentCultureIgnoreCase)" +
                        "and w.Password.Equals(@1,StringComparison.CurrentCultureIgnoreCase) ", userName, password)) 
            {
                user=(from client in _clientDBContext.Client
                join users in _clientDBContext.Users on client.Id equals users.Id
                select users).FirstOrDefault();
            }
            if(user!=null)
            _memoryCache.Set("ClientId", user.ClientId);
            return user;
        }
    }
}
