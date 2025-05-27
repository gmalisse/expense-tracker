using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Transactions",
            columns: new[] { "Id", "Description", "Amount", "Date", "Fixed", "CategoryId" },
            values: new object[,]
            {
                { 1, "Grocery shopping", 150.75m, new DateTime(2025, 05, 27, 10, 0, 0, DateTimeKind.Utc), false, 1 },
                { 2, "Electricity bill", 90.50m, new DateTime(2025, 05, 20, 15, 0, 0, DateTimeKind.Utc), true, 1 },
                { 3, "Salary", 3500.00m, new DateTime(2025, 05, 25, 08, 0, 0, DateTimeKind.Utc), true, 2 },
                { 4, "Freelance project", 1200.00m, new DateTime(2025, 05, 22, 14, 30, 0, DateTimeKind.Utc), false, 2 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            {
                migrationBuilder.DeleteData(
                    table: "Transactions",
                    keyColumn: "Id",
                    keyValues: new object[] { 1, 2, 3, 4 });
            }
        }
    }
}
