using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Table("book")]
    public partial class Book
    {
        public Book()
        {
            Loans = new HashSet<Loan>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("isbn")]
        public string Isbn { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("location")]
        public string Location { get; set; }

        [InverseProperty(nameof(Loan.Book))]
        public virtual ICollection<Loan> Loans { get; set; }
        [InverseProperty(nameof(Reservation.Book))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
