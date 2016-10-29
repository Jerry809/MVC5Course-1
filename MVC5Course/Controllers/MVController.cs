using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MVController : Controller
    {
        // GET: MV
        public ActionResult Index()
        {
            ViewData["Temp1"] = "暫存資料 Temp1";

            var b = new ClientLoginViewModel()
            {
                FirstName = "Jerry",
                LastName = "Shih"
            };
            ViewData["Temp2"] = b;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["FormModel"] = model;
                return RedirectToAction("Created");
            }

            return View();
        }

        public ActionResult Created()
        {
            return View();
        }
    }
}