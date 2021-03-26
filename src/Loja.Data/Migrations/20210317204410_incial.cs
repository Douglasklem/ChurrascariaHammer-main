using Microsoft.EntityFrameworkCore.Migrations;

namespace Churrascaria.Data.Migrations
{
    public partial class incial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    VaiBeber = table.Column<bool>(type: "bit", nullable: false),
                    ValorConvidado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    ConvidadoId = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: true),
                    ValorFuncionario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VaiBeber = table.Column<bool>(type: "bit", nullable: false),
                    CascadeMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Convidados_ConvidadoId",
                        column: x => x.ConvidadoId,
                        principalTable: "Convidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VARCHAR80 = table.Column<string>(name: "VARCHAR(80)", type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ConvidadoId",
                table: "Funcionarios",
                column: "ConvidadoId",
                unique: true,
                filter: "[ConvidadoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_FuncionarioId",
                table: "Participantes",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Convidados");
        }
    }
}
