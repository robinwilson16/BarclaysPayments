using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_BarclaysErrorCode")]
    public class BarclaysErrorCode
    {
        public int BarclaysErrorCodeID { get; set; }

        public int Code { get; set; }

        public bool Retry { get; set; }

        [StringLength(500)]
        [Required]
        public string Description { get; set; }
    }
}
