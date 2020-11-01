using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AddIELTSTestTypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAY_IELTSTestType",
                columns: table => new
                {
                    IELTSTestTypeID = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAY_IELTSTestType", x => x.IELTSTestTypeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAY_IELTSTestType");
        }
    }
}
