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
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel=new DBModel())
            {
                return View(dbmodel.Members.Where(m => m.UName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1,10));
            }
        }


        public ActionResult MemberList(int? page, string search)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(m => m.UName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }
        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(x => x.MId == id).FirstOrDefault());
            }
        }

        // GET: Member/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Register(Member member)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(member.ImageFile.FileName);
                string extension = Path.GetExtension(member.ImageFile.FileName);
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                filename = filename + randomNumber.ToString() + extension;
                member.ImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                member.ImageFile.SaveAs(filename);


                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Members.Add(member);
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

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(x => x.MId == id).FirstOrDefault());
            }
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(Member member)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(member).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Members.Where(x => x.MId == id).FirstOrDefault());
            }
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Member member)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                     member= dbmodel.Members.Where(x => x.MId == id).FirstOrDefault();
                    dbmodel.Members.Remove(member);
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
