using System;
namespace Mango.Services.AuthAPI.Models.Dto
{
	public class LoginRequestDTO
	{
        public string UserName { set; get; }
        public string Password { get; set; }
        
    }
}

