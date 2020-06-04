using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.VO
{
    public class EquipmentVO
    {
        public decimal SerialNumber { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? NextControlDate { get; set; }
    }
}
