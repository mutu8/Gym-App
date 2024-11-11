using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (TableExists(migrationBuilder, "Categoria"))
            {
                migrationBuilder.AlterColumn<string>(
                    name: "Nombre",
                    table: "Categoria",
                    type: "nvarchar(max)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(64)");
            }

            // Verificar si la tabla Articulo no existe antes de crearla
            if (!TableExists(migrationBuilder, "Articulo"))
            {
                migrationBuilder.CreateTable(
                    name: "Articulo",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        urlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        CategoriaId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Articulo", x => x.Id);
                        table.ForeignKey(
                            name: "FK_Articulo_Categoria_CategoriaId",
                            column: x => x.CategoriaId,
                            principalTable: "Categoria",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });
            }

            // Verificar si el índice IX_Articulo_CategoriaId no existe antes de crearlo
            if (!IndexExists(migrationBuilder, "IX_Articulo_CategoriaId", "Articulo"))
            {
                migrationBuilder.CreateIndex(
                    name: "IX_Articulo_CategoriaId",
                    table: "Articulo",
                    column: "CategoriaId");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (TableExists(migrationBuilder, "Articulo"))
            {
                migrationBuilder.DropTable(
                    name: "Articulo");
            }

            if (TableExists(migrationBuilder, "Categoria"))
            {
                migrationBuilder.AlterColumn<string>(
                    name: "Nombre",
                    table: "Categoria",
                    type: "nvarchar(64)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(max)");
            }
        }

        private bool TableExists(MigrationBuilder migrationBuilder, string tableName)
        {
            var sql = $"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
            var result = migrationBuilder.Sql(sql).ToString();
            return !string.IsNullOrEmpty(result);
        }

        private bool IndexExists(MigrationBuilder migrationBuilder, string indexName, string tableName)
        {
            var sql = $"SELECT 1 FROM sys.indexes WHERE name = '{indexName}' AND object_id = OBJECT_ID('{tableName}')";
            var result = migrationBuilder.Sql(sql).ToString();
            return !string.IsNullOrEmpty(result);
        }
    }
}
