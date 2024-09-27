using Microsoft.AspNetCore.Mvc;
using PeriodicTaskManagementSystem.Business.Interfaces;

namespace PeriodicTaskManagementSystem.WebApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task <IActionResult> Index()
        {
            var roles = await _roleService.GetAllAsync();
            return View(roles);
        }
    }
}
