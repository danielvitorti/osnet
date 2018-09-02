using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace osnet.Migrations
{
    public partial class Projeto_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataCadastro",
                table: "OrdemServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataInicio",
                table: "OrdemServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataTermino",
                table: "OrdemServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "OrdemServico",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Projetoid",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataTermino = table.Column<DateTime>(nullable: false),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projeto_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Projetoid",
                table: "Cliente",
                column: "Projetoid");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ProjetoId",
                table: "Projeto",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Projeto_Projetoid",
                table: "Cliente",
                column: "Projetoid",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Projeto_Projetoid",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Projetoid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "dataCadastro",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "dataInicio",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "dataTermino",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "observacao",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "Projetoid",
                table: "Cliente");
        }
    }
}
