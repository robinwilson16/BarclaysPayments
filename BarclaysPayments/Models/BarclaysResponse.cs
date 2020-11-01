using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_BarclaysResponse")]
    public class BarclaysResponse
    {
        public int BarclaysResponseID { get; set; }

        [StringLength(50)]
        public string ORDERID { get; set; }
        public string PAYID { get; set; }
        public string PAYMENT_REFERENCE { get; set; }
        public string TRXDATE { get; set; }
        public int STATUS { get; set; }
        public string NCERROR { get; set; }

        [StringLength(50)]
        public string AAVADDRESS { get; set; }

        [StringLength(10)]
        public string ACCEPTANCE { get; set; }

        [Display(Name = "Amount Paid")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AMOUNT { get; set; }

        [StringLength(20)]
        public string BRAND { get; set; }

        [StringLength(16)]
        public string CARDNO { get; set; }

        [StringLength(100)]
        public string CN { get; set; }

        [StringLength(20)]
        public string COMPLUS { get; set; }

        [StringLength(10)]
        public string CURRENCY { get; set; }

        [StringLength(4)]
        public string ED { get; set; }

        [Display(Name = "Customer IP Address")]
        [StringLength(45)]
        public string IP { get; set; }

        public string PM { get; set; }

        [Display(Name = "System IP Address")]
        [StringLength(45)]
        public string IpAddress { get; set; }

        [StringLength(100)]
        public string HostName { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        [StringLength(40)]
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Updated By")]
        [StringLength(40)]
        public string UpdatedBy { get; set; }
    }
}
