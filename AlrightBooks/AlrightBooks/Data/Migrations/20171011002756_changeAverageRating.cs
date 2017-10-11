using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AlrightBooks.Data.Migrations
{
    public partial class changeAverageRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AvgRating",
                table: "Books",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.AlterColumn<decimal>(
                name: "AvgRating",
                table: "Books",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
