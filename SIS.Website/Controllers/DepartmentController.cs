using Microsoft.AspNetCore.Mvc;
using SIS.DataStorage.Services;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Website.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.GetAllDepartments());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _departmentService.GetDepartmentById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _departmentService.CreateDepartmentAsync(department);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(department);
        }
        public async Task<IActionResult> Edit(string id)
        {
            return View(await _departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbProduct = await _departmentService.GetDepartmentById(id);
                    if (await TryUpdateModelAsync<Department>(dbProduct))
                    {
                        await _departmentService.UpdateDepartmentAsync(dbProduct);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbProduct = await _departmentService.GetDepartmentById(id);
                if (dbProduct != null)
                {
                    await _departmentService.DeleteDepartmentAsync(dbProduct);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

