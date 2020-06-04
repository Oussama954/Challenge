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
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        public PictureRepository(ChallengeContext context) : base(context)
        {
        }
    }
}
