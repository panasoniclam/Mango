using System;
using Mango.Web.Models;
namespace Mango.Web.Service.IService
{
	public interface IAuthService
	{
		Task<ResponseDto> LoginAsync(LoginRequestDTO loginRequestDTO);
		Task<ResponseDto> RegisterAsync(RegisterationRequestDto registerationRequestDto);
		Task<ResponseDto> AssignRoleAsync(RegisterationRequestDto registerationRequestDto);

	}
}

