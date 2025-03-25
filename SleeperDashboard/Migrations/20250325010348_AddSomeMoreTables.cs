using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SleeperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeMoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyPosition_Players_PlayerId",
                table: "FantasyPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_FantasyPosition_PlayerId",
                table: "FantasyPosition");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "FantasyPosition");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Players",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepthChartPosition",
                table: "Players",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "FantasyPositions",
                table: "Players",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RosterId",
                table: "Players",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RosterId1",
                table: "Players",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RosterId2",
                table: "Players",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<string>(type: "longtext", nullable: false),
                    Streak = table.Column<string>(type: "longtext", nullable: false),
                    AllowPnInactiveStarters = table.Column<string>(type: "longtext", nullable: false),
                    AllowPnPlayerInjuryStatus = table.Column<string>(type: "longtext", nullable: false),
                    AllowPnScoring = table.Column<string>(type: "longtext", nullable: false),
                    RestrictPnScoringStartersOnly = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rosters",
                columns: table => new
                {
                    RosterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CoOwners = table.Column<string>(type: "longtext", nullable: true),
                    Keepers = table.Column<string>(type: "longtext", nullable: true),
                    LeagueId = table.Column<string>(type: "longtext", nullable: true),
                    MetadataId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "longtext", nullable: true),
                    PlayerMap = table.Column<string>(type: "longtext", nullable: true),
                    Taxi = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rosters", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_Rosters_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalTable: "Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Value = table.Column<long>(type: "bigint", nullable: true),
                    RosterId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Rosters_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Rosters",
                        principalColumn: "RosterId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RosterId",
                table: "Players",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RosterId1",
                table: "Players",
                column: "RosterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RosterId2",
                table: "Players",
                column: "RosterId2");

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_MetadataId",
                table: "Rosters",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_RosterId",
                table: "Settings",
                column: "RosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rosters_RosterId",
                table: "Players",
                column: "RosterId",
                principalTable: "Rosters",
                principalColumn: "RosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rosters_RosterId1",
                table: "Players",
                column: "RosterId1",
                principalTable: "Rosters",
                principalColumn: "RosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rosters_RosterId2",
                table: "Players",
                column: "RosterId2",
                principalTable: "Rosters",
                principalColumn: "RosterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rosters_RosterId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rosters_RosterId1",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rosters_RosterId2",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Rosters");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RosterId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RosterId1",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RosterId2",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FantasyPositions",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RosterId1",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RosterId2",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "DepthChartPosition",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Players",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "FantasyPosition",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPosition_PlayerId",
                table: "FantasyPosition",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyPosition_Players_PlayerId",
                table: "FantasyPosition",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
