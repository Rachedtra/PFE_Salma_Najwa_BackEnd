using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.GestionMs.Data.Migrations
{
    public partial class app1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategorie = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategorie);
                });

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
                name: "Demande_Information",
                columns: table => new
                {
                    IdInf = table.Column<Guid>(nullable: false),
                    IdDomain = table.Column<Guid>(nullable: false),
                    Titre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demande_Information", x => x.IdInf);
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
                name: "Sous_Categories",
                columns: table => new
                {
                    IdSC = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    FK_SousCategorie = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sous_Categories", x => x.IdSC);
                    table.ForeignKey(
                        name: "FK_Sous_Categories_Categories_FK_SousCategorie",
                        column: x => x.FK_SousCategorie,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Comm_Info_Commentaires_IdCom",
                        column: x => x.IdCom,
                        principalTable: "Commentaires",
                        principalColumn: "IdCom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comm_Info_Demande_Information_IdInf",
                        column: x => x.IdInf,
                        principalTable: "Demande_Information",
                        principalColumn: "IdInf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dem_Categorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdInf = table.Column<Guid>(nullable: false),
                    IdCategorie = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dem_Categorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dem_Categorie_Categories_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dem_Categorie_Demande_Information_IdInf",
                        column: x => x.IdInf,
                        principalTable: "Demande_Information",
                        principalColumn: "IdInf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comm_Vote",
                columns: table => new
                {
                    IDCVote = table.Column<Guid>(nullable: false),
                    IdCom = table.Column<Guid>(nullable: false),
                    IdVote = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comm_Vote", x => x.IDCVote);
                    table.ForeignKey(
                        name: "FK_Comm_Vote_Commentaires_IdCom",
                        column: x => x.IdCom,
                        principalTable: "Commentaires",
                        principalColumn: "IdCom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comm_Vote_Votes_IdVote",
                        column: x => x.IdVote,
                        principalTable: "Votes",
                        principalColumn: "IdVote",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Info_IdCom",
                table: "Comm_Info",
                column: "IdCom");

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Info_IdInf",
                table: "Comm_Info",
                column: "IdInf");

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Vote_IdCom",
                table: "Comm_Vote",
                column: "IdCom");

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Vote_IdVote",
                table: "Comm_Vote",
                column: "IdVote");

            migrationBuilder.CreateIndex(
                name: "IX_Dem_Categorie_IdCategorie",
                table: "Dem_Categorie",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Dem_Categorie_IdInf",
                table: "Dem_Categorie",
                column: "IdInf");

            migrationBuilder.CreateIndex(
                name: "IX_Sous_Categories_FK_SousCategorie",
                table: "Sous_Categories",
                column: "FK_SousCategorie");
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
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Demande_Information");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
