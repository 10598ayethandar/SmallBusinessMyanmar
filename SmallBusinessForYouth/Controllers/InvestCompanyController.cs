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
    public class InvestCompanyController : Controller
    {
        // GET: InvestCompany
        public ActionResult Index(int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.InvestCompanies.ToList().ToPagedList(page ?? 1, 5));
            }
        }

        // GET: InvestCompany/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvestCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvestCompany/Create
        [HttpPost]
        public ActionResult Create(InvestCompany company)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.InvestCompanies.Add(company);
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

        // GET: InvestCompany/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvestCompany/Edit/5
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

        // GET: InvestCompany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvestCompany/Delete/5
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
