using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_PaymentStatus")]
    public class PaymentStatus
    {
        public int PaymentStatusID { get; set; }

        public int Code { get; set; }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }
    }
}
