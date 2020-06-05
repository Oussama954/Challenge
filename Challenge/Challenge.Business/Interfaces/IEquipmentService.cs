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
    }
}
