using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeCRUD;

namespace EmployeeCRUD.Controllers
{
    public class employees_tblController : Controller
    {
        private EmployeeDataModel db = new EmployeeDataModel();

        // GET: employees_tbl
        public ActionResult Index()
        {
            return View(db.employees_tbl.ToList());
        }

        // GET: employees_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employees_tbl employees_tbl = db.employees_tbl.Find(id);
            if (employees_tbl == null)
            {
                return HttpNotFound();
            }
            return View(employees_tbl);
        }

        // GET: employees_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employees_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,Salary")] employees_tbl employees_tbl)
        {
            if (ModelState.IsValid)
            {
                db.employees_tbl.Add(employees_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees_tbl);
        }

        // GET: employees_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employees_tbl employees_tbl = db.employees_tbl.Find(id);
            if (employees_tbl == null)
            {
                return HttpNotFound();
            }
            return View(employees_tbl);
        }

        // POST: employees_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,Salary")] employees_tbl employees_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees_tbl);
        }

        // GET: employees_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employees_tbl employees_tbl = db.employees_tbl.Find(id);
            if (employees_tbl == null)
            {
                return HttpNotFound();
            }
            return View(employees_tbl);
        }

        // POST: employees_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employees_tbl employees_tbl = db.employees_tbl.Find(id);
            db.employees_tbl.Remove(employees_tbl);
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
    }
}
