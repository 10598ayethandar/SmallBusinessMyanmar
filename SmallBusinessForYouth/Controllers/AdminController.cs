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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.AdminTables.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
            }
        }

        // GET: Admin/Details/5
        public ActionResult MemberDetails(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(x => x.MId == id).FirstOrDefault());
            }
        }

        public ActionResult ProductDetails(int id)
        {
            using (DBModel1 dbmodel = new DBModel1())
            {
                return View(dbmodel.Products.Where(x => x.PId == id).FirstOrDefault());
            }
        }
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.AdminTables.Where(x => x.AId == id).FirstOrDefault());
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdminTable admin)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.AdminTables.Add(admin);
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
        

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.AdminTables.Where(x => x.AId == id).FirstOrDefault());
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AdminTable admin)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }
        public ActionResult MemberDelete(int id)
        {

            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(x => x.MId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult MemberDelete(int id, Member member)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    member = dbmodel.Members.Where(x => x.MId == id).FirstOrDefault();
                    dbmodel.Members.Remove(member);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("AdminMember");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProductDelete(int id)
        {

            using (DBModel1 dbmodel = new DBModel1())
            {
                return View(dbmodel.Products.Where(x => x.PId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult ProductDelete(int id, Product product)
        {
            try
            {
                using (DBModel1 dbmodel = new DBModel1())
                {
                    product = dbmodel.Products.Where(x => x.PId == id).FirstOrDefault();
                    dbmodel.Products.Remove(product);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("AdminProduct");
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
        public ActionResult Login(AdminTable admin)
        {
            using(DBModel dbmodel=new DBModel())
            {
                var usr = dbmodel.AdminTables.Single(u => u.Name == admin.Name && u.Password == admin.Password);
                if (usr != null)
                {
                    Session["AId"] = usr.AId.ToString();
                    Session["Name"] = usr.Name.ToString();
                    if(admin.Name == "admin1")
                    {
                        return RedirectToAction("AdminMember");
                    }
                    else
                    {
                        return RedirectToAction("AdminProduct");
                    }
                    
                }
                else{
                    ModelState.AddModelError("", "User Name Or Password is Wrong...");
                }
            }
            return View();
        }

        public ActionResult AdminMember(string search, int? page)
        {

            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(m => m.UName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }

        }

        public ActionResult AdminProduct(string search, int? page)
        {

            using (DBModel1 dbmodel = new DBModel1())
            {
                return View(dbmodel.Products.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }

        }
        public ActionResult logout()
        {
            Session.Clear();
            return View("Login", "Login");
        }
    }
}
