﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Server.Migrations
{
    [DbContext(typeof(SajtContext))]
    [Migration("20220104125225_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Igra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GodinaIzlaska")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Zanr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Igra");
                });

            modelBuilder.Entity("Models.Nagrada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("IgraFKID")
                        .HasColumnType("int");

                    b.Property<string>("Kategorija")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NazivOrg")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("IgraFKID");

                    b.ToTable("Nagrada");
                });

            modelBuilder.Entity("Models.Ocena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Gameplay")
                        .HasColumnType("int");

                    b.Property<int>("Graphics")
                        .HasColumnType("int");

                    b.Property<int?>("IgraFKID")
                        .HasColumnType("int");

                    b.Property<int>("Music")
                        .HasColumnType("int");

                    b.Property<int>("Story")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IgraFKID");

                    b.ToTable("Ocena");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CenaIgre")
                        .HasColumnType("int");

                    b.Property<int>("IDProdavnice")
                        .HasColumnType("int");

                    b.Property<int?>("IgraFKID")
                        .HasColumnType("int");

                    b.Property<int>("KolicinaProdatih")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IgraFKID");

                    b.ToTable("Prodavnica");
                });

            modelBuilder.Entity("Models.Nagrada", b =>
                {
                    b.HasOne("Models.Igra", "IgraFK")
                        .WithMany("Nagrade")
                        .HasForeignKey("IgraFKID");

                    b.Navigation("IgraFK");
                });

            modelBuilder.Entity("Models.Ocena", b =>
                {
                    b.HasOne("Models.Igra", "IgraFK")
                        .WithMany("Ocene")
                        .HasForeignKey("IgraFKID");

                    b.Navigation("IgraFK");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.HasOne("Models.Igra", "IgraFK")
                        .WithMany("Prodavnice")
                        .HasForeignKey("IgraFKID");

                    b.Navigation("IgraFK");
                });

            modelBuilder.Entity("Models.Igra", b =>
                {
                    b.Navigation("Nagrade");

                    b.Navigation("Ocene");

                    b.Navigation("Prodavnice");
                });
#pragma warning restore 612, 618
        }
    }
}