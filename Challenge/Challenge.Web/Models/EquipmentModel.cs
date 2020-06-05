using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Challenge.Web.Models
{
    public class EquipmentModel
    {
        [Required]
        [Display(Name = "Serial Number")]
        public decimal SerialNumber { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Picture")]
        public HttpPostedFileBase Picture { get; set; }
        [Display(Name = "Controle Date")]
        public DateTime? NextControlDate { get; set; }
        public string PictureUrl { get;  set; }
    }
}