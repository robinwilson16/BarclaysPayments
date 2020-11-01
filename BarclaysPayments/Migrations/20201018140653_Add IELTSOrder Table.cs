using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AddIELTSOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Forename",
                table: "PAY_BarclaysPayment",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "PAY_BarclaysPayment",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PAY_IELTSOrder",
                columns: table => new
                {
                    IELTSOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarclaysPaymentID = table.Column<int>(nullable: false),
                    IELTSTestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IELTSTestDate = table.Column<DateTime>(nullable: false),
                    PracticeTestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PracticeMaterialsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAY_IELTSOrder", x => x.IELTSOrderID);
                    table.ForeignKey(
                        name: "FK_PAY_IELTSOrder_PAY_BarclaysPayment_BarclaysPaymentID",
                        column: x => x.BarclaysPaymentID,
                        principalTable: "PAY_BarclaysPayment",
                        principalColumn: "BarclaysPaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAY_IELTSOrder_BarclaysPaymentID",
                table: "PAY_IELTSOrder",
                column: "BarclaysPaymentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAY_IELTSOrder");

            migrationBuilder.DropColumn(
                name: "Forename",
                table: "PAY_BarclaysPayment");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "PAY_BarclaysPayment");
        }
    }
}
