using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            return View(data);
        }

        public ActionResult Create()
        {
            var product = new Product()
            {
                ProductName = "White 001",
                Price = 1000,
                Active = true,
                Stock = 5
            };
            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);
            product.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = db.Product.Find(id);
            return View(product);
        }

        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName += "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName + " 發生錯誤：" + vErrors.ErrorMessage);
                    }
                }
                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update20Percent()
        {
            var product = db.Product.Where(p => p.ProductName.Contains("White"));
            foreach (var item in product)
            {
                if (item.Price.HasValue)
                {
                    item.Price = item.Price * 1.2m;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ClientContribution()
        {
            var data = db.vw_ClientContribution.Take(20);
            return View(data);
        }
    }
}