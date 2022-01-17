using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessForYouth.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace SmallBusinessForYouth.Controllers
{
    public class SpecialOrderController : Controller
    {
        // GET: SpecialOrder
        public ActionResult Index()
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Orders.ToList());
            }
        }

        // GET: SpecialOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpecialOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialOrder/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {

                string filename = Path.GetFileNameWithoutExtension(order.OrderImageFile.FileName);
                string extension = Path.GetExtension(order.OrderImageFile.FileName);
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                filename = filename + randomNumber.ToString() + extension;
                order.OrderImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                order.OrderImageFile.SaveAs(filename);

               
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Orders.Add(order);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
               
                TempData["Message"] = "<script>alert('Order Successfully...')</script>";
                return RedirectToAction("ProductList","Products");
            }
            catch
            {
                return View();
            }
        }

        // GET: SpecialOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecialOrder/Edit/5
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

        // GET: SpecialOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialOrder/Delete/5
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
