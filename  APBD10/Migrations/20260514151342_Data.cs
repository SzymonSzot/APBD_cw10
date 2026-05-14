using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD10.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "Intel", new DateOnly(1968, 7, 18), "Intel Corporation" },
                    { 2, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices, Inc." },
                    { 3, "NVIDIA", new DateOnly(1993, 4, 5), "NVIDIA Corporation" },
                    { 4, "Corsair", new DateOnly(1994, 1, 1), "Corsair Gaming, Inc." }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Central Processing Unit" },
                    { 2, "GPU", "Graphics Processing Unit" },
                    { 3, "RAM", "Random Access Memory" },
                    { 4, "MB", "Motherboard" }
                });

            migrationBuilder.InsertData(
                table: "PC",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Titan Build", 5, 24, 12.5f },
                    { 2, new DateTime(2023, 10, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), "Ryzen Workstation", 3, 36, 14f },
                    { 3, new DateTime(2023, 10, 5, 9, 15, 0, 0, DateTimeKind.Unspecified), "Budget Gamer", 10, 12, 9.5f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "AMD-R9-795", 2, 1, "16-core, 32-thread desktop processor", "AMD Ryzen 9 7950X" },
                    { "COR-32G-D5", 4, 3, "2x16GB DDR5 5600MHz RAM", "Corsair Vengeance 32GB" },
                    { "INT-I9-139", 1, 1, "24-core, 32-thread desktop processor", "Intel Core i9-13900K" },
                    { "NV-RTX4090", 3, 2, "24GB GDDR6X flagship GPU", "NVIDIA GeForce RTX 4090" }
                });

            migrationBuilder.InsertData(
                table: "PcComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "COR-32G-D5", 1, 2 },
                    { "INT-I9-139", 1, 1 },
                    { "NV-RTX4090", 1, 1 },
                    { "AMD-R9-795", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "COR-32G-D5", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "INT-I9-139", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "NV-RTX4090", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "AMD-R9-795", 2 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "AMD-R9-795");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "COR-32G-D5");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "INT-I9-139");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "NV-RTX4090");

            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
