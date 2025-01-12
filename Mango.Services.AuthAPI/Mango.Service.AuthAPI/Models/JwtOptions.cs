using System;
namespace Mango.Services.AuthAPI.Models
{
	public class JwtOptions
	{
		public string Issuer { set; get; } = String.Empty;
		public string Audience { set; get; } = String.Empty;
		public string Secret { set; get; } = String.Empty;
	}
}

