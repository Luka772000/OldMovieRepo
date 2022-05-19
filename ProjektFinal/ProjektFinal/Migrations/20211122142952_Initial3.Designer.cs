﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektFinal.Models;

namespace ProjektFinal.Migrations
{
    [DbContext(typeof(FilmContext))]
    [Migration("20211122142952_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjektFinal.Models.FilmDetail", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GodinaProdukcije")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("ProdKucaID")
                        .HasColumnType("bigint");

                    b.Property<int?>("ProdKucaKucaID")
                        .HasColumnType("int");

                    b.Property<string>("Ukupnazarada")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FilmId");

                    b.HasIndex("ProdKucaKucaID");

                    b.ToTable("FilmDetails");
                });

            modelBuilder.Entity("ProjektFinal.Models.Glumac", b =>
                {
                    b.Property<int>("GlumacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GodinaRodenja")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImeGlumca")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MjestoRodenja")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GlumacID");

                    b.ToTable("Glumci");
                });

            modelBuilder.Entity("ProjektFinal.Models.ProdKuca", b =>
                {
                    b.Property<int>("KucaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImeKuce")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KucaID");

                    b.ToTable("ProdKuce");
                });

            modelBuilder.Entity("ProjektFinal.Models.Uloga", b =>
                {
                    b.Property<int>("UlogaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FilmDetailFilmId")
                        .HasColumnType("int");

                    b.Property<long>("FilmID")
                        .HasColumnType("bigint");

                    b.Property<long>("GlumacID")
                        .HasColumnType("bigint");

                    b.Property<int?>("GlumacID1")
                        .HasColumnType("int");

                    b.Property<string>("ImeUloge")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UlogaID");

                    b.HasIndex("FilmDetailFilmId");

                    b.HasIndex("GlumacID1");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("ProjektFinal.Models.FilmDetail", b =>
                {
                    b.HasOne("ProjektFinal.Models.ProdKuca", "ProdKuca")
                        .WithMany("FilmDetails")
                        .HasForeignKey("ProdKucaKucaID");

                    b.Navigation("ProdKuca");
                });

            modelBuilder.Entity("ProjektFinal.Models.Uloga", b =>
                {
                    b.HasOne("ProjektFinal.Models.FilmDetail", "FilmDetail")
                        .WithMany("Uloge")
                        .HasForeignKey("FilmDetailFilmId");

                    b.HasOne("ProjektFinal.Models.Glumac", "Glumac")
                        .WithMany("Uloge")
                        .HasForeignKey("GlumacID1");

                    b.Navigation("FilmDetail");

                    b.Navigation("Glumac");
                });

            modelBuilder.Entity("ProjektFinal.Models.FilmDetail", b =>
                {
                    b.Navigation("Uloge");
                });

            modelBuilder.Entity("ProjektFinal.Models.Glumac", b =>
                {
                    b.Navigation("Uloge");
                });

            modelBuilder.Entity("ProjektFinal.Models.ProdKuca", b =>
                {
                    b.Navigation("FilmDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
