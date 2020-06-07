using Challenge.Model;
using System.Collections.Generic;

namespace Challenge.Dal.Interfaces
{
    /// <summary>
    /// Equipment Repository interface
    /// </summary>
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        IEnumerable<Equipment> FindByName(string name, int page, int pageSize);
        int CountByName(string name);
    }
}
