using System;
using Mango.Services.AuthAPI.Models.Dto;
namespace Mango.Services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
        Task<string> Register(RegisterationRequestDto registerationRequestDto);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<bool> AssignRole(string email, string roleName);
	}
	
}

