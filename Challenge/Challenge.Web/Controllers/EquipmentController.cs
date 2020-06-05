using Challenge.Business.Interfaces;
using Challenge.VO;
using Challenge.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Challenge.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        // GET: Equipment
        public ActionResult Index()
        {
            return View(_equipmentService.GetAll().Select(e => new EquipmentModel
            {
                Name = e.Name,
                NextControlDate = e.NextControlDate,
                SerialNumber = e.SerialNumber,
                PictureUrl = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(e.Picture))
            })) ;
        }

        // GET: Equipment/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipmentVO = _equipmentService.Find(id);
            var equipmentModel = new EquipmentModel
            {
                Name = equipmentVO.Name,
                NextControlDate = equipmentVO.NextControlDate,
                Picture = null,
                SerialNumber = equipmentVO.SerialNumber
            };
            if (equipmentVO == null)
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
        public ActionResult Create([Bind(Include = "SerialNumber,Name,Picture,NextControlDate")] EquipmentModel EquipmentModel)
        {
           
            if (ModelState.IsValid)
            {
                var target = new MemoryStream();
                EquipmentModel.Picture.InputStream.CopyTo(target);
                byte[] picture = target.ToArray();

                var equipmentVO = new EquipmentVO
                {
                    Name = EquipmentModel.Name,
                    NextControlDate = EquipmentModel.NextControlDate,
                    Picture = picture,
                    SerialNumber = EquipmentModel.SerialNumber
                };
                _equipmentService.Add(equipmentVO);

                return RedirectToAction("Index");
            }

            return View(EquipmentModel);
        }

        // GET: Equipment/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipmentVO = _equipmentService.Find(id);
            var equipmentModel = new EquipmentModel
            {
                Name = equipmentVO.Name,
                NextControlDate = equipmentVO.NextControlDate,
                Picture = null,
                SerialNumber = equipmentVO.SerialNumber
            };
            if (equipmentVO == null)
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
        public ActionResult Edit([Bind(Include = "SerialNumber,Name,Picture,NextControlDate")] EquipmentModel EquipmentModel)
        {
            if (ModelState.IsValid)
            {
                /* db.Entry(EquipmentModel).State = EntityState.Modified;
                 db.SaveChanges();*/
                return RedirectToAction("Index");
            }
            return View(EquipmentModel);
        }

        // GET: Equipment/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipmentVO = _equipmentService.Find(id);
            var equipmentModel = new EquipmentModel
            {
                Name = equipmentVO.Name,
                NextControlDate = equipmentVO.NextControlDate,
                Picture = null,
                SerialNumber = equipmentVO.SerialNumber
            };
            if (equipmentVO == null)
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
            /* EquipmentModel EquipmentModel = db.EquipmentModels.Find(id);
             db.EquipmentModels.Remove(EquipmentModel);
             db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}
