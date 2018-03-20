using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class AddedTransactionTypeToBasketHeader2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                table: "BasketHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                table: "BasketHeaders",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
