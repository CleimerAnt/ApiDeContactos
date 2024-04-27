using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDeContactos.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAppellido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Contactos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Contactos");
        }
    }
}
