using Challenge.VO;
using System.Collections;
using System.Collections.Generic;

namespace Challenge.Business.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentVO> GetAll();
        EquipmentVO Find(int id);
        void Add(EquipmentVO equipmentVO);
        void Update(EquipmentVO equipmentVO);
        void Delete(EquipmentVO equipmentVO);
        int Count();
        int CountByName(string name);
        IEnumerable<EquipmentVO> OrderBySerialNumber(int page, int pageSize);
        IEnumerable<EquipmentVO> OrderByDescendingSerialNumber(int page, int pageSize);
        IEnumerable<EquipmentVO> FindName(string name, int page, int pageSize);
        IEnumerable<EquipmentVO> OrderByName(int pageSize, int pageNumber);
        IEnumerable<EquipmentVO> OrderByDescendingName(int pageSize, int pageNumber);
        IEnumerable<EquipmentVO> OrderByDate(int pageSize, int pageNumber);
        IEnumerable<EquipmentVO> OrderByDescendingDate(int pageSize, int pageNumber);
    }
}
