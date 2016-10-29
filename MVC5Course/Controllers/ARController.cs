using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult FileTest1()
        {
            var filePath = Server.MapPath("~/Content/PPAP.jpg");
            return File(filePath, "image/jpeg");
        }

        public ActionResult FileTest2()
        {
            var filePath = Server.MapPath("~/Content/PPAP.jpg");
            return File(filePath, "image/jpeg","PPAP.jpg");
        }
    }
}