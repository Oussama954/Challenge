using System;

namespace Challenge.Business.Exceptions
{
    public class EquipmentExistException : Exception
    {
        public EquipmentExistException()
        {
        }

        public EquipmentExistException(int id) : base($"Equipment Already Exist: {id}")
        {
        }
    }
}