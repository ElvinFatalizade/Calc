using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SOAP2JSON.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogData1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogData1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogData2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    LogData1Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogData2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogData2s_LogData1s_LogData1Id",
                        column: x => x.LogData1Id,
                        principalTable: "LogData1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogData2s_LogData1Id",
                table: "LogData2s",
                column: "LogData1Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogData2s");

            migrationBuilder.DropTable(
                name: "LogData1s");
        }
    }
}
