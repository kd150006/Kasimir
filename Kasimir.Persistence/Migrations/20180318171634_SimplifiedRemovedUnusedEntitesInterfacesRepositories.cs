using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kasimir.Persistence.Migrations
{
    public partial class SimplifiedRemovedUnusedEntitesInterfacesRepositories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashDrawers_MeansOfPayments_MeansOfPaymentId",
                table: "CashDrawers");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "MeansOfPayments");

            migrationBuilder.DropIndex(
                name: "IX_CashDrawers_MeansOfPaymentId",
                table: "CashDrawers");

            migrationBuilder.DropColumn(
                name: "MeansOfPaymentId",
                table: "CashDrawers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeansOfPaymentId",
                table: "CashDrawers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasketHeaderId = table.Column<int>(nullable: false),
                    DateOfTransaction = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TransactionType = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_BasketHeaders_BasketHeaderId",
                        column: x => x.BasketHeaderId,
                        principalTable: "BasketHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeansOfPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeansOfPayments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashDrawers_MeansOfPaymentId",
                table: "CashDrawers",
                column: "MeansOfPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_BasketHeaderId",
                table: "Journals",
                column: "BasketHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashDrawers_MeansOfPayments_MeansOfPaymentId",
                table: "CashDrawers",
                column: "MeansOfPaymentId",
                principalTable: "MeansOfPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
