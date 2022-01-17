using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using SmallBusinessForYouth.Models;

namespace SmallBusinessForYouth.Controllers
{
    public class ComplainController : Controller
    {
        // GET: Complain
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Complains.Where(m => m.C_Type.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
            }
        }

        // GET: Complain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Complain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Complain/Create
        [HttpPost]
        public ActionResult Create(Complain complain)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Complains.Add(complain);
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

        // GET: Complain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Complain/Edit/5
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

        // GET: Complain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Complain/Delete/5
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
