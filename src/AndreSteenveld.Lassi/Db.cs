using System;
using System.ComponentModel.DataAnnotations.Schema;
using AndreSteenveld.Lassi.Model;
using JsonApiDotNetCore.Resources;
using Microsoft.EntityFrameworkCore;

namespace AndreSteenveld.Lassi {
    public partial class LibraryContext {
        partial void OnModelCreatingPartial(ModelBuilder builder){

            builder.Entity<Author>( e => {
                e.HasKey( e => e.Id );
                e.Property( e => e.Id ).HasColumnName( "author_id" );
            });

            builder.Entity<Book>( e => {
                e.HasKey( e => e.Id );
                e.Property( e => e.Id ).HasColumnName( "book_id" );
            });

            builder.Entity<Fee>( e => {
                e.HasKey( e => e.Id );
                e.Property( e => e.Id ).HasColumnName( "fee_id" );
            });

            builder.Entity<Loan>( e => {
                e.HasKey( e => e.Id );
                e.Property( e => e.Id ).HasColumnName( "loan_id" );
            });

            builder.Entity<Reservation>( e => {
                e.HasKey( e => e.Id );
                e.Property( e => e.Id ).HasColumnName( "reservation_id" );
            });


        }

    }

}

namespace AndreSteenveld.Lassi.Model {

    public partial class Author : IIdentifiable<int> {

        public int Id { get => AuthorId; set => AuthorId = value; }

        [NotMapped]
        public string StringId { get => Id.ToString(); set => Id = Int32.Parse(value); }

    }

    public partial class Book : IIdentifiable<int> { 

        public int Id { get => BookId; set => BookId = value; }

        [NotMapped]
        public string StringId { get => Id.ToString(); set => Id = Int32.Parse(value); }

    }
    
    public partial class Fee : IIdentifiable<int> { 

        public int Id { get => FeeId; set => FeeId = value; }

        [NotMapped]
        public string StringId { get => Id.ToString(); set => Id = Int32.Parse(value); }

    }

    public partial class Loan : IIdentifiable<int> { 

        public int Id { get => LoanId; set => LoanId = value; }

        [NotMapped]
        public string StringId { get => Id.ToString(); set => Id = Int32.Parse(value); }

    }
    
    public partial class Member : IIdentifiable<Guid> { 

        public Guid Id { get => MemberId; set => MemberId = value; }

        [NotMapped]
        public string StringId { get => Id.ToString(); set => Id = Guid.Parse(value); }

    }

    public partial class Reservation : IIdentifiable<int> { 

        public int Id { get => ReservationId; set => ReservationId = value; }

        [NotMapped]
        public string StringId { get => Id.ToString(); set => Id = Int32.Parse(value); }

    }

}