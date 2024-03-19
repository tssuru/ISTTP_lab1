using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraryDomain.Model;

namespace LibraryInfrasrtructure;

public partial class DblibraryContext : DbContext
{
    public DblibraryContext()
    {
    }

    public DblibraryContext(DbContextOptions<DblibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrowing> Borrowings { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC\\SQLEXPRESS; Database=DBlibrary; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Author__70DAFC3401604559");

            entity.ToTable("Author");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BirthDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.DeathDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(36)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3DE0C207341BC1A7");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PublishedYear)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books.AuthorId");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_Books.PublisherId");
        });

        modelBuilder.Entity<Borrowing>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.BookId }).HasName("PK__Borrowin__7456C06C246EBB0A");

            entity.Property(e => e.BorrowDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.ReturnDate)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.Book).WithMany(p => p.Borrowings)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrowings.BookId");

            entity.HasOne(d => d.User).WithMany(p => p.Borrowings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrowings.UserId");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC07F93A5C9C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.GenreName)
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.HasMany(d => d.Books).WithMany(p => p.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenre",
                    r => r.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BookGenres_Books1"),
                    l => l.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BookGenres_Genres"),
                    j =>
                    {
                        j.HasKey("GenreId", "BookId");
                        j.ToTable("BookGenres");
                    });
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publishe__4C657FABAC459840");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__1788CC4C89287039");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(36)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
