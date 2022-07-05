using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_PK", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerOne = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdConfectionery_PK", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpLastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdEmployee_PK", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "CleitnOrder",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdClientOrder_PK", x => x.IdClientOrder);
                    table.ForeignKey(
                        name: "Client_ClientOrder_FK",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "Employee_ClientOrder_FK",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_ClientOrder",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false),
                    IdConfectionery = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Confectionery_ClientOrder_PK", x => new { x.IdConfectionery, x.IdClientOrder });
                    table.ForeignKey(
                        name: "ClientOrder_FK",
                        column: x => x.IdClientOrder,
                        principalTable: "CleitnOrder",
                        principalColumn: "IdClientOrder");
                    table.ForeignKey(
                        name: "Confectionery_FK",
                        column: x => x.IdConfectionery,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleitnOrder_IdClient",
                table: "CleitnOrder",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_CleitnOrder_IdEmployee",
                table: "CleitnOrder",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_ClientOrder_IdClientOrder",
                table: "Confectionery_ClientOrder",
                column: "IdClientOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_ClientOrder");

            migrationBuilder.DropTable(
                name: "CleitnOrder");

            migrationBuilder.DropTable(
                name: "Confectionery");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
