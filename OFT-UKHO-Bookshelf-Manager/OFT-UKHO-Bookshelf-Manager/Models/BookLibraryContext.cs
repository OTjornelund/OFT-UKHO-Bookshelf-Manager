using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OFT_UKHO_Bookshelf_Manager.Models
{
    public partial class BookLibraryContext : DbContext
    {
        public BookLibraryContext()
        {
        }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Copy> Copies { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: To protect potentially sensitive information in your connection string, you should move it out of source code...
            // You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
            // For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=oft-book-library.database.windows.net; Database=BookLibrary; User Id=libraryadmin; Password=Admin123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn10, "UQ_Books_ISBN10")
                    .IsUnique();

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn10)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ISBN10");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Copies)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Copies_BookId_Books_Id");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_CopyId_Copies_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_UserId_Users_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
