using Microsoft.AspNetCore.Mvc;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Website.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationUser _auc;
        public RegistrationController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            return View("/Home/Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegisterModel uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The user" + uc.Username + " is saved successfully";
            //  ViewBag.message = "The user " + uc.Username + " is saved successfully";
            return View();
        }
    }
}
