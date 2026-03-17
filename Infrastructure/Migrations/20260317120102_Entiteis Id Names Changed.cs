using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntiteisIdNamesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StatementItems",
                newName: "StatementItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DebtPages",
                newName: "DebtPageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccountStatements",
                newName: "AccountStatementId");

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 7, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 9, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 10, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "AccountStatementId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 15, 1, 1, 617, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 2, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 7, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 7, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 5, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 9, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 9, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 10, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 10, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "DebtPageId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 12, 15, 1, 1, 618, DateTimeKind.Local).AddTicks(2624));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatementItemId",
                table: "StatementItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DebtPageId",
                table: "DebtPages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountStatementId",
                table: "AccountStatements",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 24, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 1, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 27, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 4, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 6, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "AccountStatements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 6, 2, 43, 49, 756, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 24, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 24, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 1, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 1, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 27, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 27, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 3, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 4, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 4, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "DebtPages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 6, 2, 43, 49, 758, DateTimeKind.Local).AddTicks(2914));
        }
    }
}
