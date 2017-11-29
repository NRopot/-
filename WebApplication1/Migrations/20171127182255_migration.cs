using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nchar(20)", nullable: true),
                    FIO_Customer = table.Column<string>(type: "nchar(20)", nullable: false),
                    Passport_data = table.Column<string>(type: "nchar(20)", nullable: true),
                    Phone = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Material_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nchar(10)", nullable: true),
                    Material_Price = table.Column<decimal>(type: "money", nullable: true),
                    Name_Material = table.Column<string>(type: "nchar(10)", nullable: false),
                    Packing = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Material_id);
                });

            migrationBuilder.CreateTable(
                name: "Types_Of_Jobs",
                columns: table => new
                {
                    Job_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cost_work = table.Column<decimal>(type: "money", nullable: true),
                    Description = table.Column<string>(maxLength: 10, nullable: true),
                    Material_id = table.Column<int>(nullable: true),
                    Name_Work = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types_Of_Jobs", x => x.Job_id);
                    table.ForeignKey(
                        name: "FK_Types_Of_Jobs_Materials",
                        column: x => x.Material_id,
                        principalTable: "Materials",
                        principalColumn: "Material_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brigade",
                columns: table => new
                {
                    Brigade_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Composition_worker = table.Column<string>(type: "nchar(10)", nullable: true),
                    FIO_Brigadier = table.Column<string>(type: "nchar(10)", nullable: true),
                    Job_id = table.Column<int>(nullable: true),
                    Name_brigade = table.Column<string>(type: "nchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigade", x => x.Brigade_id);
                    table.ForeignKey(
                        name: "FK_Brigade_Types_Of_Jobs",
                        column: x => x.Job_id,
                        principalTable: "Types_Of_Jobs",
                        principalColumn: "Job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brigade_id = table.Column<int>(nullable: true),
                    Brigadier = table.Column<string>(type: "nchar(10)", nullable: true),
                    Completion_note = table.Column<bool>(nullable: true),
                    Cost = table.Column<decimal>(type: "money", nullable: true),
                    Customers_id = table.Column<int>(nullable: true),
                    Job_id = table.Column<int>(nullable: true),
                    Materials_id = table.Column<int>(nullable: true),
                    Payment_note = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Orders_Brigade",
                        column: x => x.Brigade_id,
                        principalTable: "Brigade",
                        principalColumn: "Brigade_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.Customers_id,
                        principalTable: "Customers",
                        principalColumn: "Customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Materials",
                        column: x => x.Materials_id,
                        principalTable: "Materials",
                        principalColumn: "Material_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Work_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brigade_id = table.Column<int>(nullable: true),
                    Date_Beginning = table.Column<DateTime>(type: "date", nullable: true),
                    Date_End = table.Column<DateTime>(type: "date", nullable: true),
                    FIO_Brigadier = table.Column<string>(type: "nchar(10)", nullable: true),
                    Job_id = table.Column<int>(nullable: true),
                    Order_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Work_id);
                    table.ForeignKey(
                        name: "FK_Works_Brigade",
                        column: x => x.Brigade_id,
                        principalTable: "Brigade",
                        principalColumn: "Brigade_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Types_Of_Jobs",
                        column: x => x.Job_id,
                        principalTable: "Types_Of_Jobs",
                        principalColumn: "Job_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Orders",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brigade_Job_id",
                table: "Brigade",
                column: "Job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Brigade_id",
                table: "Orders",
                column: "Brigade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customers_id",
                table: "Orders",
                column: "Customers_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Materials_id",
                table: "Orders",
                column: "Materials_id");

            migrationBuilder.CreateIndex(
                name: "IX_Types_Of_Jobs_Material_id",
                table: "Types_Of_Jobs",
                column: "Material_id");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Brigade_id",
                table: "Works",
                column: "Brigade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Job_id",
                table: "Works",
                column: "Job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Order_id",
                table: "Works",
                column: "Order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brigade");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Types_Of_Jobs");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
