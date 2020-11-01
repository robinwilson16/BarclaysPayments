using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class PaymentStatusaddCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "PAY_PaymentStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PAY_PaymentStatus_Code",
                table: "PAY_PaymentStatus",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PAY_PaymentStatus_Code",
                table: "PAY_PaymentStatus");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PAY_PaymentStatus");
        }
    }
}
