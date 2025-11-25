using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class changePortfolioAssetKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioAssets",
                table: "PortfolioAssets");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioAssets_PortfolioId",
                table: "PortfolioAssets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PortfolioAssets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioAssets",
                table: "PortfolioAssets",
                columns: new[] { "PortfolioId", "AssetId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioAssets",
                table: "PortfolioAssets");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PortfolioAssets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioAssets",
                table: "PortfolioAssets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioAssets_PortfolioId",
                table: "PortfolioAssets",
                column: "PortfolioId");
        }
    }
}
