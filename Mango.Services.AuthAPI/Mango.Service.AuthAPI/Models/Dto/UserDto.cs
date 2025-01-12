using System;
namespace Mango.Services.AuthAPI.Models.Dto
{
	public class UserDto
	{
		public string ID { set; get; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { set; get; }
	}
}

