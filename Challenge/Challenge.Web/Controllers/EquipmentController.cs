using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge.Web.Data;
using Challenge.Web.Models;

namespace Challenge.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private ChallengeWebContext db = new ChallengeWebContext();

        // GET: Equipment
        public ActionResult Index()
        {
            return View(db.EquipmentModels.ToList());
        }

        // GET: Equipment/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentModel equipmentModel = db.EquipmentModels.Find(id);
            if (equipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentModel);
        }

        // GET: Equipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipment/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNumber,Name,Picture,NextControlDate")] EquipmentModel equipmentModel)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentModels.Add(equipmentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipmentModel);
        }

        // GET: Equipment/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentModel equipmentModel = db.EquipmentModels.Find(id);
            if (equipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentModel);
        }

        // POST: Equipment/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNumber,Name,Picture,NextControlDate")] EquipmentModel equipmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipmentModel);
        }

        // GET: Equipment/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentModel equipmentModel = db.EquipmentModels.Find(id);
            if (equipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentModel);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            EquipmentModel equipmentModel = db.EquipmentModels.Find(id);
            db.EquipmentModels.Remove(equipmentModel);
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
