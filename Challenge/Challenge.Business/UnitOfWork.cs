using Challenge.Business.Interfaces;
using Challenge.Dal;
using Challenge.Dal.Interfaces;
using Challenge.Model;

namespace Challenge.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeContext _context;
        public IEquipmentRepository Equipments { get; private set; }

        public IPictureRepository Pictures { get; private set; }

        public UnitOfWork(ChallengeContext context)
        {
            _context = context;
            Equipments = new EquipmentRepository(_context);
            Pictures = new PictureRepository(_context);
        }
        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
