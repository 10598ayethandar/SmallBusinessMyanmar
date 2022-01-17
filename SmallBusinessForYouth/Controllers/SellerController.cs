using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessForYouth.Models;
using PagedList;
using PagedList.Mvc;

namespace SmallBusinessForYouth.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult Index(String search, int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Sellers.Where(m => m.Password.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
            }
        }

        // GET: Seller/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Sellers.Where(x => x.SId == id).FirstOrDefault());
            }
        }

        // GET: Seller/Create
        public ActionResult SellerRegister()
        {
            return View();
        }

        // POST: Seller/Create
        [HttpPost]
        public ActionResult SellerRegister(Seller sell)
        {
            try
            {


                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Sellers.Add(sell);
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

        // GET: Seller/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Sellers.Where(x => x.SId == id).FirstOrDefault());
            }
        }

        // POST: Seller/Edit/5
        [HttpPost]
        public ActionResult Edit( Seller sell)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(sell).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Sellers.Where(x => x.SId == id).FirstOrDefault());
            }
        }

        // POST: Seller/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Seller sell)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    sell = dbmodel.Sellers.Where(x => x.SId == id).FirstOrDefault();
                    dbmodel.Sellers.Remove(sell);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Seller seller)
        {
            using (DBModel dbmodel = new DBModel())
            {
                var sell = dbmodel.Sellers.Single(u => u.MId == seller.MId && u.Password == seller.Password);
                if (sell != null)
                {
                    return RedirectToAction("Create","Products");
                }
                else
                {
                    ModelState.AddModelError("", "User Name Or Password is Wrong...");
                }
            }
            return View();
        }
    }
}
