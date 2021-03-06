﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Migrations
{
    [DbContext(typeof(ZorkDbContext))]
    partial class ZorkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "French_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanMoveTo")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ItemRate")
                        .HasColumnType("int");

                    b.Property<int>("MonsterRate")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<bool?>("PlayerPresence")
                        .HasColumnType("bit");

                    b.Property<int>("PosX")
                        .HasColumnType("int");

                    b.Property<int>("PosY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("MissRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ObjectTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjectTypeId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.ObjectsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Heal")
                        .HasColumnType("int");

                    b.Property<int>("MissRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ObjectsType");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CellId")
                        .HasColumnType("int");

                    b.Property<int>("Exp")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("MaxHp")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WeaponTypeId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.WeaponsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("MissRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("WeaponsType");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Cell", b =>
                {
                    b.HasOne("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Player", "Player")
                        .WithMany("Cells")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Cells__PlayerId__178D7CA5");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Object", b =>
                {
                    b.HasOne("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.ObjectsType", "ObjectType")
                        .WithMany("Objects")
                        .HasForeignKey("ObjectTypeId")
                        .HasConstraintName("FK__Objects__ObjectT__1A69E950")
                        .IsRequired();

                    b.HasOne("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Player", "Player")
                        .WithMany("Objects")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Objects__PlayerI__1B5E0D89")
                        .IsRequired();

                    b.Navigation("ObjectType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Player", b =>
                {
                    b.HasOne("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Cell", null)
                        .WithMany("Players")
                        .HasForeignKey("CellId");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Weapon", b =>
                {
                    b.HasOne("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Player", "Player")
                        .WithMany("Weapons")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Weapons__PlayerI__1975C517")
                        .IsRequired();

                    b.HasOne("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.WeaponsType", "WeaponType")
                        .WithMany("Weapons")
                        .HasForeignKey("WeaponTypeId")
                        .HasConstraintName("FK__Weapons__WeaponT__1881A0DE")
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("WeaponType");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Cell", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.ObjectsType", b =>
                {
                    b.Navigation("Objects");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.Player", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Objects");

                    b.Navigation("Weapons");
                });

            modelBuilder.Entity("TP_CS_ZORK.DATA_ACCESS_LAYER.Models.WeaponsType", b =>
                {
                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
