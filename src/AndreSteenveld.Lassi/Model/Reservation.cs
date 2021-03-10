using System;
using System.Collections.Generic;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? BookId { get; set; }
        public Guid? MemberId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
