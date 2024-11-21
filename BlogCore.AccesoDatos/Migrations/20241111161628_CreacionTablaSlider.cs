using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CrearTablaSliderSiNoExiste(migrationBuilder);

            migrationBuilder.AlterColumn<string>(
                name: "urlImagen",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        private void CrearTablaSliderSiNoExiste(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Slider')
                BEGIN
                    CREATE TABLE Slider (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Nombre NVARCHAR(MAX) NOT NULL,
                        Estado NVARCHAR(MAX) NOT NULL,
                        urlImagen NVARCHAR(MAX) NOT NULL
                    )
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.AlterColumn<string>(
                name: "urlImagen",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
