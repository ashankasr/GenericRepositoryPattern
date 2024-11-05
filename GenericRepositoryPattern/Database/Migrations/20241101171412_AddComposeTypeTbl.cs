using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericRepositoryPattern.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddComposeTypeTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComposeType",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComposeType", x => new { x.EmployeeId, x.MaritalStatusId });
                    table.ForeignKey(
                        name: "FK_ComposeType_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComposeType");
        }
    }
}
