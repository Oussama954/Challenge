using Challenge.Business.Interfaces;
using Challenge.Model;
using Challenge.VO;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Business
{
    /// <summary>
    /// Equipment Service Class
    /// </summary>
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Return the number of equipments
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _unitOfWork.Equipments.Count();
        }
        /// <summary>
        /// Retrun the number of equipment with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountByName(string name)
        {
            return _unitOfWork.Equipments.CountByName(name);
        }
        /// <summary>
        /// Store an equipment
        /// </summary>
        /// <param name="equipmentVO"></param>
        public void Add(EquipmentVO equipmentVO)
        {
            _unitOfWork.Equipments.Add(new Equipment
            {
                Name = equipmentVO.Name,
                SerialNumber = equipmentVO.SerialNumber,
                NextControlDate = equipmentVO.NextControlDate
            });
            _unitOfWork.Pictures.Add(new Picture
            {
                SerialNumber = equipmentVO.SerialNumber,
                Content = equipmentVO.Picture
            });
            _unitOfWork.Complete();
        }

        /// <summary>
        /// Delete an equipment
        /// </summary>
        /// <param name="equipmentVO"></param>
        public void Delete(EquipmentVO equipmentVO)
        {
            var serialNumber = equipmentVO.SerialNumber;
            var equipment = _unitOfWork.Equipments.Get(serialNumber);
            var picture = _unitOfWork.Pictures.Get(serialNumber);
            _unitOfWork.Equipments.Remove(equipment);
            _unitOfWork.Pictures.Remove(picture);
            _unitOfWork.Complete();
        }
        /// <summary>
        /// Find an equipment with given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EquipmentVO Find(int id)
        {
            var equipment = _unitOfWork.Equipments.Get(id);
            return new EquipmentVO
            {
                Name = equipment.Name,
                SerialNumber = equipment.SerialNumber,
                NextControlDate = equipment.NextControlDate,
                Picture = equipment.Picture.Content
            };
        }
        /// <summary>
        /// Update an equipment
        /// </summary>
        /// <param name="equipmentVO"></param>
        public void Update(EquipmentVO equipmentVO)
        {
            var equipment = _unitOfWork.Equipments.Get(equipmentVO.SerialNumber);
            equipment.Name = equipmentVO.Name;
            equipment.NextControlDate = equipmentVO.NextControlDate;
            equipment.Picture.Content = equipmentVO.Picture;
            _unitOfWork.Equipments.Update(equipment);
            _unitOfWork.Complete();
        }

        /// <summary>
        /// Retun all stored equipment
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> GetAll()
        {
            return _unitOfWork.Equipments.GetAll().Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Return all equipment sorted by serial number
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> OrderBySerialNumber(int page, int pageSize)
        {
            return _unitOfWork.Equipments.OrderBy(e => e.SerialNumber, page, pageSize).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Return all equipment sorted by serial number descending
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> OrderByDescendingSerialNumber(int page, int pageSize)
        {
            return _unitOfWork.Equipments.OrderByDescending(e => e.SerialNumber, page, pageSize).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Find all equipment with given name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> FindName(string name, int page, int pageSize)
        {
            return _unitOfWork.Equipments.FindByName(name, page, pageSize).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Order Equipments by name
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> OrderByName(int pageSize, int pageNumber)
        {
            return _unitOfWork.Equipments.OrderBy(e => e.Name, pageSize, pageNumber).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Order Equipments by name descending
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> OrderByDescendingName(int pageSize, int pageNumber)
        {
            return _unitOfWork.Equipments.OrderByDescending(e => e.Name, pageSize, pageNumber).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Order Equipments by next controle date 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> OrderByDate(int pageSize, int pageNumber)
        {
            return _unitOfWork.Equipments.OrderBy(e => e.NextControlDate, pageSize, pageNumber).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
        /// <summary>
        /// Order Equipments by next controle date descending
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentVO> OrderByDescendingDate(int pageSize, int pageNumber)
        {
            return _unitOfWork.Equipments.OrderByDescending(e => e.NextControlDate, pageSize, pageNumber).Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
    }
}
