using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Interfaces;
using StoreApp.DTO.models;

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Authenticate(string userName,string password)
        {
           UsersDto userDto= _userService.Authenticate(userName, password);
            return Ok(userDto.Token);
        }
    }
}