using Challenge.Dal.Interfaces;
using Challenge.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Challenge.Dal
{
    /// <summary>
    /// Equipment Repository Class
    /// </summary>
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ChallengeContext context) : base(context)
        {
        }
        /// <summary>
        /// Count the number of equipment with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountByName(string name)
        {
            return Context.Set<Equipment>().Where(e => e.Name == name).Count();
        }
        /// <summary>
        /// Find the equipments with given name with pagination
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Equipment> FindByName(string name, int page, int pageSize)
        {
            return Context.Set<Equipment>().Where(e => name == e.Name)
                                           .OrderByDescending(e => e.Name)
                                           .Skip(page)
                                           .Take(pageSize)
                                           .ToList();
        }
    }
}
