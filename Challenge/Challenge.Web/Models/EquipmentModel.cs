using Challenge.Web.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Challenge.Web.Models
{
    public class EquipmentModel
    {
        [Required]
        [Display(Name = "Serial Number")]
        public int SerialNumber { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Picture")]
        public HttpPostedFileBase Picture { get; set; }
        [Display(Name = "Controle Date")]
        [CurrentDate(ErrorMessage = "Date must be after current date")]
        [DataType(DataType.Date),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime? NextControlDate { get; set; }
        public string PictureUrl { get; set; }
    }
}