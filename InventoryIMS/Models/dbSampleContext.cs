using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryIMS.Models
{
    public partial class dbSampleContext : DbContext
    {
        public dbSampleContext()
        {
        }

        public dbSampleContext(DbContextOptions<dbSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblLogin> TblLogins { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblSale> TblSales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=wjlp-1407;Initial Catalog=db.Sample;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblLogin__206D9170D5A973D8");

                entity.ToTable("tblLogin");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.Product_Id)
                    .HasName("PK__tblProdu__9834FBBAD51F23EA");

                entity.ToTable("tblProduct");

                entity.Property(e => e.Product_Id).HasColumnName("Product_Id");

                entity.Property(e => e.Product_Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.Product_Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Product_Price");

                entity.Property(e => e.Product_Qty).HasColumnName("Product_Qty");
            });

            modelBuilder.Entity<TblSale>(entity =>
            {
                entity.HasKey(e => e.ReceiptId)
                    .HasName("PK__tblSale__38B787EC213F801E");

                entity.ToTable("tblSale");

                entity.Property(e => e.ReceiptId).HasColumnName("Receipt_Id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

              /*  entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblSales)
                    .HasForeignKey(d => d.Product_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblSale__Product__2B3F6F97");*/
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
