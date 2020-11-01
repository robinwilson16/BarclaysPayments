using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_OrderStatus")]
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<IELTSOrder> IELTSOrder { get; set; }
    }
}
