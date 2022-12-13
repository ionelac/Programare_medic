using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_medic.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire_Serviciu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_consultatie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data_Programare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serviciu");
        }
    }
}
