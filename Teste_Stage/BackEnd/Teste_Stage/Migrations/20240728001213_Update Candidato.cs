using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_Stage.Migrations
{
    public partial class UpdateCandidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Entrevistas_EntrevistaId",
                table: "Candidatos");

            migrationBuilder.AlterColumn<int>(
                name: "EntrevistaId",
                table: "Candidatos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Entrevistas_EntrevistaId",
                table: "Candidatos",
                column: "EntrevistaId",
                principalTable: "Entrevistas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Entrevistas_EntrevistaId",
                table: "Candidatos");

            migrationBuilder.AlterColumn<int>(
                name: "EntrevistaId",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Entrevistas_EntrevistaId",
                table: "Candidatos",
                column: "EntrevistaId",
                principalTable: "Entrevistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
