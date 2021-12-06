using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ctesifonte.Infra.Repositories.Hefestos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HEFESTOS");

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                schema: "HEFESTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_Active",
                schema: "HEFESTOS",
                table: "CUSTOMERS",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_Email",
                schema: "HEFESTOS",
                table: "CUSTOMERS",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_Id",
                schema: "HEFESTOS",
                table: "CUSTOMERS",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMERS",
                schema: "HEFESTOS");
        }
    }
}
