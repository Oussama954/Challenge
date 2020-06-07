using System;

namespace Challenge.Business.Exceptions
{
    public class EquipmentExistException : Exception
    {
        public EquipmentExistException()
        {

        }
        public EquipmentExistException(int id) : base(string.Format("Equipment Already Exist: {0}", id))
        {

        }
    }
}
