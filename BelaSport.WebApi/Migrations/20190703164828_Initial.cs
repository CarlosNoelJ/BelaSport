using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BelaSport.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventType",
                columns: table => new
                {
                    eventTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name_eventType = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventType", x => x.eventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "host",
                columns: table => new
                {
                    dniHost = table.Column<int>(nullable: false),
                    nameHost = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    lastNameHost = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_host", x => x.dniHost);
                });

            migrationBuilder.CreateTable(
                name: "eventTitle",
                columns: table => new
                {
                    eventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name_event = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    dniHost = table.Column<int>(nullable: false),
                    eventTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eventtitle", x => x.eventId);
                    table.ForeignKey(
                        name: "fk_eventTitle_host",
                        column: x => x.dniHost,
                        principalTable: "host",
                        principalColumn: "dniHost",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_eventTitle_eventType",
                        column: x => x.eventTypeId,
                        principalTable: "eventType",
                        principalColumn: "eventTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventTitle_dniHost",
                table: "eventTitle",
                column: "dniHost");

            migrationBuilder.CreateIndex(
                name: "IX_eventTitle_eventTypeId",
                table: "eventTitle",
                column: "eventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventTitle");

            migrationBuilder.DropTable(
                name: "host");

            migrationBuilder.DropTable(
                name: "eventType");
        }
    }
}
