using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AddIELTSPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAY_IELTSPrice",
                columns: table => new
                {
                    IELTSPriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAY_IELTSPrice", x => x.IELTSPriceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAY_IELTSPrice");
        }
    }
}
