using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_PaymentReason")]
    public class PaymentReason
    {
        [StringLength(40)]
        public string PaymentReasonID { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<BarclaysPayment> BarclaysPayment { get; set; }
    }
}
