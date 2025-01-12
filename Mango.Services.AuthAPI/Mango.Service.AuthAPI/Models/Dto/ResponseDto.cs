using System;
namespace Mango.Services.AuthAPI.Models
{
	public class ResponseDto
	{
		 public object? Result { set; get; }
		public bool IsSuccess { set; get; } = true;
		public string Message { get; set; } = "";
	}
}

