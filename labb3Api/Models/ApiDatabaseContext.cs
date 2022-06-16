using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace labb3Api.Models
{
    public partial class ApiDatabaseContext : DbContext
    {
        public ApiDatabaseContext()
        {
        }

        public ApiDatabaseContext(DbContextOptions<ApiDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Interest> Interest { get; set; }
        public virtual DbSet<Links> Links { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInterest> UserInterest { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interest>(entity =>
            {
                entity.Property(e => e.InterestId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Links>(entity =>
            {
                entity.HasKey(e => new { e.InterestId, e.InterestLink })
                    .HasName("Primary_Key_Links");

                entity.Property(e => e.InterestLink).HasMaxLength(300);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
                
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserInterest>(entity =>
            {
                entity.HasKey(e => new { e.InterestId, e.UserId })
                   .HasName("Primary_Key_UserInterest");


                entity.HasOne(d => d.Interest)
                    .WithMany()
                    .HasForeignKey(d => d.InterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInterest_Interest");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInterest_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
