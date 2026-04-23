using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitCorePro.Nutrition.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PLANO_SEMANAL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "character varying(355)", maxLength: 355, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANO_SEMANAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PLANO_SEMANAL_DIA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    PlanoSemanalId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    DiaSemana = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANO_SEMANAL_DIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PLANO_SEMANAL_DIA_TB_PLANO_SEMANAL_PlanoSemanalId",
                        column: x => x.PlanoSemanalId,
                        principalTable: "TB_PLANO_SEMANAL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_REFEICAO_PLANO_SEMANAL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Tipo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    PlanoSemanalDiaId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REFEICAO_PLANO_SEMANAL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_REFEICAO_PLANO_SEMANAL_TB_PLANO_SEMANAL_DIA_PlanoSemanal~",
                        column: x => x.PlanoSemanalDiaId,
                        principalTable: "TB_PLANO_SEMANAL_DIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALIMENTO_PLANO_SEMANAL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Gramas = table.Column<int>(type: "integer", nullable: false),
                    RefeicaoPlanoSemanalId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALIMENTO_PLANO_SEMANAL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ALIMENTO_PLANO_SEMANAL_TB_REFEICAO_PLANO_SEMANAL_Refeica~",
                        column: x => x.RefeicaoPlanoSemanalId,
                        principalTable: "TB_REFEICAO_PLANO_SEMANAL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALIMENTO_PLANO_SEMANAL_RefeicaoPlanoSemanalId",
                table: "TB_ALIMENTO_PLANO_SEMANAL",
                column: "RefeicaoPlanoSemanalId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PLANO_SEMANAL_DIA_PlanoSemanalId",
                table: "TB_PLANO_SEMANAL_DIA",
                column: "PlanoSemanalId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_REFEICAO_PLANO_SEMANAL_PlanoSemanalDiaId",
                table: "TB_REFEICAO_PLANO_SEMANAL",
                column: "PlanoSemanalDiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALIMENTO_PLANO_SEMANAL");

            migrationBuilder.DropTable(
                name: "TB_REFEICAO_PLANO_SEMANAL");

            migrationBuilder.DropTable(
                name: "TB_PLANO_SEMANAL_DIA");

            migrationBuilder.DropTable(
                name: "TB_PLANO_SEMANAL");
        }
    }
}
