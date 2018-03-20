using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class AddedQuantityToBasketDetailEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSerialNumber",
                table: "BasketDetails");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BasketDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BasketDetails");

            migrationBuilder.AddColumn<string>(
                name: "ProductSerialNumber",
                table: "BasketDetails",
                nullable: true);
        }
    }
}
