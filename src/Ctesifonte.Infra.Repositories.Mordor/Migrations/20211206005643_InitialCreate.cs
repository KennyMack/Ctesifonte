using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ctesifonte.Infra.Repositories.Mordor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MORDOR");

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "MORDOR",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Active",
                schema: "MORDOR",
                table: "USERS",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Email",
                schema: "MORDOR",
                table: "USERS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Id",
                schema: "MORDOR",
                table: "USERS",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Uid",
                schema: "MORDOR",
                table: "USERS",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Username",
                schema: "MORDOR",
                table: "USERS",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS",
                schema: "MORDOR");
        }
    }
}
