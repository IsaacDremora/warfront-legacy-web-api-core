using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace warfront_legacy_web_api_core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerInf",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userName = table.Column<string>(type: "text", nullable: true),
                    birthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    expCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInf", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bldUnits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bldUnitSkinName = table.Column<string>(type: "text", nullable: true),
                    bldUnitSkinURL = table.Column<string>(type: "text", nullable: true),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    PlayerInformationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bldUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_bldUnits_PlayerInf_PlayerInformationid",
                        column: x => x.PlayerInformationid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "engUnits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    engUnitSkinName = table.Column<string>(type: "text", nullable: true),
                    engUnitSkinURL = table.Column<string>(type: "text", nullable: true),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    PlayerInformationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_engUnits_PlayerInf_PlayerInformationid",
                        column: x => x.PlayerInformationid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flagName = table.Column<string>(type: "text", nullable: true),
                    imgURL = table.Column<string>(type: "text", nullable: true),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    PlayerInformationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.id);
                    table.ForeignKey(
                        name: "FK_Flags_PlayerInf_PlayerInformationid",
                        column: x => x.PlayerInformationid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sessionDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    winnerid = table.Column<int>(type: "integer", nullable: true),
                    loserid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sessions_PlayerInf_loserid",
                        column: x => x.loserid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Sessions_PlayerInf_winnerid",
                        column: x => x.winnerid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SniperUnits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sniperUnitSkinName = table.Column<string>(type: "text", nullable: true),
                    sniperUnitSkinURL = table.Column<string>(type: "text", nullable: true),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    PlayerInformationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SniperUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_SniperUnits_PlayerInf_PlayerInformationid",
                        column: x => x.PlayerInformationid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usernameHash = table.Column<string>(type: "text", nullable: true),
                    passHash = table.Column<string>(type: "text", nullable: true),
                    playerInformationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_PlayerInf_playerInformationid",
                        column: x => x.playerInformationid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "WarriorUnits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    warrioirUnitSkinName = table.Column<string>(type: "text", nullable: true),
                    warriorUnitSkinURL = table.Column<string>(type: "text", nullable: true),
                    isFree = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    PlayerInformationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarriorUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_WarriorUnits_PlayerInf_PlayerInformationid",
                        column: x => x.PlayerInformationid,
                        principalTable: "PlayerInf",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bldUnits_PlayerInformationid",
                table: "bldUnits",
                column: "PlayerInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_engUnits_PlayerInformationid",
                table: "engUnits",
                column: "PlayerInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_Flags_PlayerInformationid",
                table: "Flags",
                column: "PlayerInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_loserid",
                table: "Sessions",
                column: "loserid");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_winnerid",
                table: "Sessions",
                column: "winnerid");

            migrationBuilder.CreateIndex(
                name: "IX_SniperUnits_PlayerInformationid",
                table: "SniperUnits",
                column: "PlayerInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_playerInformationid",
                table: "Users",
                column: "playerInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_WarriorUnits_PlayerInformationid",
                table: "WarriorUnits",
                column: "PlayerInformationid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bldUnits");

            migrationBuilder.DropTable(
                name: "engUnits");

            migrationBuilder.DropTable(
                name: "Flags");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "SniperUnits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WarriorUnits");

            migrationBuilder.DropTable(
                name: "PlayerInf");
        }
    }
}
