using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TSSharaDDDWEB.Infraestructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nobreak",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Serial = table.Column<string>(maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    UPSModel = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    NobreakID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nobreak", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nobreak_Nobreak_NobreakID",
                        column: x => x.NobreakID,
                        principalTable: "Nobreak",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NobreakEvent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventReasons = table.Column<double>(nullable: false),
                    InputVoltage = table.Column<double>(nullable: false),
                    OutputVoltage = table.Column<double>(nullable: false),
                    Load = table.Column<double>(nullable: false),
                    Battery = table.Column<double>(nullable: false),
                    Frequency = table.Column<double>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    CreationData = table.Column<DateTime>(nullable: false),
                    NobreakID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NobreakEvent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NobreakEvent_Nobreak_NobreakID",
                        column: x => x.NobreakID,
                        principalTable: "Nobreak",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nobreak_NobreakID",
                table: "Nobreak",
                column: "NobreakID");

            migrationBuilder.CreateIndex(
                name: "IX_NobreakEvent_NobreakID",
                table: "NobreakEvent",
                column: "NobreakID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NobreakEvent");

            migrationBuilder.DropTable(
                name: "Nobreak");
        }
    }
}
