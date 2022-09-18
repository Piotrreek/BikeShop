using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeShop.Migrations
{
    public partial class AddIdentityAndUpdateSomePropertiesAtProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPurchases",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "ProductionYear",
                table: "MountainBikes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NumberOfPurchases",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionYear",
                table: "MountainBikes");
        }
    }
}
