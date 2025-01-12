using System;
namespace Mango.Services.AuthAPI.Models.Dto
{
	public class LoginResponseDTO
	{
        public UserDto User { set; get; }
        public string Token { get; set; }
         
    }
}

