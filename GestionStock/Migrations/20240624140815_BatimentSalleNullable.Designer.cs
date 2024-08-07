﻿// <auto-generated />
using System;
using GestionStock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionStock.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240624140815_BatimentSalleNullable")]
    partial class BatimentSalleNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionStock.Models.Batiment", b =>
                {
                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Nom");

                    b.ToTable("Batiments");
                });

            modelBuilder.Entity("GestionStock.Models.DemandeSAV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateDemande")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRetour")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroSerie_Materiel")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OrdreReservation")
                        .HasColumnType("int");

                    b.Property<int?>("RMA")
                        .HasColumnType("int");

                    b.Property<string>("RaisonDemande")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("travaux_effectués")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("NumeroSerie_Materiel");

                    b.ToTable("DemandesSAV");
                });

            modelBuilder.Entity("GestionStock.Models.Document", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ID_Demande")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ID_Demande");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("GestionStock.Models.Emplacement", b =>
                {
                    b.Property<string>("Nom_Salle")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("Reference_Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Nom_Salle", "Nom");

                    b.HasIndex("Reference_Modele");

                    b.ToTable("Emplacements");
                });

            modelBuilder.Entity("GestionStock.Models.Materiel", b =>
                {
                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateEntree")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<string>("Nom_Emplacement")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom_Salle")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Reference_Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NumeroSerie");

                    b.HasIndex("Reference_Modele");

                    b.HasIndex("Nom_Salle", "Nom_Emplacement");

                    b.ToTable("Materiels");
                });

            modelBuilder.Entity("GestionStock.Models.Modele", b =>
                {
                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DureeGarantie")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Reference");

                    b.ToTable("Modeles");
                });

            modelBuilder.Entity("GestionStock.Models.Salle", b =>
                {
                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom_Batiment")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Nom");

                    b.HasIndex("Nom_Batiment");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("GestionStock.Models.Service", b =>
                {
                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Nom");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("GestionStock.Models.ServicesModele", b =>
                {
                    b.Property<string>("Reference_Modele")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("Nom_Service")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("Reference_Modele", "Nom_Service");

                    b.HasIndex("Nom_Service");

                    b.ToTable("ServicesModeles");
                });

            modelBuilder.Entity("GestionStock.Models.DemandeSAV", b =>
                {
                    b.HasOne("GestionStock.Models.Materiel", "Materiel")
                        .WithMany("DemandesSAV")
                        .HasForeignKey("NumeroSerie_Materiel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materiel");
                });

            modelBuilder.Entity("GestionStock.Models.Document", b =>
                {
                    b.HasOne("GestionStock.Models.DemandeSAV", "DemandeSAV")
                        .WithMany("Documents")
                        .HasForeignKey("ID_Demande")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DemandeSAV");
                });

            modelBuilder.Entity("GestionStock.Models.Emplacement", b =>
                {
                    b.HasOne("GestionStock.Models.Salle", "Salle")
                        .WithMany("Emplacements")
                        .HasForeignKey("Nom_Salle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionStock.Models.Modele", "Modele")
                        .WithMany("Emplacements")
                        .HasForeignKey("Reference_Modele")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Modele");

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("GestionStock.Models.Materiel", b =>
                {
                    b.HasOne("GestionStock.Models.Salle", "Salle")
                        .WithMany("Materiels")
                        .HasForeignKey("Nom_Salle")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GestionStock.Models.Modele", "Modele")
                        .WithMany("Materiels")
                        .HasForeignKey("Reference_Modele")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestionStock.Models.Emplacement", "Emplacement")
                        .WithMany("Materiels")
                        .HasForeignKey("Nom_Salle", "Nom_Emplacement")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Emplacement");

                    b.Navigation("Modele");

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("GestionStock.Models.Salle", b =>
                {
                    b.HasOne("GestionStock.Models.Batiment", "Batiment")
                        .WithMany("Salles")
                        .HasForeignKey("Nom_Batiment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batiment");
                });

            modelBuilder.Entity("GestionStock.Models.ServicesModele", b =>
                {
                    b.HasOne("GestionStock.Models.Service", "Service")
                        .WithMany("ServicesModeles")
                        .HasForeignKey("Nom_Service")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestionStock.Models.Modele", "Modele")
                        .WithMany("ServicesModeles")
                        .HasForeignKey("Reference_Modele")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Modele");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GestionStock.Models.Batiment", b =>
                {
                    b.Navigation("Salles");
                });

            modelBuilder.Entity("GestionStock.Models.DemandeSAV", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("GestionStock.Models.Emplacement", b =>
                {
                    b.Navigation("Materiels");
                });

            modelBuilder.Entity("GestionStock.Models.Materiel", b =>
                {
                    b.Navigation("DemandesSAV");
                });

            modelBuilder.Entity("GestionStock.Models.Modele", b =>
                {
                    b.Navigation("Emplacements");

                    b.Navigation("Materiels");

                    b.Navigation("ServicesModeles");
                });

            modelBuilder.Entity("GestionStock.Models.Salle", b =>
                {
                    b.Navigation("Emplacements");

                    b.Navigation("Materiels");
                });

            modelBuilder.Entity("GestionStock.Models.Service", b =>
                {
                    b.Navigation("ServicesModeles");
                });
#pragma warning restore 612, 618
        }
    }
}
