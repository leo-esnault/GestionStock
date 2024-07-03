using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionStock.Migrations
{
    /// <inheritdoc />
    public partial class creationBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.Nom);
                });

            migrationBuilder.CreateTable(
                name: "Modeles",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DureeGarantie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeles", x => x.Reference);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Nom);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom_Batiment = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.Nom);
                    table.ForeignKey(
                        name: "FK_Salles_Batiments_Nom_Batiment",
                        column: x => x.Nom_Batiment,
                        principalTable: "Batiments",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesModeles",
                columns: table => new
                {
                    Reference_Modele = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom_Service = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesModeles", x => new { x.Reference_Modele, x.Nom_Service });
                    table.ForeignKey(
                        name: "FK_ServicesModeles_Modeles_Reference_Modele",
                        column: x => x.Reference_Modele,
                        principalTable: "Modeles",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesModeles_Services_Nom_Service",
                        column: x => x.Nom_Service,
                        principalTable: "Services",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emplacements",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom_Salle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reference_Modele = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplacements", x => new { x.Nom_Salle, x.Nom });
                    table.ForeignKey(
                        name: "FK_Emplacements_Modeles_Reference_Modele",
                        column: x => x.Reference_Modele,
                        principalTable: "Modeles",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emplacements_Salles_Nom_Salle",
                        column: x => x.Nom_Salle,
                        principalTable: "Salles",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiels",
                columns: table => new
                {
                    NumeroSerie = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateEntree = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    Nom_Salle = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nom_Emplacement = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Reference_Modele = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiels", x => x.NumeroSerie);
                    table.ForeignKey(
                        name: "FK_Materiels_Emplacements_Nom_Salle_Nom_Emplacement",
                        columns: x => new { x.Nom_Salle, x.Nom_Emplacement },
                        principalTable: "Emplacements",
                        principalColumns: new[] { "Nom_Salle", "Nom" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materiels_Modeles_Reference_Modele",
                        column: x => x.Reference_Modele,
                        principalTable: "Modeles",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materiels_Salles_Nom_Salle",
                        column: x => x.Nom_Salle,
                        principalTable: "Salles",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DemandesSAV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RMA = table.Column<int>(type: "int", nullable: true),
                    OrdreReservation = table.Column<int>(type: "int", nullable: true),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RaisonDemande = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    travaux_effectués = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumeroSerie_Materiel = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesSAV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemandesSAV_Materiels_NumeroSerie_Materiel",
                        column: x => x.NumeroSerie_Materiel,
                        principalTable: "Materiels",
                        principalColumn: "NumeroSerie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Demande = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_DemandesSAV_ID_Demande",
                        column: x => x.ID_Demande,
                        principalTable: "DemandesSAV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandesSAV_NumeroSerie_Materiel",
                table: "DemandesSAV",
                column: "NumeroSerie_Materiel");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ID_Demande",
                table: "Documents",
                column: "ID_Demande");

            migrationBuilder.CreateIndex(
                name: "IX_Emplacements_Reference_Modele",
                table: "Emplacements",
                column: "Reference_Modele");

            migrationBuilder.CreateIndex(
                name: "IX_Materiels_Nom_Salle_Nom_Emplacement",
                table: "Materiels",
                columns: new[] { "Nom_Salle", "Nom_Emplacement" });

            migrationBuilder.CreateIndex(
                name: "IX_Materiels_Reference_Modele",
                table: "Materiels",
                column: "Reference_Modele");

            migrationBuilder.CreateIndex(
                name: "IX_Salles_Nom_Batiment",
                table: "Salles",
                column: "Nom_Batiment");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesModeles_Nom_Service",
                table: "ServicesModeles",
                column: "Nom_Service");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "ServicesModeles");

            migrationBuilder.DropTable(
                name: "DemandesSAV");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Materiels");

            migrationBuilder.DropTable(
                name: "Emplacements");

            migrationBuilder.DropTable(
                name: "Modeles");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Batiments");
        }
    }
}
