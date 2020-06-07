using Challenge.Business.Interfaces;
using Challenge.Dal;
using Challenge.Dal.Interfaces;
using Challenge.Model;

namespace Challenge.Business
{
    /// <summary>
    ///     Unit of work Class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeContext _context;

        public UnitOfWork(ChallengeContext context)
        {
            _context = context;
            Equipments = new EquipmentRepository(_context);
            Pictures = new PictureRepository(_context);
        }

        public IEquipmentRepository Equipments { get; }
        public IPictureRepository Pictures { get; }

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