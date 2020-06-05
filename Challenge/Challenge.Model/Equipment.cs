namespace Challenge.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
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
