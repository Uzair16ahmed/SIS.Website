using Microsoft.AspNetCore.Mvc;
using SIS.DataStorage.Services;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController (IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsers());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _userService.GetUserById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.CreateUserAsync(user);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(user);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _userService.GetUserById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbProduct = await _userService.GetUserById(id);
                    if (await TryUpdateModelAsync<User>(dbProduct))
                    {
                        await _userService.UpdateUserAsync(dbProduct);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception )
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbProduct = await _userService.GetUserById(id);
                if (dbProduct != null)
                {
                    await _userService.DeleteUserAsync(dbProduct);
                }
            }
            catch (Exception )
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
