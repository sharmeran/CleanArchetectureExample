using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchExample.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_By = table.Column<int>(nullable: false),
                    Updated_By = table.Column<int>(nullable: false),
                    Created_On = table.Column<DateTime>(nullable: false),
                    Updated_On = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Type",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_By = table.Column<int>(nullable: false),
                    Updated_By = table.Column<int>(nullable: false),
                    Created_On = table.Column<DateTime>(nullable: false),
                    Updated_On = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_By = table.Column<int>(nullable: false),
                    Updated_By = table.Column<int>(nullable: false),
                    Created_On = table.Column<DateTime>(nullable: false),
                    Updated_On = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Company_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Company_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_By = table.Column<int>(nullable: false),
                    Updated_By = table.Column<int>(nullable: false),
                    Created_On = table.Column<DateTime>(nullable: false),
                    Updated_On = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Username = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    User_Type_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_User_Type_User_Type_ID",
                        column: x => x.User_Type_ID,
                        principalTable: "User_Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Company_ID",
                table: "Employee",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Type_ID",
                table: "Users",
                column: "User_Type_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User_Type");
        }
    }
}
