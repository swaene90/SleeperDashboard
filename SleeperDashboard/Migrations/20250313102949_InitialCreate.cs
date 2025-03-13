using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SleeperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Hashtag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    DepthChartPosition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Sport = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    SearchLastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    InjuryStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Weight = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Position = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PracticeParticipation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SportradarId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Team = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    College = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    FantasyDataId = table.Column<int>(type: "int", nullable: false),
                    InjuryStatus = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PlayerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Height = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    SearchFullName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    BirthCountry = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    EspnId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    SearchRank = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    DepthChartOrder = table.Column<int>(type: "int", nullable: false),
                    YearsExp = table.Column<int>(type: "int", nullable: false),
                    RotowireId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    RotoworldId = table.Column<int>(type: "int", nullable: false),
                    SearchFirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    YahooId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FantasyPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PlayerId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyPosition_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPosition_PlayerId",
                table: "FantasyPosition",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyPosition");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
