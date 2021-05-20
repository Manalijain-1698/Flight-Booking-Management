using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingsAPI.Models
{
    public partial class FlightManagementSystemContext : DbContext
    {
        public FlightManagementSystemContext()
        {
        }

        public FlightManagementSystemContext(DbContextOptions<FlightManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airlines> Airlines { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Userdetails> Userdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-331;Database=FlightManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airlines>(entity =>
            {
                entity.Property(e => e.Airlinesid).HasColumnName("airlinesid");

                entity.Property(e => e.Airlinename)
                    .HasColumnName("airlinename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.Bookingid)
                    .HasName("PK__Bookings__C6D30705B77D9C8F");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Flightid).HasColumnName("flightid");

                entity.Property(e => e.NoOfSeats).HasColumnName("no_of_seats");

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Flightid)
                    .HasConstraintName("FK__Bookings__flight__44FF419A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Bookings__userid__440B1D61");
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.Flightid)
                    .HasName("PK__Flights__0E06BA3AD9C01372");

                entity.Property(e => e.Flightid).HasColumnName("flightid");

                entity.Property(e => e.Airlineid).HasColumnName("airlineid");

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartureTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.Airlineid)
                    .HasConstraintName("FK__Flights__airline__412EB0B6");
            });

            modelBuilder.Entity<Userdetails>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Userdeta__CBA1B25788D70B86");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
