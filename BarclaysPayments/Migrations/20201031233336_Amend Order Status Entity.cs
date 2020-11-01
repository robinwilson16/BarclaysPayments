using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AmendOrderStatusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatusID",
                table: "PAY_IELTSOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID",
                principalTable: "PAY_OrderStatus",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatusID",
                table: "PAY_IELTSOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PAY_IELTSOrder_PAY_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID",
                principalTable: "PAY_OrderStatus",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
