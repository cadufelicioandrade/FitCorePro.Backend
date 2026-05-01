using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitCorePro.Training.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelasTreinoPlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PLANO_TREINO_SEMANAL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANO_TREINO_SEMANAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TREINO_DIA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    DiaSemana = table.Column<int>(type: "integer", nullable: false),
                    PlanoTreinoSemanalId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TREINO_DIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TREINO_DIA_TB_PLANO_TREINO_SEMANAL_PlanoTreinoSemanalId",
                        column: x => x.PlanoTreinoSemanalId,
                        principalTable: "TB_PLANO_TREINO_SEMANAL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EXERCICIO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    TipoExercicio = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Serie = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Carga = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TreinoDiaId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EXERCICIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_EXERCICIO_TB_TREINO_DIA_TreinoDiaId",
                        column: x => x.TreinoDiaId,
                        principalTable: "TB_TREINO_DIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_EXERCICIO_TreinoDiaId",
                table: "TB_EXERCICIO",
                column: "TreinoDiaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TREINO_DIA_PlanoTreinoSemanalId",
                table: "TB_TREINO_DIA",
                column: "PlanoTreinoSemanalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_EXERCICIO");

            migrationBuilder.DropTable(
                name: "TB_TREINO_DIA");

            migrationBuilder.DropTable(
                name: "TB_PLANO_TREINO_SEMANAL");
        }
    }
}
