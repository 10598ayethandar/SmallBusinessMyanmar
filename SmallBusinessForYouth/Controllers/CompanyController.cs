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
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Companies.Where(m => m.CName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Companies.Where(x => x.CId == id).FirstOrDefault());
            }
        }

        // GET: Company/Create
        public ActionResult CompanyRegister()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult CompanyRegister(Company company)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Companies.Add(company);
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

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Companies.Where(x => x.CId == id).FirstOrDefault());
            }
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Company company)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(company).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Companies.Where(x => x.CId == id).FirstOrDefault());
            }
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Company company)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    company = dbmodel.Companies.Where(x => x.CId == id).FirstOrDefault();
                    dbmodel.Companies.Remove(company);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
