using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Table("fee")]
    public partial class Fee
    {
        [Key]
        [Column("fee_id")]
        public int FeeId { get; set; }
        [Column("loan_id")]
        public int? LoanId { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("amount")]
        public int? Amount { get; set; }
        [Column("paid", TypeName = "date")]
        public DateTime? Paid { get; set; }

        [ForeignKey(nameof(LoanId))]
        [InverseProperty("Fees")]
        public virtual Loan Loan { get; set; }
    }
}
