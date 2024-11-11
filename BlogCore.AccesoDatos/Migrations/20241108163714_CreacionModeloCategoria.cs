using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Verificar si la tabla Categoria no existe antes de crearla
            if (!TableExists(migrationBuilder, "Categoria"))
            {
                migrationBuilder.CreateTable(
                    name: "Categoria",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Nombre = table.Column<int>(type: "nvarchar", nullable: false),
                        Orden = table.Column<int>(type: "int", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Categoria", x => x.Id);
                    });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");
        }

        private bool TableExists(MigrationBuilder migrationBuilder, string tableName)
        {
            var sql = $"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
            var result = migrationBuilder.Sql(sql).ToString();
            return !string.IsNullOrEmpty(result);
        }
    }
}
