using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        [Display(Name = "Customer or Company Name")]
        [StringLength(100)]
        [Required]
        public string CustomerName { get; set; }

        [Display(Name = "Surname")]
        [StringLength(100)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Forename")]
        [StringLength(100)]
        [Required]
        public string Forename { get; set; }

        public Guid UniquePaymentRef { get; set; }

        [Display(Name = "Payment Reference")]
        [StringLength(40)]
        [Required]
        public string OnlineBookingRefNo { get; set; }

        [Display(Name = "Reason for Payment")]
        [StringLength(40)]
        [Required]
        public string PaymentReasonCode { get; set; }

        [Display(Name = "Reason for Payment")]
        [StringLength(40)]
        [Required]
        public string PaymentReasonName { get; set; }

        [Display(Name = "Other Reason Details")]
        [StringLength(200)]
        public string PaymentReasonOther { get; set; }

        [Display(Name = "Amount To Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountDue { get; set; }

        [Display(Name = "Email")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string TelNumber { get; set; }

        [Display(Name = "Address 1")]
        [StringLength(200)]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(200)]
        public string Address2 { get; set; }

        [Display(Name = "Address 3")]
        [StringLength(200)]
        public string Address3 { get; set; }

        [Display(Name = "Post Code")]
        [StringLength(8)]
        public string PostCode { get; set; }

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

        public int? ResponseID { get; set; }

        [Display(Name = "Amount Paid")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? AmountPaid { get; set; }

        public int? ResponseStatusCode { get; set; }

        [Display(Name = "Status")]
        [StringLength(200)]
        public string ResponseStatusName { get; set; }

        public string BarclaysErrorCode { get; set; }

        [Display(Name = "BarclaysError")]
        [StringLength(500)]
        public string BarclaysErrorName { get; set; }

        public bool? BarclaysErrorRetry { get; set; }

        public string AddressOK { get; set; }

        public string ConfirmationID { get; set; }

        public string BarclaysPaymentID { get; set; }

        public string CardType { get; set; }

        public string CardNo { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? PaymentDate { get; set; }

        public string IPAddress { get; set; }

        public int? IELTSOrderID { get; set; }

        [Display(Name = "IELTS Test")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IELTSTestAmount { get; set; }

        [Display(Name = "IELTS TestDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IELTSTestDate { get; set; }

        [Display(Name = "Practice Test")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PracticeTestAmount { get; set; }

        [Display(Name = "Practice Materials")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PracticeMaterialsAmount { get; set; }

        public string TestTypeCode { get; set; }

        [Display(Name = "Test Type")]
        [StringLength(150)]
        public string TestTypeName { get; set; }

        public int? OrderStatusCode { get; set; }

        [Display(Name = "Order Status")]
        [StringLength(50)]
        public string OrderStatusName { get; set; }

        public bool? PracticeTestBooked { get; set; }

        public bool? PracticeMaterialsSent { get; set; }

        [Display(Name = "Notes")]
        public int? NumNotes { get; set; }
    }
}
