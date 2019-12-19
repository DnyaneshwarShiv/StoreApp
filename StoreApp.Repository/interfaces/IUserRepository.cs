using StoreApp.Domain.ClientDB;

namespace StoreApp.Repository.interfaces
{
    public interface IUserRepository
    {
        Users Authenticate(string userName, string password);
    
    }
}
