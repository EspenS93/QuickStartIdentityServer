using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickStartIdentityServer.Models;
using IdentityServer4.Services;
using QuickStartIdentityServer.Quickstart.UI;

namespace QuickStartIdentityServer.Controllers
{
    public class AdminController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;

        public AdminController(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Licenses()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Products()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Users()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Roles()
        {
            ViewData["Message"] = "Your application description page.";
            

            return View();
        }
        public IActionResult Invoices()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Specials()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }
    }
}
