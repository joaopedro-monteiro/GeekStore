using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekStore.Migrations
{
    /// <inheritdoc />
    public partial class VendasInfoIdAdc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "VendasInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendasInfo",
                table: "VendasInfo",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VendasInfo",
                table: "VendasInfo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VendasInfo");
        }
    }
}
