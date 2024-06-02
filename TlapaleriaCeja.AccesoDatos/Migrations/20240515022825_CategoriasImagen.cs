using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TlapaleriaCeja.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CategoriasImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Categorias");
        }
    }
}
