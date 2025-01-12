 using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Mango.Services.AuthAPI.Models;
namespace Mango.Services.AuthAPI.Data
{
	public class AppDbContext:IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
		{
		}

         public  DbSet<ApplicationUser> ApplicationUsers { set; get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);
        }

    }
}

