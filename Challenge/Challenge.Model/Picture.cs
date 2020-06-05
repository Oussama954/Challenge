namespace Challenge.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Picture")]
    public partial class Picture
    {
        public byte[] Content { get; set; }

        [Key]
        public int SerialNumber { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
