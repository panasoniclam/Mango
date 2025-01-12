﻿using System;
namespace Mango.Services.CouponAPI.Models.Dto
{
	public class ResponseDto
	{
		 public object? Result { set; get; }
		public bool IsSuccess { set; get; } = true;
		public string Message { get; set; } = "";
	}
}

