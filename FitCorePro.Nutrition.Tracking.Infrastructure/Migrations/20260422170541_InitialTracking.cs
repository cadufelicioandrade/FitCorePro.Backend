using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALIMENTO_BASE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "character varying(355)", maxLength: 355, nullable: false),
                    Gramas = table.Column<int>(type: "integer", nullable: false),
                    Calorias = table.Column<double>(type: "double precision", nullable: false),
                    Carboidratos = table.Column<double>(type: "double precision", nullable: false),
                    Proteinas = table.Column<double>(type: "double precision", nullable: false),
                    Gorduras = table.Column<double>(type: "double precision", nullable: false),
                    Fibras = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALIMENTO_BASE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_DIETA_DIA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataDieta = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DIETA_DIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_REFEICAO_DIETA_DIA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordem = table.Column<int>(type: "integer", nullable: false),
                    DietaDiaId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REFEICAO_DIETA_DIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_REFEICAO_DIETA_DIA_TB_DIETA_DIA_DietaDiaId",
                        column: x => x.DietaDiaId,
                        principalTable: "TB_DIETA_DIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALIMENTO_DIETA_DIA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "character varying(355)", maxLength: 355, nullable: false),
                    RefeicaoDietaDiaId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    QuantidadeGramas = table.Column<int>(type: "integer", nullable: false),
                    Calorias = table.Column<double>(type: "double precision", nullable: false),
                    Carboidratos = table.Column<double>(type: "double precision", nullable: false),
                    Proteinas = table.Column<double>(type: "double precision", nullable: false),
                    Gorduras = table.Column<double>(type: "double precision", nullable: false),
                    Fibras = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALIMENTO_DIETA_DIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ALIMENTO_DIETA_DIA_TB_REFEICAO_DIETA_DIA_RefeicaoDietaDi~",
                        column: x => x.RefeicaoDietaDiaId,
                        principalTable: "TB_REFEICAO_DIETA_DIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALIMENTO_DIETA_DIA_RefeicaoDietaDiaId",
                table: "TB_ALIMENTO_DIETA_DIA",
                column: "RefeicaoDietaDiaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_REFEICAO_DIETA_DIA_DietaDiaId",
                table: "TB_REFEICAO_DIETA_DIA",
                column: "DietaDiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALIMENTO_BASE");

            migrationBuilder.DropTable(
                name: "TB_ALIMENTO_DIETA_DIA");

            migrationBuilder.DropTable(
                name: "TB_REFEICAO_DIETA_DIA");

            migrationBuilder.DropTable(
                name: "TB_DIETA_DIA");
        }
    }
}
