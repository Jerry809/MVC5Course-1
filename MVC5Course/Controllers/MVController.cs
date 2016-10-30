using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MVController : BaseController
    {
        [LocalRequestOnly]
        [ShareViewBagData]
        // GET: MV
        public ActionResult Index()
        {
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

        public ActionResult ProductList()
        {
            var data = db.Product.OrderBy(x=>x.ProductId).Take(20);
            return View(data);
        }

        public ActionResult BatchUpdate(IList<ProductBatchUpdateViewModel> items)
        {
            /*
             * 預設輸出的欄位名稱格式：item.ProductId
             * 要改成以下欄位格式：
             * items[0].ProductId
             * items[1].ProductId
             */

            if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    var product = db.Product.Find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Price = item.Price;
                    product.Active = item.Active;
                    product.Stock = item.Stock;
                } 
            }

            db.SaveChanges();

            return RedirectToAction("ProductList");
        }

        public ActionResult MyError()
        {
            throw new InvalidOperationException("ERROR");
            return View();
        }
    }
}