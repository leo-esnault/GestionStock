using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using GestionStock.Models;
using Document = GestionStock.Models.Document;

namespace GestionStock.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Emplacement> Emplacements { get; set; }
        public DbSet<Materiel> Materiels { get; set; }
        public DbSet<DemandeSAV> DemandesSAV { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ServicesModele> ServicesModeles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Service
            modelBuilder.Entity<Service>()
                .HasKey(s => s.Nom);

            // Batiment
            modelBuilder.Entity<Batiment>()
                .HasKey(b => b.Nom);

            // Salle
            modelBuilder.Entity<Salle>()
                .HasKey(s => s.Nom);

            modelBuilder.Entity<Salle>()
                .HasOne(s => s.Batiment)
                .WithMany(b => b.Salles)
                .HasForeignKey(s => s.Nom_Batiment)
                .OnDelete(DeleteBehavior.Cascade);

            // Emplacement
            modelBuilder.Entity<Emplacement>()
                .HasKey(e => new { e.Nom_Salle, e.Nom });

            modelBuilder.Entity<Emplacement>()
                .HasOne(e => e.Salle)
                .WithMany(s => s.Emplacements)
                .HasForeignKey(e => e.Nom_Salle)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Emplacement>()
                .HasOne(e => e.Modele)
                .WithMany(m => m.Emplacements)
                .HasForeignKey(e => e.Reference_Modele)
                .OnDelete(DeleteBehavior.Restrict);

            // Modele
            modelBuilder.Entity<Modele>()
                .HasKey(m => m.Reference);

            // Materiel
            modelBuilder.Entity<Materiel>()
                .HasKey(m => m.NumeroSerie);

            modelBuilder.Entity<Materiel>()
                .HasOne(m => m.Salle)
                .WithMany(s => s.Materiels)
                .HasForeignKey(m => m.Nom_Salle)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Materiel>()
                .HasOne(m => m.Emplacement)
                .WithMany(e => e.Materiels)
                .HasForeignKey(m => new { m.Nom_Salle, m.Nom_Emplacement })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Materiel>()
                .HasOne(m => m.Modele)
                .WithMany(mo => mo.Materiels)
                .HasForeignKey(m => m.Reference_Modele)
                .OnDelete(DeleteBehavior.Restrict);

            // DemandeSAV
            modelBuilder.Entity<DemandeSAV>()
                .HasKey(d => d.ID);

            modelBuilder.Entity<DemandeSAV>()
                .HasOne(d => d.Materiel)
                .WithMany(m => m.DemandesSAV)
                .HasForeignKey(d => d.NumeroSerie_Materiel)
                .OnDelete(DeleteBehavior.Cascade);

            // Document
            modelBuilder.Entity<Document>()
                .HasKey(d => d.ID);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.DemandeSAV)
                .WithMany(ds => ds.Documents)
                .HasForeignKey(d => d.ID_Demande)
                .OnDelete(DeleteBehavior.Cascade);

            // ServicesModele (many-to-many)
            modelBuilder.Entity<ServicesModele>()
                .HasKey(sm => new { sm.Reference_Modele, sm.Nom_Service });

            modelBuilder.Entity<ServicesModele>()
                .HasOne(sm => sm.Modele)
                .WithMany(m => m.ServicesModeles)
                .HasForeignKey(sm => sm.Reference_Modele)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServicesModele>()
                .HasOne(sm => sm.Service)
                .WithMany(s => s.ServicesModeles)
                .HasForeignKey(sm => sm.Nom_Service)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}