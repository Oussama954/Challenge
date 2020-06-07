using Challenge.Business.Interfaces;
using Challenge.VO;
using Challenge.Web.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
        public ActionResult Index(string sortOrder, int? page, string searchString,string currentFilter) 
        {
            var pager = new Pager(_equipmentService.Count(), page);
            int pageSize = (pager.CurrentPage - 1) * pager.PageSize;
            int pageNumber = pager.PageSize;

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SerialNumberSortParm = string.IsNullOrEmpty(sortOrder) ? "serial_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.NextControlDateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var equipmentList = _equipmentService.OrderBySerialNumber(pageSize, pageNumber);

            if (searchString == null)
            {
                searchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                pager = new Pager(_equipmentService.CountByName(searchString), page);
                equipmentList = _equipmentService.FindName(searchString, (pager.CurrentPage - 1) * pager.PageSize,  pager.PageSize);
            }
            switch (sortOrder)
            {
                case "serial_desc":
                    equipmentList = _equipmentService.OrderByDescendingSerialNumber(pageSize, pageNumber);
                    break;
                case "Name":
                    equipmentList = _equipmentService.OrderByName(pageSize, pageNumber);
                    break;
                case "name_desc":
                    equipmentList = _equipmentService.OrderByDescendingName(pageSize, pageNumber);
                    break;
                case "Date":
                    equipmentList = _equipmentService.OrderByDate(pageSize, pageNumber);
                    break;
                case "date_desc":
                    equipmentList = _equipmentService.OrderByDescendingDate(pageSize, pageNumber);
                    break;
            }
            var viewModel = new IndexViewModel
            {
                Items = equipmentList.Select(e => new EquipmentModel
                {
                    Name = e.Name,
                    NextControlDate = e.NextControlDate,
                    SerialNumber = e.SerialNumber,
                    PictureUrl = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(e.Picture))
                }),
                Pager = pager
            };

            return View(viewModel);
        }

        // GET: Equipment/Details/5
        public ActionResult Details(int id)
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
                PictureUrl = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(equipmentVO.Picture)),
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
                var picture = new byte[0];
                if(EquipmentModel.Picture != null)
                {
                    var target = new MemoryStream();
                    EquipmentModel.Picture.InputStream.CopyTo(target);
                    picture = target.ToArray();
                }

                var equipmentVO = new EquipmentVO
                {
                    Name = EquipmentModel.Name,
                    NextControlDate = EquipmentModel.NextControlDate,
                    Picture = picture,
                    SerialNumber = EquipmentModel.SerialNumber
                };
                try
                {
                    _equipmentService.Add(equipmentVO);

                }
                catch (DbUpdateException e)
                when
                      (e.InnerException?.InnerException is SqlException sqlEx
                      && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    return RedirectToAction("Unique");
                }

                return RedirectToAction("Index");
            }
            return View(EquipmentModel);
        }

        // GET: Equipment/Edit/5
        public ActionResult Edit(int id)
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
                var picture = new byte[0];
                if (EquipmentModel.Picture != null)
                {
                    var target = new MemoryStream();
                    EquipmentModel.Picture.InputStream.CopyTo(target);
                    picture = target.ToArray();
                }
                var equipmentVO = new EquipmentVO
                {
                    Name = EquipmentModel.Name,
                    NextControlDate = EquipmentModel.NextControlDate,
                    Picture = picture,
                    SerialNumber = EquipmentModel.SerialNumber
                };
                _equipmentService.Update(equipmentVO);
                return RedirectToAction("Index");
            }
            return View(EquipmentModel);
        }

        // GET: Equipment/Delete/5
        public ActionResult Delete(int id)
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
                PictureUrl = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(equipmentVO.Picture)),
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
        public ActionResult DeleteConfirmed(int id)
        {
            var equipmentVO = _equipmentService.Find(id);
            _equipmentService.Delete(equipmentVO);
            return RedirectToAction("Index");
        }
        public ActionResult Unique()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
