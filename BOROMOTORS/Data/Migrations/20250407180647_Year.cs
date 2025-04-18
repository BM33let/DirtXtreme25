﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOROMOTORS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Year : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "DirtBikes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "DirtBikes");
        }
    }
}
