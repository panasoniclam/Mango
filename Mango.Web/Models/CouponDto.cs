using System;
namespace Mango.Web.Models
{
	public class CouponDto
	{
        public int CouponId { set; get; }
        public string CouponCode { set; get; }
        public double DiscountAmount { set; get; }
        public int MintAmount { set; get; }
    }
}

