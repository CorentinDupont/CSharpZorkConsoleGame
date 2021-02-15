using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class ZorkDbContext : DbContext
    {
        public ZorkDbContext()
        {
        }

        public ZorkDbContext(DbContextOptions<ZorkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<Object> Objects { get; set; }
        public virtual DbSet<ObjectsType> ObjectsTypes { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponsType> WeaponsTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ZorkDb;Trusted_connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Cell>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Cells)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cells__PlayerId__178D7CA5");
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.ObjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__ObjectT__1A69E950");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__PlayerI__1B5E0D89");
            });

            modelBuilder.Entity<ObjectsType>(entity =>
            {
                entity.ToTable("ObjectsType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CurrentCell)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CurrentCellId)
                    .HasConstraintName("FK__Players__Current__1699586C");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapons__PlayerI__1975C517");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapons__WeaponT__1881A0DE");
            });

            modelBuilder.Entity<WeaponsType>(entity =>
            {
                entity.ToTable("WeaponsType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
