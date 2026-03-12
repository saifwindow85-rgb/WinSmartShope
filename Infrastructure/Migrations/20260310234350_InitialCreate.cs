using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    ThirdName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(700)", maxLength: 700, nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountStatements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(700)", maxLength: 700, nullable: false),
                    AccountStatementID = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtPages_AccountStatements_AccountStatementID",
                        column: x => x.AccountStatementID,
                        principalTable: "AccountStatements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtPageId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[Quantity] * [Price]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementItems_DebtPages_DebtPageId",
                        column: x => x.DebtPageId,
                        principalTable: "DebtPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, "New York", "john@example.com", "John", "Smith", "770100111", "Ali", "Ahmed" },
                    { 2, "Los Angeles", "alice@example.com", "Alice", "Johnson", "770100222", "Ali", "Ahmed" },
                    { 3, "Chicago", "michael@example.com", "Michael", "Brown", "770100333", "Ali", "Ahmed" },
                    { 4, "Houston", "emma@example.com", "Emma", "Davis", "770100444", "Ali", "Ahmed" },
                    { 5, "Philadelphia", "david@example.com", "David", "Wilson", "770100555", "Ali", "Ahmed" }
                });

            migrationBuilder.InsertData(
                table: "AccountStatements",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "IsClosed", "IsPaid" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 24, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5492), 1, "January Purchases", false, false },
                    { 2, new DateTime(2026, 3, 1, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5523), 1, "February Purchases", false, false },
                    { 3, new DateTime(2026, 2, 27, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5528), 2, "January Purchases", true, true },
                    { 4, new DateTime(2026, 3, 3, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5533), 3, "February Purchases", false, false },
                    { 5, new DateTime(2026, 3, 4, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5537), 4, "March Purchases", false, false },
                    { 6, new DateTime(2026, 3, 6, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5541), 5, "March Purchases", false, false },
                    { 7, new DateTime(2026, 3, 6, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5546), 5, "March Purchases", true, true }
                });

            migrationBuilder.InsertData(
                table: "DebtPages",
                columns: new[] { "Id", "AccountStatementID", "CreatedAt", "Description", "IsClosed", "IsPaid" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 2, 24, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2847), "Page 1 - Vegetables", false, false },
                    { 2, 1, new DateTime(2026, 2, 24, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2862), "Page 2 - Beverages", false, false },
                    { 3, 2, new DateTime(2026, 3, 1, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2867), "Page 1 - Snacks", false, false },
                    { 4, 2, new DateTime(2026, 3, 1, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2871), "Page 2 - Dairy", false, false },
                    { 5, 3, new DateTime(2026, 2, 27, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2876), "Page 1 - Household Items", true, true },
                    { 6, 3, new DateTime(2026, 2, 27, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2880), "Page 2 - Cleaning Supplies", true, true },
                    { 7, 4, new DateTime(2026, 3, 3, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2885), "Page 1 - Fruits", false, false },
                    { 8, 4, new DateTime(2026, 3, 3, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2889), "Page 2 - Vegetables", false, false },
                    { 9, 5, new DateTime(2026, 3, 4, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2893), "Page 1 - Snacks", false, false },
                    { 10, 5, new DateTime(2026, 3, 4, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2897), "Page 2 - Beverages", false, false },
                    { 11, 6, new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2901), "Page 1 - Dairy", false, false },
                    { 12, 6, new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2906), "Page 2 - Fruits", false, false },
                    { 13, 7, new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2910), "Page 1 - Dairy", true, true },
                    { 14, 7, new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2914), "Page 2 - Fruits", true, true }
                });

            migrationBuilder.InsertData(
                table: "StatementItems",
                columns: new[] { "Id", "DebtPageId", "ItemName", "Price", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, 1, "Potatoes", 2m, 5, "Kg" },
                    { 2, 1, "Carrots", 1.5m, 3, "Kg" },
                    { 3, 1, "Tomatoes", 2.2m, 4, "Kg" },
                    { 4, 2, "Mineral Water", 0.5m, 12, "Bottle" },
                    { 5, 2, "Orange Juice", 1.2m, 6, "Bottle" },
                    { 6, 3, "Chips", 2m, 3, "Box" },
                    { 7, 3, "Cookies", 3m, 2, "Box" },
                    { 8, 4, "Milk", 1.5m, 6, "Kg" },
                    { 9, 4, "Cheese", 5m, 1, "Kg" },
                    { 10, 5, "Pan", 20m, 1, "Piece" },
                    { 11, 5, "Pressure Cooker", 35m, 1, "Piece" },
                    { 12, 6, "Soap", 1.2m, 5, "Piece" },
                    { 13, 6, "Detergent", 6m, 2, "Box" },
                    { 14, 7, "Apple", 2m, 6, "Kg" },
                    { 15, 7, "Banana", 1.8m, 5, "Kg" },
                    { 16, 8, "Cucumber", 1.5m, 4, "Kg" },
                    { 17, 8, "Lettuce", 1.2m, 3, "Kg" },
                    { 18, 9, "Chocolate", 1.5m, 5, "Piece" },
                    { 19, 9, "Candy", 2.5m, 3, "Box" },
                    { 20, 10, "Cola", 1m, 12, "Bottle" },
                    { 21, 10, "Orange Soda", 1.2m, 8, "Bottle" },
                    { 22, 11, "Yogurt", 0.8m, 10, "Piece" },
                    { 23, 11, "Butter", 4m, 1, "Kg" },
                    { 24, 12, "Mango", 3m, 3, "Kg" },
                    { 25, 12, "Pineapple", 2.5m, 2, "Piece" },
                    { 26, 12, "Mango", 3m, 3, "Kg" },
                    { 27, 12, "Pineapple", 2.5m, 2, "Piece" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountStatements_CustomerId",
                table: "AccountStatements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtPages_AccountStatementID",
                table: "DebtPages",
                column: "AccountStatementID");

            migrationBuilder.CreateIndex(
                name: "IX_StatementItems_DebtPageId",
                table: "StatementItems",
                column: "DebtPageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatementItems");

            migrationBuilder.DropTable(
                name: "DebtPages");

            migrationBuilder.DropTable(
                name: "AccountStatements");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
