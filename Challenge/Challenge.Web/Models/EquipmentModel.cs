using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Web.Models
{
    public class EquipmentModel
    {
        [Key]
        public decimal SerialNumber { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? NextControlDate { get; set; }

    }
}