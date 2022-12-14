using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_medic.Migrations
{
    public partial class MedicTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medic",
                table: "Serviciu");

            migrationBuilder.AddColumn<int>(
                name: "MedicID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_MedicID",
                table: "Serviciu",
                column: "MedicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Medic_MedicID",
                table: "Serviciu",
                column: "MedicID",
                principalTable: "Medic",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Medic_MedicID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_MedicID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "MedicID",
                table: "Serviciu");

            migrationBuilder.AddColumn<string>(
                name: "Medic",
                table: "Serviciu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
