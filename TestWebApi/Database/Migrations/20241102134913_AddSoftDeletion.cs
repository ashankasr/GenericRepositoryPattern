﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employee");
        }
    }
}
