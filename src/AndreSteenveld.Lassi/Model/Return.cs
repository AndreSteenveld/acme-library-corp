using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Keyless]
    [Table("return")]
    public partial class Return
    {
        [Column("loan_id")]
        public int? LoanId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("note")]
        public string Note { get; set; }

        [ForeignKey(nameof(LoanId))]
        public virtual Loan Loan { get; set; }
    }
}
