﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Decors.Infrastructure.Persistence.Migrations
{
    public partial class InitiaizeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Vendors_VendorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Vendors_VendorId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Vendors_VendorId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vendors_VendorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VendorId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Vendors",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Transactions",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Products",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Photos",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Permissions",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Orders",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Document",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Customers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Coupons",
                newName: "Expires");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "CartItem",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Cart",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Reviews",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Locations",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_Location_VendorId",
                table: "Locations",
                newName: "IX_Locations_VendorId");

            migrationBuilder.RenameColumn(
                name: "CreatedDa",
                table: "Addresses",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TransactionRef",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionStatus",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colors",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Shipping",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Coupons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Coupons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAfterDiscount",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Locations",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Locations",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RegionCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFirstLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoggedInAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoggedOutAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageAccessed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlReferrer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "VendorUsers",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorUsers", x => new { x.VendorId, x.UserId });
                    table.ForeignKey(
                        name: "FK_VendorUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorUsers_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendorUsers_UserId",
                table: "VendorUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Vendors_VendorId",
                table: "Coupons",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Vendors_VendorId",
                table: "Locations",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vendors_VendorId",
                table: "Products",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Vendors_VendorId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Vendors_VendorId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vendors_VendorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "VendorUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionRef",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Colors",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "TotalAfterDiscount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Vendors",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Transactions",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Photos",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Permissions",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Orders",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Document",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Customers",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "Expires",
                table: "Coupons",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Categories",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "CartItem",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Cart",
                newName: "CreatedDa");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Review",
                newName: "CreatedDa");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "Review",
                newName: "IX_Review_ProductId");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Location",
                newName: "CreatedDa");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_VendorId",
                table: "Location",
                newName: "IX_Location_VendorId");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Address",
                newName: "CreatedDa");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(14,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Coupons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VendorId",
                table: "AspNetUsers",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Vendors_VendorId",
                table: "AspNetUsers",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Vendors_VendorId",
                table: "Coupons",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Vendors_VendorId",
                table: "Location",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vendors_VendorId",
                table: "Products",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
