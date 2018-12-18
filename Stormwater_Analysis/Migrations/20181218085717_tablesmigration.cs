using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stormwater_Analysis.Migrations
{
    public partial class tablesmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manholes",
                columns: table => new
                {
                    ManholeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PipeID = table.Column<int>(nullable: false),
                    InstallationDt = table.Column<DateTime>(nullable: false),
                    ManagedBy = table.Column<string>(nullable: true),
                    DrainageArea = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manholes", x => x.ManholeID);
                });

            migrationBuilder.CreateTable(
                name: "ManholesMaintenance",
                columns: table => new
                {
                    MaintenanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManholeID = table.Column<int>(nullable: false),
                    CoverCondition = table.Column<string>(nullable: true),
                    FrameCondition = table.Column<string>(nullable: true),
                    FrameSealCondition = table.Column<string>(nullable: true),
                    CheckedBy = table.Column<string>(nullable: false),
                    LastMaintenanceDt = table.Column<DateTime>(nullable: false),
                    MaintenanceLevel = table.Column<int>(nullable: false),
                    MaintenanceIssues = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.MaintenanceID);
                });

            migrationBuilder.CreateTable(
                name: "Pipes",
                columns: table => new
                {
                    Pipe_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pipe_Type = table.Column<int>(nullable: false),
                    Start_Manhole_ID = table.Column<int>(nullable: false),
                    Pipe_Length = table.Column<decimal>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Material = table.Column<int>(nullable: false),
                    Slope = table.Column<decimal>(nullable: false),
                    Est_Life = table.Column<int>(nullable: false),
                    Critical_Infrastructure = table.Column<bool>(nullable: false),
                    Critical_Structure = table.Column<bool>(nullable: false),
                    DateOfInstallation = table.Column<DateTime>(nullable: false),
                    Maintenance_Records_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipes", x => x.Pipe_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manholes");

            migrationBuilder.DropTable(
                name: "ManholesMaintenance");

            migrationBuilder.DropTable(
                name: "Pipes");
        }
    }
}
