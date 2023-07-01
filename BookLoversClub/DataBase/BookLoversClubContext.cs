using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookLoversClub.DataBase
{
    public partial class BookLoversClubContext : DbContext
    {
        public BookLoversClubContext()
        {
        }

        public BookLoversClubContext(DbContextOptions<BookLoversClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookOrder> BookOrders { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<PickPoint> PickPoints { get; set; } = null!;
        public virtual DbSet<Production> Productions { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = DESKTOP-KIC205I\\SQLEXPRESS; Database=BookLoversClub; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IdProduction).HasColumnName("idProduction");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhotoImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaleCost).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdProductionNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdProduction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Production");
            });

            modelBuilder.Entity<BookOrder>(entity =>
            {
                entity.HasKey(e => new { e.IdBook, e.IdOrder });

                entity.ToTable("BookOrder");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BookOrders)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookOrder_Book");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.BookOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookOrder_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("Order");

                entity.Property(e => e.Number).ValueGeneratedNever();

                entity.Property(e => e.IdPickPoint).HasColumnName("idPickPoint");

                entity.Property(e => e.OrderCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OrderCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.SummSaleCost).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdPickPointNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPickPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PickPoint");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");
            });

            modelBuilder.Entity<PickPoint>(entity =>
            {
                entity.ToTable("PickPoint");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.ToTable("Production");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
