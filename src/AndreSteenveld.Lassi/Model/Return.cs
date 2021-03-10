using System;
using System.Collections.Generic;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class Return
    {
        public int? LoanId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
