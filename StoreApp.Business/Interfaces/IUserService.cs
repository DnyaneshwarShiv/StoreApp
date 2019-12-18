using StoreApp.DTO.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Interfaces
{
    public interface IUserService
    {
        UsersDto Authenticate(string userName, string password);
    }
}
