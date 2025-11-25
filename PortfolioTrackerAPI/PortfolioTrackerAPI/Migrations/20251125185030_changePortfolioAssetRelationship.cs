using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class changePortfolioAssetRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetPortfolio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetPortfolio",
                columns: table => new
                {
                    AssetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfoliosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPortfolio", x => new { x.AssetsId, x.PortfoliosId });
                    table.ForeignKey(
                        name: "FK_AssetPortfolio_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetPortfolio_Portfolios_PortfoliosId",
                        column: x => x.PortfoliosId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetPortfolio_PortfoliosId",
                table: "AssetPortfolio",
                column: "PortfoliosId");
        }
    }
}
