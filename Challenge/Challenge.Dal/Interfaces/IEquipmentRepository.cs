using Challenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Dal.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        IEnumerable<Equipment> FindByName(string name, int page, int pageSize);
    }
}
