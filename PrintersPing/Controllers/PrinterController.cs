using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrintersPing.Models;

namespace PrintersPing.Controllers
{
    public class PrinterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Printer/
        public ActionResult Index()
        {
            var printers = db.Printers.Include(p => p.Printer_Location).Include(p => p.Printer_Make).Include(p => p.Printer_Model).Include(p => p.Printer_Status);
            return View(printers.ToList());
        }

        // GET: /Printer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Printers.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // GET: /Printer/Create
        public ActionResult Create()
        {
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Printer_Location");
            ViewBag.Make_id = new SelectList(db.Makes, "Make_id", "Printer_Make");
            ViewBag.Model_id = new SelectList(db.Models, "Model_id", "Printer_Model");
            ViewBag.Status_id = new SelectList(db.Status, "Status_id", "Printer_Status");
            return View();
        }

        // POST: /Printer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Location_id,Make_id,Model_id,Printer_Type,IP,VLAN,Ink_or_Toner,Comment,Status_id,Warning,Serial,MAC_Address")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                db.Printers.Add(printer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Printer_Location", printer.Location_id);
            ViewBag.Make_id = new SelectList(db.Makes, "Make_id", "Printer_Make", printer.Make_id);
            ViewBag.Model_id = new SelectList(db.Models, "Model_id", "Printer_Model", printer.Model_id);
            ViewBag.Status_id = new SelectList(db.Status, "Status_id", "Printer_Status", printer.Status_id);
            return View(printer);
        }

        // GET: /Printer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Printers.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Printer_Location", printer.Location_id);
            ViewBag.Make_id = new SelectList(db.Makes, "Make_id", "Printer_Make", printer.Make_id);
            ViewBag.Model_id = new SelectList(db.Models, "Model_id", "Printer_Model", printer.Model_id);
            ViewBag.Status_id = new SelectList(db.Status, "Status_id", "Printer_Status", printer.Status_id);
            return View(printer);
        }

        // POST: /Printer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Location_id,Make_id,Model_id,Printer_Type,IP,VLAN,Ink_or_Toner,Comment,Status_id,Warning,Serial,MAC_Address")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Printer_Location", printer.Location_id);
            ViewBag.Make_id = new SelectList(db.Makes, "Make_id", "Printer_Make", printer.Make_id);
            ViewBag.Model_id = new SelectList(db.Models, "Model_id", "Printer_Model", printer.Model_id);
            ViewBag.Status_id = new SelectList(db.Status, "Status_id", "Printer_Status", printer.Status_id);
            return View(printer);
        }

        // GET: /Printer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Printers.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // POST: /Printer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Printer printer = db.Printers.Find(id);
            db.Printers.Remove(printer);
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
