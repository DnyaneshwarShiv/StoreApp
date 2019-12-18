using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using StoreApp.Business.Interfaces;
using StoreApp.DTO;
using StoreApp.DTO.models;
using StoreApp.Repository.interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreApp.Business.services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UsersDto Authenticate(string userName, string password)
        {
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            password = Convert.ToBase64String(passwordBytes);
            var user = _userRepository.Authenticate(userName,password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constant.secrete);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;
            UsersDto userDto = _mapper.Map<UsersDto>(user);
            return userDto;
        }
      
    }
}
