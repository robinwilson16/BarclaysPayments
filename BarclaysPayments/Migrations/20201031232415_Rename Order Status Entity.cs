using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class RenameOrderStatusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAY_IELTSOrder_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus");

            migrationBuilder.RenameTable(
                name: "OrderStatus",
                newName: "PAY_OrderStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAY_OrderStatus",
                table: "PAY_OrderStatus",
                column: "OrderStatusID");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAY_OrderStatus",
                table: "PAY_OrderStatus");

            migrationBuilder.RenameTable(
                name: "PAY_OrderStatus",
                newName: "OrderStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus",
                column: "OrderStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_PAY_IELTSOrder_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID",
                principalTable: "OrderStatus",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
