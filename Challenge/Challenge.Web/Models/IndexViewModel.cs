using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<EquipmentModel> Items { get; set; }
        public Pager Pager { get; set; }
        public string SearchString { get; set; }
    }
}