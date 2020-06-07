using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Model
{
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNumber { get; set; }

        [Required] 
        public string Name { get; set; }

        public DateTime? NextControlDate { get; set; }
        public virtual Picture Picture { get; set; }
    }
}