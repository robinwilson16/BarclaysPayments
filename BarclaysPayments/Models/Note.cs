using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Models
{
    [Table("PAY_Note")]
    public class Note
    {
        public int NoteID { get; set; }
        public int TransactionID { get; set; }
        [Display(Name = "Note")]
        public string NoteText { get; set; }

        [Display(Name = "Show As Alert?")]
        public bool IsAlert { get; set; }

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
