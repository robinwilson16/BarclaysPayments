using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_IELTSOrder")]
    public class IELTSOrder
    {
        public int IELTSOrderID { get; set; }

        public int BarclaysPaymentID { get; set; }

        [Display(Name = "IELTS Test")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal IELTSTestAmount { get; set; }

        [Display(Name = "IELTS TestDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? IELTSTestDate { get; set; }

        public string TestType { get; set; }

        [Display(Name = "Practice Test")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PracticeTestAmount { get; set; }

        [Display(Name = "Practice Materials")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PracticeMaterialsAmount { get; set; }

        public int? OrderStatusID { get; set; }

        public bool PracticeTestBooked { get; set; }

        public bool PracticeMaterialsSent { get; set; }

        public BarclaysPayment BarclaysPayment { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
