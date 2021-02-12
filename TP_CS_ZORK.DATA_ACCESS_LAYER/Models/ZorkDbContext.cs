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
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Cells)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cells__PlayerId__373B3228");
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.ObjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__ObjectT__3A179ED3");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__PlayerI__3B0BC30C");
            });

            modelBuilder.Entity<ObjectsType>(entity =>
            {
                entity.ToTable("ObjectsType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CurrentCell)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CurrentCellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Players__Current__36470DEF");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapons__PlayerI__39237A9A");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapons__WeaponT__382F5661");
            });

            modelBuilder.Entity<WeaponsType>(entity =>
            {
                entity.ToTable("WeaponsType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
