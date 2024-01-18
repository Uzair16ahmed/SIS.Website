using Microsoft.AspNetCore.Mvc;
using System;
using SIS.DataStorage.Services;
using SIS.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Website.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAllCourses());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _courseService.GetCourseById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Courses course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _courseService.CreateCourseAsync(course);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(course);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _courseService.GetCourseById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Courses course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbProduct = await _courseService.GetCourseById(id);
                    if (await TryUpdateModelAsync<Courses>(dbProduct))
                    {
                        await _courseService.UpdateCourseAsync(dbProduct);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbProduct = await _courseService.GetCourseById(id);
                if (dbProduct != null)
                {
                    await _courseService.DeleteCourseAsync(dbProduct);
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
