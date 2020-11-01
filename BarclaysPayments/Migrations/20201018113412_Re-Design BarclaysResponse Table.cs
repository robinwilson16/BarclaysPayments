using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarclaysPayments.Migrations
{
    public partial class ReDesignBarclaysResponseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "RemoteAddr",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "RemoteHost",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "PAY_BarclaysResponse");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "PAY_BarclaysResponse",
                newName: "ORDERID");

            migrationBuilder.AddColumn<string>(
                name: "AAVADDRESS",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ACCEPTANCE",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AMOUNT",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BRAND",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CARDNO",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CN",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COMPLUS",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CURRENCY",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PAY_BarclaysResponse",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PAY_BarclaysResponse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ED",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NCERROR",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAYID",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAYMENT_REFERENCE",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PM",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRXDATE",
                table: "PAY_BarclaysResponse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PAY_BarclaysResponse",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PAY_BarclaysResponse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AAVADDRESS",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "ACCEPTANCE",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "AMOUNT",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "BRAND",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "CARDNO",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "CN",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "COMPLUS",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "CURRENCY",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "ED",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "HostName",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "NCERROR",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "PAYID",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "PAYMENT_REFERENCE",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "PM",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "TRXDATE",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PAY_BarclaysResponse");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PAY_BarclaysResponse");

            migrationBuilder.RenameColumn(
                name: "ORDERID",
                table: "PAY_BarclaysResponse",
                newName: "OrderID");

            migrationBuilder.AddColumn<string>(
                name: "ClientID",
                table: "PAY_BarclaysResponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteAddr",
                table: "PAY_BarclaysResponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteHost",
                table: "PAY_BarclaysResponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalAmount",
                table: "PAY_BarclaysResponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionDate",
                table: "PAY_BarclaysResponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatus",
                table: "PAY_BarclaysResponse",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
