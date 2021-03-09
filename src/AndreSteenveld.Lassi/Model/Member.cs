using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AndreSteenveld.Lassi.Model
{
    [Table("member")]
    public partial class Member
    {
        public Member()
        {
            Loans = new HashSet<Loan>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [Column("member_id")]
        public Guid MemberId { get; set; }
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("expiration_date", TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        [InverseProperty(nameof(Loan.Member))]
        public virtual ICollection<Loan> Loans { get; set; }
        [InverseProperty(nameof(Reservation.Member))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
