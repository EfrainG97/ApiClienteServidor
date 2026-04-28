using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClienteServidor.Migrations
{
    /// <inheritdoc />
    public partial class ImplementPatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Persona",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Persona",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 5, "Descripción de Juan Pérez" });

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 3, "Descripción de María Gómez" });

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 7, "Descripción de Carlos Rodríguez" });

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 2, "Descripción de Ana López" });

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cantidad", "Descripcion" },
                values: new object[] { 4, "Descripción de Luis Fernández" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Persona");
        }
    }
}
