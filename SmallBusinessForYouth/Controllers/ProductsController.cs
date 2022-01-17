using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessForYouth.Models;
using PagedList;
using PagedList.Mvc;
namespace SmallBusinessForYouth.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(int? page,string search)
        {
            using (DBModel1 dbmodel = new DBModel1())
            {
                return View(dbmodel.Products.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        public ActionResult ProductList(int? page, string search)
        {
            using (DBModel1 dbmodel = new DBModel1())
            {
                return View(dbmodel.Products.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        public ActionResult ProductListForCompany(int? page, string search)
        {
            using (DBModel1 dbmodel = new DBModel1())
            {
                return View(dbmodel.Products.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(product.ProductFile.FileName);
                string extension = Path.GetExtension(product.ProductFile.FileName);
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                filename = filename + randomNumber.ToString() + extension;
                product.Image_Path = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                product.ProductFile.SaveAs(filename);

                using (DBModel1 dbmodel = new DBModel1())
                {
                    dbmodel.Products.Add(product);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
