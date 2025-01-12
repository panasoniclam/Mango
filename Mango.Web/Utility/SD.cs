using System;
namespace Mango.Web.Utility
{
	public class SD
	{
		public static string CouponAPIBase { get; set; }
		public enum ApiType{
		GET, PUT, POST, DELETE
			 }
		public static string AuthAPIBase { get; set; }
		public const string RoleAmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
    }
}

