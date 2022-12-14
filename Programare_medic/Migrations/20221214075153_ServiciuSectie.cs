using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_medic.Migrations
{
    public partial class ServiciuSectie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireSectie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiciuSectie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciuID = table.Column<int>(type: "int", nullable: false),
                    SectieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciuSectie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiciuSectie_Sectie_SectieID",
                        column: x => x.SectieID,
                        principalTable: "Sectie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciuSectie_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiciuSectie_SectieID",
                table: "ServiciuSectie",
                column: "SectieID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciuSectie_ServiciuID",
                table: "ServiciuSectie",
                column: "ServiciuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiciuSectie");

            migrationBuilder.DropTable(
                name: "Sectie");
        }
    }
}
