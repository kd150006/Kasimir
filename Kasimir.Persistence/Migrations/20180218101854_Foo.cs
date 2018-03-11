using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class Foo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrossPrice",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "BasketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasketHeaderId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketDetails_BasketHeaders_BasketHeaderId",
                        column: x => x.BasketHeaderId,
                        principalTable: "BasketHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_BasketHeaderId",
                table: "BasketDetails",
                column: "BasketHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDetails");

            migrationBuilder.AddColumn<double>(
                name: "GrossPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
