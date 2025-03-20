using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlersAPI.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bowlers",
                columns: table => new
                {
                    BowlerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BowlerFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerMiddleInit = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerLastName = table.Column<string>(type: "TEXT", nullable: true),
                    TeamID = table.Column<int>(type: "INTEGER", nullable: true),
                    BowlerAddress = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerCity = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerState = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerZip = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowlers", x => x.BowlerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowlers");
        }
    }
}
