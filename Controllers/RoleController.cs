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

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkId=397860

namespace QuickStartIdentityServer.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;


        public RoleController(
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger
            )
        {
            _roleManager = roleManager;
            _logger = logger;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRoleViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole(model.Name);
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Role created");

                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // GET: api/Role
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles;
            ListViewModel model = new ListViewModel();
            model.Headers.Add("Name");

            return View(model);
        }

        // GET: api/Role/id
        [HttpGet("{id}", Name = "GetRole")]
        public async Task<IActionResult> GetRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return new ObjectResult(role);
        }

        // POST: api/Role
        [HttpPost]
        public async Task<IActionResult> AddRoleAsync([FromBody]IdentityRole role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            var result = await _roleManager.CreateAsync(role);
            return CreatedAtRoute("GetRole", new { id = role.Id }, role);
        }

        // PUT: api/Role/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(string id, [FromBody]IdentityRole newRole)
        {
            if (newRole == null || newRole.Id != id)
            {
                return BadRequest();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleManager.UpdateAsync(newRole);
            return new NoContentResult();
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                await _roleManager.DeleteAsync(role);
                return new NoContentResult();
            }
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
