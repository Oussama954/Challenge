using Challenge.Web.Validation;
using Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Challenge.Web.Models
{
    public class EquipmentModel
    {
        [Required]
        [Display(Name = "SerialNumber", ResourceType = typeof(Equipment))]
        public int SerialNumber { get; set; }
        [Required]
        [Display(Name = "Name", ResourceType = typeof(Equipment))]
        public string Name { get; set; }
        [Display(Name = "Picture", ResourceType = typeof(Equipment))]
        public HttpPostedFileBase Picture { get; set; }
        [Display(Name = "ControleDate", ResourceType = typeof(Equipment))]
        [CurrentDate(ErrorMessageResourceType = typeof(Equipment), ErrorMessageResourceName = "BeforeDateError")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NextControlDate { get; set; }
        public string PictureUrl { get; set; }
    }
}