using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_BarclaysPayment")]
    public class BarclaysPayment
    {
        public int BarclaysPaymentID { get; set; }
        public Guid UniquePaymentRef { get; set; }
        public string PaymentURL { get; set; }
        public string PSPID { get; set; }

        [Display(Name = "Payment Reference")]
        [StringLength(40)]
        [Required]
        public string ORDERID { get; set; }

        [Display(Name = "Reason for Payment")]
        [StringLength(40)]
        [Required]
        public string PaymentReasonID { get; set; }

        [Display(Name = "Other Reason Details")]
        [StringLength(200)]
        public string PaymentReasonOther { get; set; }

        [Display(Name = "Amount To Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AMOUNT { get; set; }
        public string CURRENCY { get; set; }
        public string LANGUAGE { get; set; }

        [Display(Name = "Customer or Company Name")]
        [StringLength(100)]
        [Required]
        public string CN { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string Forename { get; set; }

        [Display(Name = "Email")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [Display(Name = "Post Code")]
        [StringLength(8)]
        public string OWNERZIP { get; set; }

        [Display(Name = "Address 1")]
        [StringLength(200)]
        public string OWNERADDRESS { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(200)]
        public string OWNERCTY { get; set; }

        [Display(Name = "Address 3")]
        [StringLength(200)]
        public string OWNERTOWN { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string OWNERTELNO { get; set; }
        public string SHASIGN { get; set; }
        public string TITLE { get; set; }
        public string BGCOLOR { get; set; }
        public string TXTCOLOR { get; set; }
        public string TBLBGCOLOR { get; set; }
        public string TBLTXTCOLOR { get; set; }
        public string BUTTONBGCOLOR { get; set; }
        public string BUTTONTXTCOLOR { get; set; }
        public string LOGO { get; set; }
        public string FONTTYPE { get; set; }
        public string ACCEPTURL { get; set; }
        public string DECLINEURL { get; set; }
        public string EXCEPTIONURL { get; set; }
        public string CANCELURL { get; set; }

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

        public PaymentReason PaymentReason { get; set; }
    }
}
