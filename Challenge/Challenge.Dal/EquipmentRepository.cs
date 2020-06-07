using Challenge.Dal.Interfaces;
using Challenge.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Challenge.Dal
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ChallengeContext context) : base(context)
        {
        }

        public int CountByName(string name)
        {
            return Context.Set<Equipment>().Where(e => e.Name == name).Count();
        }

        public IEnumerable<Equipment> FindByName(string name, int page, int pageSize)
        {
            return Context.Set<Equipment>().Where(e => name == e.Name).OrderByDescending(e => e.Name).Skip(page).Take(pageSize).ToList();
        }
    }
}
