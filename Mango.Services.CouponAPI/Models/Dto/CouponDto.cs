using System;
namespace Mango.Services.CouponAPI.Models.Dto
{
	public class CouponDto
	{
        public int CouponId { set; get; }
        public string CouponCode { set; get; }
        public double DiscountAmount { set; get; }
        public int MintAmount { set; get; }
    }
}

