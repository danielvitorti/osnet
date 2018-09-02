using Microsoft.EntityFrameworkCore.Migrations;

namespace osnet.Migrations
{
    public partial class UpdateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Projeto_ProjetoId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "Cliente",
                newName: "Projetoid");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_ProjetoId",
                table: "Cliente",
                newName: "IX_Cliente_Projetoid");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "OrdemServico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Projetoid",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ProjetoId",
                table: "OrdemServico",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Projeto_Projetoid",
                table: "Cliente",
                column: "Projetoid",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Projeto_ProjetoId",
                table: "OrdemServico",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Projeto_Projetoid",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Projeto_ProjetoId",
                table: "OrdemServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_ProjetoId",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "OrdemServico");

            migrationBuilder.RenameColumn(
                name: "Projetoid",
                table: "Cliente",
                newName: "ProjetoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_Projetoid",
                table: "Cliente",
                newName: "IX_Cliente_ProjetoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Projeto_ProjetoId",
                table: "Cliente",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
