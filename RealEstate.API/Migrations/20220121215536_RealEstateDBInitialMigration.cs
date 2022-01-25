using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.API.Migrations
{
    public partial class RealEstateDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RoomAmount = table.Column<int>(nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UploadedAt = table.Column<DateTime>(nullable: false),
                    PropertyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    StateOrProvince = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single Family Home" },
                    { 2, "Multi Family Home" },
                    { 3, "Townhome" },
                    { 4, "Flat" },
                    { 5, "Co-op" },
                    { 6, "Condo" },
                    { 7, "Mobile" },
                    { 8, "Farm" },
                    { 9, "Land" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressLine1_AddressLine2_PostalCode_StateOrProvince_City",
                table: "Addresses",
                columns: new[] { "AddressLine1", "AddressLine2", "PostalCode", "StateOrProvince", "City" },
                unique: true,
                filter: "[AddressLine1] IS NOT NULL AND [AddressLine2] IS NOT NULL AND [PostalCode] IS NOT NULL AND [StateOrProvince] IS NOT NULL AND [City] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_Name",
                table: "PropertyTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyTypes");
        }
    }
}
