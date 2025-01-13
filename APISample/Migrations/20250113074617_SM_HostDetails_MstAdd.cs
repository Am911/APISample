using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISample.Migrations
{
    /// <inheritdoc />
    public partial class SM_HostDetails_MstAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SM_HostDetails_Mst",
                columns: table => new
                {
                    Host_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessCount = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SM_HostDetails_Mst", x => x.Host_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SM_HostDetails_Mst");
        }
    }
}
