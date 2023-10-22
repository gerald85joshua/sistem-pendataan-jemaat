using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            var viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }

        public IActionResult Register()
        {
            var viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }

        public IActionResult RegisterAdminRole()
        {
            var viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }
    }
}
