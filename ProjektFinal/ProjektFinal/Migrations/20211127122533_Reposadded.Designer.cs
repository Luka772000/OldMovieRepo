﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektFinal.Models;

namespace ProjektFinal.Migrations
{
    [DbContext(typeof(FilmContext))]
    [Migration("20211127122533_Reposadded")]
    partial class Reposadded
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

                    b.Property<int>("ProdKucaID")
                        .HasColumnType("int");

                    b.Property<string>("Ukupnazarada")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FilmId");

                    b.HasIndex("ProdKucaID");

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

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<int>("GlumacID")
                        .HasColumnType("int");

                    b.Property<string>("ImeUloge")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UlogaID");

                    b.HasIndex("FilmID");

                    b.HasIndex("GlumacID");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("ProjektFinal.Models.FilmDetail", b =>
                {
                    b.HasOne("ProjektFinal.Models.ProdKuca", "ProdKuca")
                        .WithMany("FilmDetails")
                        .HasForeignKey("ProdKucaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdKuca");
                });

            modelBuilder.Entity("ProjektFinal.Models.Uloga", b =>
                {
                    b.HasOne("ProjektFinal.Models.FilmDetail", "FilmDetail")
                        .WithMany("Uloge")
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektFinal.Models.Glumac", "Glumac")
                        .WithMany("Uloge")
                        .HasForeignKey("GlumacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
