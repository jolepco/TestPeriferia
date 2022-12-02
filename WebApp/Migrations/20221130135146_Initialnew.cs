using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Initialnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Polizas_PolizaId",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_PolizaId",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "PolizaId",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Polizas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_CiudadId",
                table: "Polizas",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polizas_Ciudades_CiudadId",
                table: "Polizas",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polizas_Ciudades_CiudadId",
                table: "Polizas");

            migrationBuilder.DropIndex(
                name: "IX_Polizas_CiudadId",
                table: "Polizas");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Polizas");

            migrationBuilder.AddColumn<int>(
                name: "PolizaId",
                table: "Ciudades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PolizaId",
                table: "Ciudades",
                column: "PolizaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Polizas_PolizaId",
                table: "Ciudades",
                column: "PolizaId",
                principalTable: "Polizas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
