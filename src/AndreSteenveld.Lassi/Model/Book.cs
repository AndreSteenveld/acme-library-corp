using System;
using System.Collections.Generic;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    public partial class Book
    {
        public Book()
        {
            Loans = new HashSet<Loan>();
            Reservations = new HashSet<Reservation>();
        }

        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
