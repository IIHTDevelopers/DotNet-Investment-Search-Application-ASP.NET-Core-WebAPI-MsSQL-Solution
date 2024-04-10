using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.OpenApi.Models;

namespace InvestmentSearchApplication.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CurrentTradingPrice = table.Column<decimal>(nullable: false),
                    ClosingPrice = table.Column<decimal>(nullable: false),
                    TodayHigh = table.Column<decimal>(nullable: false),
                    TodayLow = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekLow = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekHigh = table.Column<decimal>(nullable: false),
                    FaceValue = table.Column<decimal>(nullable: false),
                    NumberOfShares = table.Column<int>(nullable: false),
                    MarketCapitalization = table.Column<decimal>(nullable: false),
                    Cash = table.Column<decimal>(nullable: false),
                    Debt = table.Column<decimal>(nullable: false),
                    EnterpriseValue = table.Column<decimal>(nullable: false),
                    DividendYield = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(nullable: false),
                    OverallRating = table.Column<decimal>(nullable: false),
                    OwnershipReviewsCount = table.Column<int>(nullable: false),
                    ValuationReviewsCount = table.Column<int>(nullable: false),
                    EfficiencyReviewsCount = table.Column<int>(nullable: false),
                    FinancialsReviewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Ratings_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwotAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(nullable: false),
                    Strengths = table.Column<string>(nullable: true),
                    Weaknesses = table.Column<string>(nullable: true),
                    Opportunities = table.Column<string>(nullable: true),
                    Threats = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwotAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwotAnalyses_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwotAnalyses_StockId",
                table: "SwotAnalyses",
                column: "StockId");

            migrationBuilder.InsertData(
         table: "Stocks",
         columns: new[] { "Name", "CurrentTradingPrice", "ClosingPrice", "TodayHigh", "TodayLow", "FiftyTwoWeekLow", "FiftyTwoWeekHigh", "FaceValue", "NumberOfShares", "MarketCapitalization", "Cash", "Debt", "EnterpriseValue", "DividendYield" },
         values: new object[,]
         {
            { "Company A", 100.00m, 98.50m, 105.00m, 95.50m, 90.00m, 110.00m, 10.00m, 1000000, 100000000.00m, 20000000.00m, 5000000.00m, 25000000.00m, 2.5m },
            { "Company B", 75.50m, 76.00m, 80.00m, 70.50m, 65.00m, 85.00m, 8.00m, 800000, 60000000.00m, 15000000.00m, 4000000.00m, 20000000.00m, 1.8m },
            { "Company C", 50.25m, 52.00m, 55.75m, 48.50m, 45.00m, 58.00m, 5.00m, 500000, 25000000.00m, 10000000.00m, 3000000.00m, 15000000.00m, 1.2m },
            { "Company D", 40.00m, 39.75m, 42.50m, 38.25m, 35.00m, 45.00m, 4.00m, 400000, 16000000.00m, 8000000.00m, 2000000.00m, 12000000.00m, 1.0m },
            { "Company E", 90.75m, 92.00m, 95.50m, 87.25m, 80.00m, 100.00m, 12.00m, 1200000, 108000000.00m, 30000000.00m, 6000000.00m, 36000000.00m, 2.0m }
         });

            // Insert data into SWOTAnalyses table
            migrationBuilder.InsertData(
                table: "SWOTAnalyses",
                columns: new[] { "StockId", "Strengths", "Weaknesses", "Opportunities", "Threats" },
                values: new object[,]
                {
            { 1, "Strong brand presence", "High debt", "Expansion into new markets", "Intense competition" },
            { 2, "Innovative products", "Limited cash reserves", "Partnership opportunities", "Regulatory challenges" },
            { 3, "Experienced management team", "Declining market share", "Product diversification", "Economic downturn" },
            { 4, "Low production costs", "Poor brand recognition", "Global expansion", "Technological disruptions" },
            { 5, "High customer satisfaction", "Heavy reliance on key suppliers", "Strategic alliances", "Legal and regulatory risks" }
                });

            // Insert data into Ratings table
            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "StockId", "OverallRating", "OwnershipReviewsCount", "ValuationReviewsCount", "EfficiencyReviewsCount", "FinancialsReviewsCount" },
                values: new object[,]
                {
            { 1, 4.3m, 20, 15, 25, 18 },
            { 2, 4.0m, 18, 12, 22, 16 },
            { 3, 4.5m, 22, 20, 28, 21 },
            { 4, 3.8m, 15, 10, 18, 12 },
            { 5, 4.2m, 25, 18, 30, 20 }
                });

            migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "Email", "Password" },
               values: new object[,]
               {
            { "example@kanini.com", "Kanini@123" },
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "SwotAnalyses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
