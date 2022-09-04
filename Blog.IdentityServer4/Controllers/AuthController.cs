using Blog.IdentityServer4.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.IdentityServer4.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<BlogUser> _userManager;
		private readonly RoleManager<BlogUserRole> _roleManager;

		public AuthController(UserManager<BlogUser> _userManager, RoleManager<BlogUserRole> _roleManager)
		{
			this._userManager = _userManager;
			this._roleManager = _roleManager;
		}
		public IActionResult Register()
		{
			throw new NotImplementedException();
		}
	}
}
