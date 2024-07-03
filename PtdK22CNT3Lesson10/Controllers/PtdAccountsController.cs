using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PtdK22CNT3Lesson10.Models;

namespace PtdK22CNT3Lesson10.Controllers
{
    public class PtdAccountsController : Controller
    {
        private PTDK22CNT3Lesson10Entities db = new PTDK22CNT3Lesson10Entities();

        // GET: PtdAccounts
        public ActionResult Index()
        {
            return View(db.PtdAccount.ToList());
        }

        // GET: PtdAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PtdAccount ptdAccount = db.PtdAccount.Find(id);
            if (ptdAccount == null)
            {
                return HttpNotFound();
            }
            return View(ptdAccount);
        }

        // GET: PtdAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PtdAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PtdId,PtdUserName,PtdPassword,PtdFullName,PtdEmail,PtdPhone,PtdActive")] PtdAccount ptdAccount)
        {
            if (ModelState.IsValid)
            {
                db.PtdAccount.Add(ptdAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ptdAccount);
        }

        // GET: PtdAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PtdAccount ptdAccount = db.PtdAccount.Find(id);
            if (ptdAccount == null)
            {
                return HttpNotFound();
            }
            return View(ptdAccount);
        }

        // POST: PtdAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PtdId,PtdUserName,PtdPassword,PtdFullName,PtdEmail,PtdPhone,PtdActive")] PtdAccount ptdAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ptdAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ptdAccount);
        }

        // GET: PtdAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PtdAccount ptdAccount = db.PtdAccount.Find(id);
            if (ptdAccount == null)
            {
                return HttpNotFound();
            }
            return View(ptdAccount);
        }

        // POST: PtdAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PtdAccount ptdAccount = db.PtdAccount.Find(id);
            db.PtdAccount.Remove(ptdAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult PtdLogin()
        {
            var ptdMoldel = new PtdAccount();
            return View(ptdMoldel);
        }
        [HttpPost]
        public ActionResult PtdLogin(PtdAccount ptdAccount)
        {
            var ptdCheck = db.PtdAccount.Where(x => x.PtdUserName.Equals(ptdAccount.PtdUserName) && x.PtdPassword.Equals(ptdAccount.PtdPassword)).FirstOrDefault();
            if (ptdCheck != null)
              
            {
                //luu session
                Session["PtdAccount"] = ptdCheck;
                return Redirect("/");
            }
            return View(ptdAccount);
        }
    }
}
