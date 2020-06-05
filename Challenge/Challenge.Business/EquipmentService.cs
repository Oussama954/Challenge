using Challenge.Business.Interfaces;
using Challenge.Model;
using Challenge.VO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Business
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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

        public EquipmentVO Find(decimal id)
        {
            var equipment =_unitOfWork.Equipments.Get(id);
            return new EquipmentVO
            {
                Name = equipment.Name,
                SerialNumber = equipment.SerialNumber,
                NextControlDate = equipment.NextControlDate,
                Picture = equipment.Picture.Content
            };
        }

        public IEnumerable GetAll()
        {
            return _unitOfWork.Equipments.GetAll();
        }

        IEnumerable<EquipmentVO> IEquipmentService.GetAll()
        {
            return _unitOfWork.Equipments.GetAll().Select(e => new EquipmentVO
            {
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                NextControlDate = e.NextControlDate,
                Picture = e.Picture.Content
            });
        }
    }
}
