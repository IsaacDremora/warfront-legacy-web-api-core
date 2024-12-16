using System;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace warfront_legacy_web_api_core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usernameHash = table.Column<string>(type: "text", nullable: false),
                    passHash = table.Column<string>(type: "text", nullable: false),
                    userName = table.Column<string>(type: "text", nullable: false),
                    birthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    expCount = table.Column<BigInteger>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flagName = table.Column<string>(type: "text", nullable: false),
                    imgURL = table.Column<string>(type: "text", nullable: false),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    Userid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.id);
                    table.ForeignKey(
                        name: "FK_Flags_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sessionDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    winnerid = table.Column<int>(type: "integer", nullable: false),
                    loserid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_loserid",
                        column: x => x.loserid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_winnerid",
                        column: x => x.winnerid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarriorUnits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    warrioirUnitSkinName = table.Column<string>(type: "text", nullable: false),
                    warriorUnitSkinURL = table.Column<string>(type: "text", nullable: false),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    Userid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarriorUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_WarriorUnits_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flags_Userid",
                table: "Flags",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_loserid",
                table: "Sessions",
                column: "loserid");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_winnerid",
                table: "Sessions",
                column: "winnerid");

            migrationBuilder.CreateIndex(
                name: "IX_WarriorUnits_Userid",
                table: "WarriorUnits",
                column: "Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flags");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "WarriorUnits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
