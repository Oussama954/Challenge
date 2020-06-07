using System;

namespace Challenge.VO
{
    public class EquipmentVO
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? NextControlDate { get; set; }
    }
}
