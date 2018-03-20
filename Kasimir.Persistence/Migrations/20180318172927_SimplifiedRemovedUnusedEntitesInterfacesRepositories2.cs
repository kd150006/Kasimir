using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class SimplifiedRemovedUnusedEntitesInterfacesRepositories2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CashDrawers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CashDrawers");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "CashDrawers",
                newName: "Balance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "CashDrawers",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CashDrawers",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CashDrawers",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }
    }
}
