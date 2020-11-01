using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_IELTSTestType")]
    public class IELTSTestType
    {
        [StringLength(40)]
        public string IELTSTestTypeID { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsEnabled { get; set; }
    }
}
