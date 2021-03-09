using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Table("reservation")]
    public partial class Reservation
    {
        [Key]
        [Column("reservation_id")]
        public int ReservationId { get; set; }
        [Column("book_id")]
        public int? BookId { get; set; }
        [Column("member_id")]
        public Guid? MemberId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("Reservations")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(MemberId))]
        [InverseProperty("Reservations")]
        public virtual Member Member { get; set; }
    }
}
