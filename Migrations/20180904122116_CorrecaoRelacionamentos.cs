using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace osnet.Migrations
{
    public partial class CorrecaoRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataTermino = table.Column<DateTime>(nullable: false),
                    dataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: false),
                    valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOrdemServico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOrdemServico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: false),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    cnpj = table.Column<string>(nullable: true),
                    enderecoCep = table.Column<string>(nullable: true),
                    enderecoRua = table.Column<string>(nullable: true),
                    enderecoNumero = table.Column<string>(nullable: true),
                    enderecoBairro = table.Column<string>(nullable: true),
                    enderecoCidade = table.Column<string>(nullable: true),
                    projetoIdid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Projeto_projetoIdid",
                        column: x => x.projetoIdid,
                        principalTable: "Projeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titulo = table.Column<string>(nullable: false),
                    resumo = table.Column<string>(nullable: true),
                    justificativa = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    resolucao = table.Column<string>(nullable: true),
                    observacao = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false),
                    TipoOrdemServicoId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataTermino = table.Column<DateTime>(nullable: false),
                    dataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServico_TipoOrdemServico_TipoOrdemServicoId",
                        column: x => x.TipoOrdemServicoId,
                        principalTable: "TipoOrdemServico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_projetoIdid",
                table: "Cliente",
                column: "projetoIdid");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ClienteId",
                table: "OrdemServico",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ProjetoId",
                table: "OrdemServico",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_ServicoId",
                table: "OrdemServico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_StatusId",
                table: "OrdemServico",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_TipoOrdemServicoId",
                table: "OrdemServico",
                column: "TipoOrdemServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipoOrdemServico");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
