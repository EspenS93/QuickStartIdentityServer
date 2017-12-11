using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickStartIdentityServer.Models;
using QuickStartIdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using QuickStartIdentityServer.Models.AdminViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkId=397860

namespace QuickStartIdentityServer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LicenseViewComponent : ViewComponent
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;


        public LicenseViewComponent(
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger
            )
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            ListViewModel model = new ListViewModel();
            model.Headers = new List<string>
            {
                "name"
            };
            model.Name = "Roles";
            model.List = roles.ToList();
            return View(model);
        }

        public async Task<ListViewModel> GetItemsAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            ListViewModel model = new ListViewModel();
            model.Headers.Add("Name");

            return model;
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
