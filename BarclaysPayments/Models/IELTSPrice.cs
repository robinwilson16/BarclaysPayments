using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_IELTSPrice")]
    public class IELTSPrice
    {
        public int IELTSPriceID { get; set; }

        [Display(Name = "Price Code")]
        [StringLength(50)]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
