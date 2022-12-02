using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Initialaddfielpermitida_correccionmodelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polizas_Ciudades_CiudadId",
                table: "Polizas");

            migrationBuilder.RenameColumn(
                name: "CiudadId",
                table: "Polizas",
                newName: "ciudadId");

            migrationBuilder.RenameIndex(
                name: "IX_Polizas_CiudadId",
                table: "Polizas",
                newName: "IX_Polizas_ciudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polizas_Ciudades_ciudadId",
                table: "Polizas",
                column: "ciudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polizas_Ciudades_ciudadId",
                table: "Polizas");

            migrationBuilder.RenameColumn(
                name: "ciudadId",
                table: "Polizas",
                newName: "CiudadId");

            migrationBuilder.RenameIndex(
                name: "IX_Polizas_ciudadId",
                table: "Polizas",
                newName: "IX_Polizas_CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polizas_Ciudades_CiudadId",
                table: "Polizas",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
