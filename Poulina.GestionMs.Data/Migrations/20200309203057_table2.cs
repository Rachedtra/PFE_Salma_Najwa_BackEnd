using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionMs.Data.Migrations
{
    public partial class table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    IdCom = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.IdCom);
                });

            migrationBuilder.CreateTable(
                name: "demandes",
                columns: table => new
                {
                    IdInf = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demandes", x => x.IdInf);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    IdVote = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.IdVote);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategorie = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    demandesIdInf = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategorie);
                    table.ForeignKey(
                        name: "FK_Categories_demandes_demandesIdInf",
                        column: x => x.demandesIdInf,
                        principalTable: "demandes",
                        principalColumn: "IdInf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comm_Info",
                columns: table => new
                {
                    IdCinfo = table.Column<Guid>(nullable: false),
                    IdCom = table.Column<Guid>(nullable: false),
                    IdInf = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comm_Info", x => x.IdCinfo);
                    table.ForeignKey(
                        name: "FK_Comm_Info_demandes_IdCinfo",
                        column: x => x.IdCinfo,
                        principalTable: "demandes",
                        principalColumn: "IdInf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comm_Info_Commentaires_IdCom",
                        column: x => x.IdCom,
                        principalTable: "Commentaires",
                        principalColumn: "IdCom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comm_Vote",
                columns: table => new
                {
                    IdCVote = table.Column<Guid>(nullable: false),
                    IdCom = table.Column<Guid>(nullable: true),
                    IdVote = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comm_Vote", x => x.IdCVote);
                    table.ForeignKey(
                        name: "FK_Comm_Vote_Votes_IdCVote",
                        column: x => x.IdCVote,
                        principalTable: "Votes",
                        principalColumn: "IdVote",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comm_Vote_Commentaires_IdCom",
                        column: x => x.IdCom,
                        principalTable: "Commentaires",
                        principalColumn: "IdCom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dem_Categorie",
                columns: table => new
                {
                    IdCateg = table.Column<Guid>(nullable: false),
                    IdCategorie = table.Column<Guid>(nullable: false),
                    IdInf = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dem_Categorie", x => x.IdCateg);
                    table.UniqueConstraint("AK_Dem_Categorie_IdCategorie", x => x.IdCategorie);
                    table.ForeignKey(
                        name: "FK_Dem_Categorie_Categories_IdCateg",
                        column: x => x.IdCateg,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dem_Categorie_demandes_IdInf",
                        column: x => x.IdInf,
                        principalTable: "demandes",
                        principalColumn: "IdInf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sous_Categories",
                columns: table => new
                {
                    IdSC = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    CategorieFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sous_Categories", x => x.IdSC);
                    table.ForeignKey(
                        name: "FK_Sous_Categories_Categories_CategorieFK",
                        column: x => x.CategorieFK,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_demandesIdInf",
                table: "Categories",
                column: "demandesIdInf");

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Info_IdCom",
                table: "Comm_Info",
                column: "IdCom");

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Vote_IdCom",
                table: "Comm_Vote",
                column: "IdCom");

            migrationBuilder.CreateIndex(
                name: "IX_Dem_Categorie_IdInf",
                table: "Dem_Categorie",
                column: "IdInf");

            migrationBuilder.CreateIndex(
                name: "IX_Sous_Categories_CategorieFK",
                table: "Sous_Categories",
                column: "CategorieFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comm_Info");

            migrationBuilder.DropTable(
                name: "Comm_Vote");

            migrationBuilder.DropTable(
                name: "Dem_Categorie");

            migrationBuilder.DropTable(
                name: "Sous_Categories");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "demandes");
        }
    }
}
