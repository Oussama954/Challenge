using Challenge.Dal.Interfaces;
using Challenge.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Dal
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ChallengeContext context) : base(context)
        {
        }
    }
}
