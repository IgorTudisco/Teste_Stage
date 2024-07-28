using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_Stage.Migrations
{
    public partial class UpdateEndereço : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Enderecos_EnderecoId",
                table: "Candidatos");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Enderecos_EnderecoId",
                table: "Candidatos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Enderecos_EnderecoId",
                table: "Candidatos");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Enderecos_EnderecoId",
                table: "Candidatos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
