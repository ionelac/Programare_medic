using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_medic.Migrations
{
    public partial class ImagineSpital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagine",
                table: "Spital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagine",
                table: "Spital");
        }
    }
}
