using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class _13285075320985321093509723097 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceBasketHeaderId",
                table: "BasketHeaders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceBasketHeaderId",
                table: "BasketHeaders");
        }
    }
}
