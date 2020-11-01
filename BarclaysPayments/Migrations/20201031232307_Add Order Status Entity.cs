using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class AddOrderStatusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusID",
                table: "PAY_IELTSOrder",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PracticeMaterialsSent",
                table: "PAY_IELTSOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PracticeTestBooked",
                table: "PAY_IELTSOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAY_IELTSOrder_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_PAY_IELTSOrder_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder",
                column: "OrderStatusID",
                principalTable: "OrderStatus",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAY_IELTSOrder_OrderStatus_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_PAY_IELTSOrder_OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.DropColumn(
                name: "OrderStatusID",
                table: "PAY_IELTSOrder");

            migrationBuilder.DropColumn(
                name: "PracticeMaterialsSent",
                table: "PAY_IELTSOrder");

            migrationBuilder.DropColumn(
                name: "PracticeTestBooked",
                table: "PAY_IELTSOrder");
        }
    }
}
