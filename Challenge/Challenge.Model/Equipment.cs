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
        [Column(TypeName = "numeric")]
        public decimal SerialNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? NextControlDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PictureId { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
