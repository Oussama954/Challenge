using Challenge.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEquipmentRepository Equipments { get; }
        IPictureRepository Pictures { get; }
        int Complete();
    }
}
