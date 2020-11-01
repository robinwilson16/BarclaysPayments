using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AddBarclaysResponseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAY_BarclaysResponse",
                columns: table => new
                {
                    BarclaysResponseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<string>(nullable: true),
                    TransactionStatus = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<string>(nullable: true),
                    ClientID = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<string>(nullable: true),
                    RemoteAddr = table.Column<string>(nullable: true),
                    RemoteHost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAY_BarclaysResponse", x => x.BarclaysResponseID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAY_BarclaysResponse");
        }
    }
}
