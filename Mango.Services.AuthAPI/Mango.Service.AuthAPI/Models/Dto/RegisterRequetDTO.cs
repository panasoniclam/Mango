using System;
namespace Mango.Services.AuthAPI.Models.Dto
{
	public class RegisterRequetDTO
	{
        public string ID { set; get; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { set; get; }
    }
}

