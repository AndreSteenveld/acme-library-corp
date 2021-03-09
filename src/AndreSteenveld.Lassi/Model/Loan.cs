using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Table("loan")]
    public partial class Loan
    {
        public Loan()
        {
            Fees = new HashSet<Fee>();
        }

        [Key]
        [Column("loan_id")]
        public int LoanId { get; set; }
        [Column("member_id")]
        public Guid? MemberId { get; set; }
        [Column("book_id")]
        public int? BookId { get; set; }
        [Column("period", TypeName = "daterange")]
        public NpgsqlRange<DateTime>? Period { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("Loans")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(MemberId))]
        [InverseProperty("Loans")]
        public virtual Member Member { get; set; }
        [InverseProperty(nameof(Fee.Loan))]
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
