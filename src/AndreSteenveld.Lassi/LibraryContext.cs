using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AndreSteenveld.Lassi.Model;

#nullable disable

namespace AndreSteenveld.Lassi
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<IsbnAuthor> IsbnAuthors { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Return> Returns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=library;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Isbn).HasColumnName("isbn");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.ToTable("fee");

                entity.Property(e => e.FeeId).HasColumnName("fee_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.Paid)
                    .HasColumnType("date")
                    .HasColumnName("paid");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("fee_loan_id_fkey");
            });

            modelBuilder.Entity<IsbnAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("isbn_author");

                entity.HasIndex(e => new { e.Isbn, e.AuthorId }, "isbn_author_isbn_author_id_key")
                    .IsUnique();

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Isbn).HasColumnName("isbn");

                entity.HasOne(d => d.Author)
                    .WithMany()
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("isbn_author_author_id_fkey");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("loan");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.Period)
                    .HasColumnType("daterange")
                    .HasColumnName("period");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("loan_book_id_fkey");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("loan_member_id_fkey");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("reservation_book_id_fkey");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("reservation_member_id_fkey");
            });

            modelBuilder.Entity<Return>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("return");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.HasOne(d => d.Loan)
                    .WithMany()
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("return_loan_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
