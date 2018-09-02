using Microsoft.EntityFrameworkCore.Migrations;

namespace osnet.Migrations
{
    public partial class UpdateProject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdemServicoId",
                table: "OrdemServico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_OrdemServicoId",
                table: "OrdemServico",
                column: "OrdemServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_OrdemServico_OrdemServicoId",
                table: "OrdemServico",
                column: "OrdemServicoId",
                principalTable: "OrdemServico",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_OrdemServico_OrdemServicoId",
                table: "OrdemServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_OrdemServicoId",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "OrdemServicoId",
                table: "OrdemServico");
        }
    }
}
