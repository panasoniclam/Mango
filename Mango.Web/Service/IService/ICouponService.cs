using System;
using Mango.Web.Models;
namespace Mango.Web.Service.IService
{
	public interface ICouponService
	{
		Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);

        Task<ResponseDto?> GetAllCouponAsync();

        Task<ResponseDto?> GetCouponByIdAsync(int id);

        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);

        Task<ResponseDto?> DeleteCouponAsync(int id);

    }
}

