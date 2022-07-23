using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineerKA_1._0.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmissionSpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionSpareParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentSpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSpareParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewSpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewSpareParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutOfStockSpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutOfStockSpareParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedSpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedSpareParts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionSpareParts");

            migrationBuilder.DropTable(
                name: "CurrentSpareParts");

            migrationBuilder.DropTable(
                name: "NewSpareParts");

            migrationBuilder.DropTable(
                name: "OutOfStockSpareParts");

            migrationBuilder.DropTable(
                name: "ReceivedSpareParts");
        }
    }
}
