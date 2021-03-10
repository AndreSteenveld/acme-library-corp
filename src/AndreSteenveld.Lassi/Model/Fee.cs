using System;
using System.Collections.Generic;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class Fee
    {
        public int FeeId { get; set; }
        public int? LoanId { get; set; }
        public string Type { get; set; }
        public int? Amount { get; set; }
        public DateTime? Paid { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
