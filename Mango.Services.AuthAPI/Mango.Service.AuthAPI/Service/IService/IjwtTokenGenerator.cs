﻿using System;
using Mango.Services.AuthAPI.Models;
namespace Mango.Services.AuthAPI.Service.IService
{
	public interface IjwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser);
	}
}

