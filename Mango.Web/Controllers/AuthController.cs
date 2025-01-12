using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mango.Web.Utility;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = SD.RoleAmin, Value =SD.RoleAmin},
                new SelectListItem{Text =SD.RoleCustomer, Value=SD.RoleCustomer}
            };


            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Register(RegisterationRequestDto obj)
        {
            ResponseDto result = await _authService.RegisterAsync(obj);
            ResponseDto assignRole;
            if(result != null && result.IsSuccess)
            {
                if (!string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;

                }
                assignRole = await _authService.AssignRoleAsync(obj);

                if(assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration success!";
                    return RedirectToAction(nameof(Login));
                }
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = SD.RoleAmin, Value =SD.RoleAmin},
                new SelectListItem{Text =SD.RoleCustomer, Value=SD.RoleCustomer}
            };


            ViewBag.RoleList = roleList;
            return View();

        }
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}

