using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class FooFoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "BasketDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice",
                table: "BasketDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductSerialNumber",
                table: "BasketDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "BasketDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_ProductId",
                table: "BasketDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_StockId",
                table: "BasketDetails",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_Products_ProductId",
                table: "BasketDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_Stocks_StockId",
                table: "BasketDetails",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_Products_ProductId",
                table: "BasketDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_Stocks_StockId",
                table: "BasketDetails");

            migrationBuilder.DropIndex(
                name: "IX_BasketDetails_ProductId",
                table: "BasketDetails");

            migrationBuilder.DropIndex(
                name: "IX_BasketDetails_StockId",
                table: "BasketDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BasketDetails");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "BasketDetails");

            migrationBuilder.DropColumn(
                name: "ProductSerialNumber",
                table: "BasketDetails");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "BasketDetails");
        }
    }
}
