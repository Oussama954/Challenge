using Challenge.Dal.Interfaces;
using Challenge.Model;

namespace Challenge.Dal
{
    /// <summary>
    /// Picture Repository Class
    /// </summary>
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        public PictureRepository(ChallengeContext context) : base(context)
        {
        }
    }
}
