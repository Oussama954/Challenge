﻿using Challenge.VO;
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
        IEnumerable<EquipmentVO> OrderBySerialNumber(int page, int pageSize);
        IEnumerable<EquipmentVO> OrderByDescendingSerialNumber(int page, int pageSize);
        IEnumerable<EquipmentVO> FindName(string name, int page, int pageSize);
    }
}
