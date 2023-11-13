using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turnos.Migrations
{
    public partial class Create_MedicoEspecialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoEspecialidades",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidades", x => new { x.IdMedico, x.IdEspecialidad });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidades_Especialidades_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidades_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidades_IdEspecialidad",
                table: "MedicoEspecialidades",
                column: "IdEspecialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoEspecialidades");
        }
    }
}
