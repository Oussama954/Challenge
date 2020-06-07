using Challenge.Dal.Interfaces;
using System;

namespace Challenge.Business.Interfaces
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IEquipmentRepository Equipments { get; }
        IPictureRepository Pictures { get; }
        int Complete();
    }
}
