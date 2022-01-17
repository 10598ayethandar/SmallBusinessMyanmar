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
    public class DelimanController : Controller
    {
        // GET: Deliman
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Deli_Man.Where(m => m.Password.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
            }
        }

        // GET: Deliman/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Deli_Man.Where(x => x.DId == id).FirstOrDefault());
            }
        }

        // GET: Deliman/Create
        public ActionResult DeliRegister()
        {
            return View();
        }

        // POST: Deliman/Create
        [HttpPost]
        public ActionResult DeliRegister(Deli_Man deli)
        {
            try
            {

                using (DBModel dbmodel = new DBModel())
                    {
                        dbmodel.Deli_Man.Add(deli);
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

        // GET: Deliman/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Deli_Man.Where(x => x.DId == id).FirstOrDefault());
            }
        }

        // POST: Deliman/Edit/5
        [HttpPost]
        public ActionResult Edit(Deli_Man deli)
        {
            try
            {

                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(deli).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deliman/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Deli_Man.Where(x => x.DId == id).FirstOrDefault());
            }
        }

        // POST: Deliman/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Deli_Man deli)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    deli = dbmodel.Deli_Man.Where(x => x.DId == id).FirstOrDefault();
                    dbmodel.Deli_Man.Remove(deli);
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
        public ActionResult Login(Deli_Man deliman )
        {
            using (DBModel dbmodel = new DBModel())
            {
                var deli = dbmodel.Deli_Man.Single(u => u.MId == deliman.MId && u.Password == deliman.Password);
                if (deli != null)
                {
                    return RedirectToAction("Index");
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
