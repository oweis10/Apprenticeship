using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Apprenticeship.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Apprenticeship.Data;
using Apprenticeship.Repositories;

namespace Apprenticeship.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _dataContext;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext dataContext)
        {
            _userManager = userManager;
            _dataContext = dataContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.SingleOrDefault(x => x.Id == userId.Value.ToString());
            var userRole = _dataContext.UserRoles.Where(x => x.UserId == userId.Value).Select(x => x.RoleId).SingleOrDefault();
            var isAdmin = _dataContext.Roles.SingleOrDefault(x => x.Id == userRole).Name.ToString() == Roles.Admin.ToString();
            ViewBag.userRole = isAdmin;
                return View();
        }

        public IActionResult Skill(Skill skill)
        {


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
