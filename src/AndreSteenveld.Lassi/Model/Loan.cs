using System;
using System.Collections.Generic;
using NpgsqlTypes;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class Loan
    {
        public Loan()
        {
            Fees = new HashSet<Fee>();
        }

        public int LoanId { get; set; }
        public Guid? MemberId { get; set; }
        public int? BookId { get; set; }
        public NpgsqlRange<DateTime>? Period { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
