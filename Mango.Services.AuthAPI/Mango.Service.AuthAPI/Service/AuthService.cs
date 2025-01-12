using System;
using Mango.Services.AuthAPI.Service.IService;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Data;
using Microsoft.AspNetCore.Identity;
using Mango.Services.AuthAPI.Service.IService;
namespace Mango.Services.AuthAPI.Service
{
	public class AuthService:IAuthService
	{
		private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IjwtTokenGenerator _jwtTokenGenerator;
		public AuthService(AppDbContext db,IjwtTokenGenerator jwtTokenGenerator ,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
			if(user != null)
			{
				if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					// tao role neu role khong ton tai
					_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
				}
				await _userManager.AddToRoleAsync(user, roleName);
				return true;
			}
			return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
			if(user == null || isValid == false)
			{
				return new LoginResponseDTO() { User = null, Token = "" };
			}
			// neu tim duoc thi gen ra token
			var token = _jwtTokenGenerator.GenerateToken(user);
            UserDto userDto = new()
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				Name = user.Name,
				ID = user.Id,
			};

			LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
			{
				User = userDto,
				Token = token,
			};
			return loginResponseDTO;
		}
        public async Task<string> Register(RegisterationRequestDto registerationRequestDto)
        {
			ApplicationUser user = new()
			{
				UserName = registerationRequestDto.Email,
				Email = registerationRequestDto.Email,
				NormalizedEmail = registerationRequestDto.Email.ToUpper(),
				Name = registerationRequestDto.Name,
				PhoneNumber = registerationRequestDto.PhoneNumber
			};
			try
			{
				var result = await _userManager.CreateAsync(user, registerationRequestDto.Password);
				if (result.Succeeded)
				{
					var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registerationRequestDto.Email);

					UserDto userDto = new()
					{
						Email = userToReturn.Email,
						ID = userToReturn.Id,
						PhoneNumber = userToReturn.PhoneNumber,
						Name = userToReturn.Name
					};
					return "";
				}
				else
				{
					return result.Errors.FirstOrDefault().Description;
				}
			}
			catch (Exception ex)
			{

			}
			return "Error encounterned";
        }
    }
}

