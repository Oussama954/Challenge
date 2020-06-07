using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Model
{
    [Table("Picture")]
    public partial class Picture
    {
        [Key]
        public int SerialNumber { get; set; }
        public byte[] Content { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
