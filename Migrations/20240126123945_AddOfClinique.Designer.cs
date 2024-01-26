﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eHealth.Api.Data;

#nullable disable

namespace eHealth.Api.Migrations
{
    [DbContext(typeof(EhealthDbContext))]
    [Migration("20240126123945_AddOfClinique")]
    partial class AddOfClinique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("eHealth.Api.Models.Clinique", b =>
                {
                    b.Property<int>("IdClinique")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdClinique");

                    b.ToTable("cliniques");
                });

            modelBuilder.Entity("eHealth.Api.Models.Medecin", b =>
                {
                    b.Property<int>("IdMedecin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CliniqueIdClinique")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdMedecin");

                    b.HasIndex("CliniqueIdClinique");

                    b.ToTable("medecins");

                    b.HasData(
                        new
                        {
                            IdMedecin = 1,
                            Nom = "La Monica",
                            Prenom = "Giuliano",
                            Specialite = "Dentiste"
                        },
                        new
                        {
                            IdMedecin = 2,
                            Nom = "Barry",
                            Prenom = "Thierno",
                            Specialite = "Orthopediste"
                        },
                        new
                        {
                            IdMedecin = 3,
                            Nom = "Nkenda",
                            Prenom = "Florent",
                            Specialite = "Orl"
                        });
                });

            modelBuilder.Entity("eHealth.Api.Models.Medecin", b =>
                {
                    b.HasOne("eHealth.Api.Models.Clinique", null)
                        .WithMany("medecins")
                        .HasForeignKey("CliniqueIdClinique");
                });

            modelBuilder.Entity("eHealth.Api.Models.Clinique", b =>
                {
                    b.Navigation("medecins");
                });
#pragma warning restore 612, 618
        }
    }
}
