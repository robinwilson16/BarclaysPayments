using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class InitialVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAY_PaymentReason",
                columns: table => new
                {
                    PaymentReasonID = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAY_PaymentReason", x => x.PaymentReasonID);
                });

            migrationBuilder.CreateTable(
                name: "PAY_BarclaysPayment",
                columns: table => new
                {
                    BarclaysPaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniquePaymentRef = table.Column<Guid>(nullable: false),
                    PaymentURL = table.Column<string>(nullable: true),
                    PSPID = table.Column<string>(nullable: true),
                    ORDERID = table.Column<string>(maxLength: 40, nullable: false),
                    PaymentReasonID = table.Column<string>(maxLength: 40, nullable: false),
                    PaymentReasonOther = table.Column<string>(maxLength: 200, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENCY = table.Column<string>(nullable: true),
                    LANGUAGE = table.Column<string>(nullable: true),
                    CN = table.Column<string>(maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 200, nullable: true),
                    OWNERZIP = table.Column<string>(maxLength: 8, nullable: false),
                    OWNERADDRESS = table.Column<string>(maxLength: 200, nullable: false),
                    OWNERCTY = table.Column<string>(maxLength: 200, nullable: true),
                    OWNERTOWN = table.Column<string>(maxLength: 200, nullable: true),
                    OWNERTELNO = table.Column<string>(nullable: true),
                    SHASIGN = table.Column<string>(nullable: true),
                    TITLE = table.Column<string>(nullable: true),
                    BGCOLOR = table.Column<string>(nullable: true),
                    TXTCOLOR = table.Column<string>(nullable: true),
                    TBLBGCOLOR = table.Column<string>(nullable: true),
                    TBLTXTCOLOR = table.Column<string>(nullable: true),
                    BUTTONBGCOLOR = table.Column<string>(nullable: true),
                    BUTTONTXTCOLOR = table.Column<string>(nullable: true),
                    LOGO = table.Column<string>(nullable: true),
                    FONTTYPE = table.Column<string>(nullable: true),
                    ACCEPTURL = table.Column<string>(nullable: true),
                    DECLINEURL = table.Column<string>(nullable: true),
                    EXCEPTIONURL = table.Column<string>(nullable: true),
                    CANCELURL = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAY_BarclaysPayment", x => x.BarclaysPaymentID);
                    table.ForeignKey(
                        name: "FK_PAY_BarclaysPayment_PAY_PaymentReason_PaymentReasonID",
                        column: x => x.PaymentReasonID,
                        principalTable: "PAY_PaymentReason",
                        principalColumn: "PaymentReasonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAY_BarclaysPayment_PaymentReasonID",
                table: "PAY_BarclaysPayment",
                column: "PaymentReasonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAY_BarclaysPayment");

            migrationBuilder.DropTable(
                name: "PAY_PaymentReason");
        }
    }
}
