using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolutionOrdersAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasurements",
                columns: table => new
                {
                    IdUnitOfMeasurement = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurements", x => x.IdUnitOfMeasurement);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IdWorker = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IdWorker);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IdCategory = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    FotoUrl = table.Column<string>(type: "text", nullable: true),
                    IdUnitOfMeasurement = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Items_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_UnitOfMeasurements_IdUnitOfMeasurement",
                        column: x => x.IdUnitOfMeasurement,
                        principalTable: "UnitOfMeasurements",
                        principalColumn: "IdUnitOfMeasurement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataOrder = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdClient = table.Column<int>(type: "integer", nullable: true),
                    IdWorker = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Workers_IdWorker",
                        column: x => x.IdWorker,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    IdOrderItem = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdOrder = table.Column<int>(type: "integer", nullable: false),
                    IdItem = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.IdOrderItem);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_IdItem",
                        column: x => x.IdItem,
                        principalTable: "Items",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Urządzenia elektroniczne", true, "Elektronika" },
                    { 2, "Produkty spożywcze", true, "Żywność" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Adress", "IsActive", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ul. Główna 1, Warszawa", true, "Jan Kowalski", "500-100-200" },
                    { 2, "ul. Kwiatowa 5, Kraków", true, "Anna Nowak", "600-200-300" }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasurements",
                columns: new[] { "IdUnitOfMeasurement", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Sztuki", true, "szt" },
                    { 2, "Kilogramy", true, "kg" },
                    { 3, "Litry", true, "l" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "IdWorker", "FirstName", "IsActive", "LastName", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "Piotr", true, "Kowalczyk", "pkowalczyk", "haslo123" },
                    { 2, "Maria", true, "Wiśniewska", "mwisnieska", "haslo456" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "IdItem", "Code", "Description", "FotoUrl", "IdCategory", "IdUnitOfMeasurement", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "LAP001", "Laptop Dell Inspiron 15", null, 1, 1, true, "Laptop Dell", 3500m, 10m },
                    { 2, "MON001", "Monitor 24 cale", null, 1, 1, true, "Monitor Samsung", 800m, 15m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_IdCategory",
                table: "Items",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IdUnitOfMeasurement",
                table: "Items",
                column: "IdUnitOfMeasurement");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdItem",
                table: "OrderItems",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdOrder",
                table: "OrderItems",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdClient",
                table: "Orders",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdWorker",
                table: "Orders",
                column: "IdWorker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UnitOfMeasurements");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
