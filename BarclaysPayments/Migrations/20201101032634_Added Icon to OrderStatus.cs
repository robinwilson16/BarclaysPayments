using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AddedIcontoOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "PAY_OrderStatus",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatusID",
                table: "PAY_IELTSOrder",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID",
                principalTable: "PAY_OrderStatus",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "PAY_OrderStatus");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatusID",
                table: "PAY_IELTSOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID",
                principalTable: "PAY_OrderStatus",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
