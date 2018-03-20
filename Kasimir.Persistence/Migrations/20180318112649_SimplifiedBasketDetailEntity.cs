using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class SimplifiedBasketDetailEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_Stocks_StockId",
                table: "BasketDetails");

            migrationBuilder.DropIndex(
                name: "IX_BasketDetails_StockId",
                table: "BasketDetails");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "BasketDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "BasketDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_StockId",
                table: "BasketDetails",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_Stocks_StockId",
                table: "BasketDetails",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
