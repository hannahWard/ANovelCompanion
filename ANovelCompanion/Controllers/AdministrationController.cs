using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    public class Administration : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public Administration(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
    }
}