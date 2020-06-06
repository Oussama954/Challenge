using Challenge.Dal.Interfaces;
using Challenge.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Dal
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ChallengeContext context) : base(context)
        {
        }

        public IEnumerable<Equipment> FindByName(string name, int page, int pageSize)
        {
            return Context.Set<Equipment>().Where(e => name.Contains(e.Name)).OrderByDescending(e=>e.Name ).Skip(page).Take(pageSize).ToList();
        }
    }
}
