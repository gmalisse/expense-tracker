using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CategoryTypeId" },
                values: new object[,]
                {
                { 1, "Food", "Expenses related to meals and groceries", 1 },
                { 2, "Transportation", "Costs for public transport, fuel, and vehicle maintenance", 1 },
                { 3, "Entertainment", "Spending on movies, games, and leisure activities", 1 },
                { 4, "Health", "Medical expenses, insurance, and fitness-related costs", 1 },
                { 5, "Education", "School fees, courses, books, and learning materials", 1 },
                { 6, "Salary", "Main source of income from employment",2 },
                { 7, "Freelance", "Earnings from independent work and side projects", 2 },
                { 8, "Investments", "Profits from stocks, dividends, and other assets", 2 },
                { 9, "Gifts", "Money received as gifts or donations", 2 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }
    }
}
