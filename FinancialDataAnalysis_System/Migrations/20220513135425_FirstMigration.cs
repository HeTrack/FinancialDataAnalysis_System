using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialDataAnalysis_System.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<int>(type: "int", nullable: false),
                    AbsoluteLiquid = table.Column<double>(type: "float", nullable: false),
                    CurrentLiquid = table.Column<double>(type: "float", nullable: false),
                    FastLiquid = table.Column<double>(type: "float", nullable: false),
                    SaleProfit = table.Column<double>(type: "float", nullable: false),
                    ActiveProfit = table.Column<double>(type: "float", nullable: false),
                    VneoborotProfit = table.Column<double>(type: "float", nullable: false),
                    CapitalProfit = table.Column<double>(type: "float", nullable: false),
                    Avtonomia = table.Column<double>(type: "float", nullable: false),
                    MobilActive = table.Column<double>(type: "float", nullable: false),
                    ManevrCapital = table.Column<double>(type: "float", nullable: false),
                    ZaemAndCapital = table.Column<double>(type: "float", nullable: false),
                    ObespOborotSredstv = table.Column<double>(type: "float", nullable: false),
                    Zrate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Finances_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Finances_OrganizationID",
                table: "Finances",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
