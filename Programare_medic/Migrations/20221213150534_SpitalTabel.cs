using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_medic.Migrations
{
    public partial class SpitalTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpitalID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spital",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireSpital = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spital", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_SpitalID",
                table: "Serviciu",
                column: "SpitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Spital_SpitalID",
                table: "Serviciu",
                column: "SpitalID",
                principalTable: "Spital",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Spital_SpitalID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Spital");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_SpitalID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "SpitalID",
                table: "Serviciu");
        }
    }
}
