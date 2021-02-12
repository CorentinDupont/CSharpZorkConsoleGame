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

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Object)
                    .HasForeignKey<Object>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__Id__123EB7A3");
            });

            modelBuilder.Entity<ObjectsType>(entity =>
            {
                entity.ToTable("ObjectsType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.CurrentCell)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CurrentCellId)
                    .HasConstraintName("FK__Players__Current__0E6E26BF");

                entity.HasOne(d => d.Objects)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.ObjectsId)
                    .HasConstraintName("FK__Players__Objects__10566F31");

                entity.HasOne(d => d.Weapons)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.WeaponsId)
                    .HasConstraintName("FK__Players__Weapons__0F624AF8");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<WeaponsType>(entity =>
            {
                entity.ToTable("WeaponsType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.WeaponsType)
                    .HasForeignKey<WeaponsType>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WeaponsType__Id__114A936A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
