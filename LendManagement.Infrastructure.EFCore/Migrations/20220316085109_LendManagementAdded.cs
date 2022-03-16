using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LendManagement.Infrastructure.EFCore.Migrations
{
    public partial class LendManagementAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lend",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    Borrower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Lended = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LendOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operation = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    OperatorId = table.Column<long>(type: "bigint", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    LendId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LendOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LendOperations_Lend_LendId",
                        column: x => x.LendId,
                        principalTable: "Lend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LendOperations_LendId",
                table: "LendOperations",
                column: "LendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LendOperations");

            migrationBuilder.DropTable(
                name: "Lend");
        }
    }
}
