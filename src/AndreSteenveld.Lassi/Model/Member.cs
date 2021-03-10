using System;
using System.Collections.Generic;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class Member
    {
        public Member()
        {
            Loans = new HashSet<Loan>();
            Reservations = new HashSet<Reservation>();
        }

        public Guid MemberId { get; set; }
        public string UserId { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
