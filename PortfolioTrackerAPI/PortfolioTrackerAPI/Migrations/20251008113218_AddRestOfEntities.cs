using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRestOfEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetPortfolio_Asset_AssetsId",
                table: "AssetPortfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioAssets_Asset_AssetId",
                table: "PortfolioAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceCache_Asset_AssetId",
                table: "PriceCache");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Asset_AssetId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Portfolios_PortfolioId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceCache",
                table: "PriceCache");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "PriceCache",
                newName: "PriceCaches");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_PortfolioId",
                table: "Transactions",
                newName: "IX_Transactions_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AssetId",
                table: "Transactions",
                newName: "IX_Transactions_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceCache_AssetId",
                table: "PriceCaches",
                newName: "IX_PriceCaches_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceCaches",
                table: "PriceCaches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPortfolio_Assets_AssetsId",
                table: "AssetPortfolio",
                column: "AssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioAssets_Assets_AssetId",
                table: "PortfolioAssets",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCaches_Assets_AssetId",
                table: "PriceCaches",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Assets_AssetId",
                table: "Transactions",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Portfolios_PortfolioId",
                table: "Transactions",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetPortfolio_Assets_AssetsId",
                table: "AssetPortfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioAssets_Assets_AssetId",
                table: "PortfolioAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceCaches_Assets_AssetId",
                table: "PriceCaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Assets_AssetId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Portfolios_PortfolioId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceCaches",
                table: "PriceCaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "PriceCaches",
                newName: "PriceCache");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Asset");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_PortfolioId",
                table: "Transaction",
                newName: "IX_Transaction_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AssetId",
                table: "Transaction",
                newName: "IX_Transaction_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceCaches_AssetId",
                table: "PriceCache",
                newName: "IX_PriceCache_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceCache",
                table: "PriceCache",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPortfolio_Asset_AssetsId",
                table: "AssetPortfolio",
                column: "AssetsId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioAssets_Asset_AssetId",
                table: "PortfolioAssets",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceCache_Asset_AssetId",
                table: "PriceCache",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Asset_AssetId",
                table: "Transaction",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Portfolios_PortfolioId",
                table: "Transaction",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
