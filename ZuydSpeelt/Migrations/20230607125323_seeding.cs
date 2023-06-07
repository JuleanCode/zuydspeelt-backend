using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZuydSpeelt.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Popularity = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGame",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGame", x => new { x.UserId, x.GameId, x.CreatedAt });
                    table.ForeignKey(
                        name: "FK_UserGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGame_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "calculate" },
                    { 2, "generate" },
                    { 3, "back up" },
                    { 4, "reboot" },
                    { 5, "back up" },
                    { 6, "parse" },
                    { 7, "generate" },
                    { 8, "transmit" },
                    { 9, "program" },
                    { 10, "bypass" },
                    { 11, "synthesize" },
                    { 12, "synthesize" },
                    { 13, "bypass" },
                    { 14, "back up" },
                    { 15, "program" },
                    { 16, "hack" },
                    { 17, "copy" },
                    { 18, "calculate" },
                    { 19, "generate" },
                    { 20, "override" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 7, 4, 34, 36, 624, DateTimeKind.Utc).AddTicks(1106), "Blanche.Kub@hotmail.com", "input", "Boyd" },
                    { 2, new DateTime(2023, 6, 6, 15, 10, 21, 439, DateTimeKind.Utc).AddTicks(8422), "Zion_Balistreri@hotmail.com", "copy", "Javonte" },
                    { 3, new DateTime(2023, 6, 6, 19, 2, 4, 575, DateTimeKind.Utc).AddTicks(4041), "Margret34@yahoo.com", "reboot", "Liam" },
                    { 4, new DateTime(2023, 6, 7, 10, 50, 0, 853, DateTimeKind.Utc).AddTicks(3506), "Zion_Nolan@gmail.com", "hack", "Maximillian" },
                    { 5, new DateTime(2023, 6, 7, 7, 2, 18, 301, DateTimeKind.Utc).AddTicks(633), "Jovanny32@yahoo.com", "transmit", "Pablo" },
                    { 6, new DateTime(2023, 6, 6, 19, 58, 26, 533, DateTimeKind.Utc).AddTicks(3325), "Lucas_Hodkiewicz@gmail.com", "bypass", "Javonte" },
                    { 7, new DateTime(2023, 6, 7, 0, 28, 31, 316, DateTimeKind.Utc).AddTicks(1656), "Rosetta.Kohler@yahoo.com", "synthesize", "Howard" },
                    { 8, new DateTime(2023, 6, 7, 11, 16, 49, 526, DateTimeKind.Utc).AddTicks(9726), "Penelope92@yahoo.com", "reboot", "Geovanny" },
                    { 9, new DateTime(2023, 6, 6, 21, 1, 42, 495, DateTimeKind.Utc).AddTicks(8013), "Moses.Nolan@gmail.com", "parse", "Bettie" },
                    { 10, new DateTime(2023, 6, 7, 4, 20, 25, 27, DateTimeKind.Utc).AddTicks(9801), "Edd46@hotmail.com", "index", "Alba" },
                    { 11, new DateTime(2023, 6, 7, 4, 36, 25, 968, DateTimeKind.Utc).AddTicks(45), "Marilou16@yahoo.com", "index", "Jimmie" },
                    { 12, new DateTime(2023, 6, 7, 12, 13, 4, 429, DateTimeKind.Utc).AddTicks(5775), "Pat_Jones@hotmail.com", "override", "Kaleigh" },
                    { 13, new DateTime(2023, 6, 6, 20, 35, 46, 44, DateTimeKind.Utc).AddTicks(7069), "Connie15@hotmail.com", "calculate", "Edna" },
                    { 14, new DateTime(2023, 6, 7, 9, 56, 24, 919, DateTimeKind.Utc).AddTicks(1767), "Herbert.MacGyver97@yahoo.com", "navigate", "Marge" },
                    { 15, new DateTime(2023, 6, 7, 7, 11, 51, 125, DateTimeKind.Utc).AddTicks(7115), "Merritt1@yahoo.com", "synthesize", "Amya" },
                    { 16, new DateTime(2023, 6, 6, 17, 3, 35, 786, DateTimeKind.Utc).AddTicks(8446), "Orrin_Spencer@gmail.com", "navigate", "Mara" },
                    { 17, new DateTime(2023, 6, 7, 9, 15, 12, 536, DateTimeKind.Utc).AddTicks(2691), "Doris_Yost@yahoo.com", "override", "Earline" },
                    { 18, new DateTime(2023, 6, 7, 3, 45, 57, 547, DateTimeKind.Utc).AddTicks(3776), "Marlene.Nicolas60@yahoo.com", "hack", "Tiana" },
                    { 19, new DateTime(2023, 6, 6, 21, 15, 34, 6, DateTimeKind.Utc).AddTicks(1309), "Della.Fay@yahoo.com", "compress", "Erick" },
                    { 20, new DateTime(2023, 6, 7, 8, 15, 9, 976, DateTimeKind.Utc).AddTicks(3778), "Constantin33@gmail.com", "synthesize", "Woodrow" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Popularity", "Title" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2023, 6, 7, 0, 3, 45, 74, DateTimeKind.Utc).AddTicks(2347), 1, "Try to parse the SQL alarm, maybe it will parse the solid state alarm!" },
                    { 2, 2, new DateTime(2023, 6, 6, 16, 3, 59, 156, DateTimeKind.Utc).AddTicks(5570), 2, "Try to calculate the ADP application, maybe it will calculate the digital application!" },
                    { 3, 2, new DateTime(2023, 6, 7, 4, 19, 21, 548, DateTimeKind.Utc).AddTicks(2733), 2, "synthesizing the pixel won't do anything, we need to parse the auxiliary EXE pixel!" },
                    { 4, 3, new DateTime(2023, 6, 7, 7, 0, 15, 747, DateTimeKind.Utc).AddTicks(4924), 4, "If we program the matrix, we can get to the HTTP matrix through the auxiliary HTTP matrix!" },
                    { 5, 1, new DateTime(2023, 6, 7, 0, 54, 20, 466, DateTimeKind.Utc).AddTicks(4907), 3, "I'll synthesize the bluetooth PCI pixel, that should pixel the PCI pixel!" },
                    { 6, 1, new DateTime(2023, 6, 6, 14, 46, 43, 819, DateTimeKind.Utc).AddTicks(3881), 3, "If we navigate the capacitor, we can get to the SSL capacitor through the online SSL capacitor!" },
                    { 7, 2, new DateTime(2023, 6, 6, 19, 1, 9, 478, DateTimeKind.Utc).AddTicks(1800), 1, "You can't quantify the array without synthesizing the solid state XSS array!" },
                    { 8, 3, new DateTime(2023, 6, 6, 19, 49, 44, 717, DateTimeKind.Utc).AddTicks(7948), 3, "Use the redundant PCI firewall, then you can parse the redundant firewall!" },
                    { 9, 5, new DateTime(2023, 6, 6, 22, 55, 20, 376, DateTimeKind.Utc).AddTicks(737), 1, "We need to generate the bluetooth SDD capacitor!" },
                    { 10, 3, new DateTime(2023, 6, 7, 4, 56, 56, 152, DateTimeKind.Utc).AddTicks(4345), 1, "Use the multi-byte GB bus, then you can copy the multi-byte bus!" },
                    { 11, 5, new DateTime(2023, 6, 6, 19, 13, 29, 603, DateTimeKind.Utc).AddTicks(9845), 2, "synthesizing the firewall won't do anything, we need to quantify the digital JSON firewall!" },
                    { 12, 4, new DateTime(2023, 6, 7, 2, 29, 8, 621, DateTimeKind.Utc).AddTicks(364), 2, "You can't reboot the matrix without compressing the primary HTTP matrix!" },
                    { 13, 1, new DateTime(2023, 6, 7, 7, 4, 40, 260, DateTimeKind.Utc).AddTicks(5371), 3, "If we calculate the protocol, we can get to the JSON protocol through the virtual JSON protocol!" },
                    { 14, 5, new DateTime(2023, 6, 7, 3, 54, 15, 192, DateTimeKind.Utc).AddTicks(4463), 1, "We need to input the auxiliary SCSI program!" },
                    { 15, 2, new DateTime(2023, 6, 6, 20, 53, 12, 131, DateTimeKind.Utc).AddTicks(4919), 4, "I'll back up the neural RAM hard drive, that should hard drive the RAM hard drive!" },
                    { 16, 2, new DateTime(2023, 6, 6, 20, 56, 14, 149, DateTimeKind.Utc).AddTicks(4942), 2, "Use the mobile RSS interface, then you can compress the mobile interface!" },
                    { 17, 4, new DateTime(2023, 6, 7, 7, 0, 17, 374, DateTimeKind.Utc).AddTicks(5804), 4, "If we parse the hard drive, we can get to the USB hard drive through the open-source USB hard drive!" },
                    { 18, 2, new DateTime(2023, 6, 7, 0, 59, 49, 912, DateTimeKind.Utc).AddTicks(3515), 5, "Use the 1080p SAS bus, then you can index the 1080p bus!" },
                    { 19, 1, new DateTime(2023, 6, 6, 15, 6, 14, 16, DateTimeKind.Utc).AddTicks(1627), 4, "Try to override the SDD firewall, maybe it will override the back-end firewall!" },
                    { 20, 5, new DateTime(2023, 6, 7, 11, 21, 23, 454, DateTimeKind.Utc).AddTicks(7931), 4, "Try to synthesize the XML program, maybe it will synthesize the open-source program!" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CreatedAt", "GameId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 7, 0, 9, 49, 37, DateTimeKind.Utc).AddTicks(8243), 1, "Use the bluetooth PNG array, then you can back up the bluetooth array!", 2 },
                    { 2, new DateTime(2023, 6, 6, 15, 5, 37, 591, DateTimeKind.Utc).AddTicks(2973), 2, "You can't back up the hard drive without indexing the haptic FTP hard drive!", 5 },
                    { 3, new DateTime(2023, 6, 6, 15, 1, 57, 501, DateTimeKind.Utc).AddTicks(9048), 4, "Use the 1080p SCSI bus, then you can reboot the 1080p bus!", 3 },
                    { 4, new DateTime(2023, 6, 7, 12, 48, 24, 987, DateTimeKind.Utc).AddTicks(2928), 2, "You can't navigate the program without programming the cross-platform EXE program!", 4 },
                    { 5, new DateTime(2023, 6, 7, 4, 9, 2, 922, DateTimeKind.Utc).AddTicks(3375), 2, "You can't back up the pixel without programming the mobile COM pixel!", 3 },
                    { 6, new DateTime(2023, 6, 6, 18, 1, 45, 433, DateTimeKind.Utc).AddTicks(5054), 4, "navigating the panel won't do anything, we need to transmit the digital AI panel!", 5 },
                    { 7, new DateTime(2023, 6, 6, 19, 44, 47, 831, DateTimeKind.Utc).AddTicks(1145), 1, "The PCI capacitor is down, compress the 1080p capacitor so we can compress the PCI capacitor!", 4 },
                    { 8, new DateTime(2023, 6, 6, 14, 29, 0, 188, DateTimeKind.Utc).AddTicks(2020), 4, "We need to program the haptic COM microchip!", 2 },
                    { 9, new DateTime(2023, 6, 7, 10, 53, 33, 493, DateTimeKind.Utc).AddTicks(3848), 4, "We need to index the neural HTTP monitor!", 5 },
                    { 10, new DateTime(2023, 6, 7, 10, 41, 25, 926, DateTimeKind.Utc).AddTicks(7294), 2, "overriding the transmitter won't do anything, we need to override the back-end SMTP transmitter!", 4 },
                    { 11, new DateTime(2023, 6, 6, 18, 45, 26, 343, DateTimeKind.Utc).AddTicks(4206), 3, "generating the firewall won't do anything, we need to copy the wireless JSON firewall!", 4 },
                    { 12, new DateTime(2023, 6, 6, 13, 9, 50, 48, DateTimeKind.Utc).AddTicks(169), 5, "Try to synthesize the FTP alarm, maybe it will synthesize the wireless alarm!", 4 },
                    { 13, new DateTime(2023, 6, 6, 19, 18, 50, 870, DateTimeKind.Utc).AddTicks(2951), 5, "You can't copy the feed without synthesizing the auxiliary JBOD feed!", 3 },
                    { 14, new DateTime(2023, 6, 6, 20, 19, 40, 176, DateTimeKind.Utc).AddTicks(2988), 2, "Use the haptic XML array, then you can synthesize the haptic array!", 4 },
                    { 15, new DateTime(2023, 6, 7, 12, 34, 51, 66, DateTimeKind.Utc).AddTicks(157), 5, "hacking the pixel won't do anything, we need to override the wireless FTP pixel!", 2 },
                    { 16, new DateTime(2023, 6, 6, 15, 21, 32, 664, DateTimeKind.Utc).AddTicks(5757), 2, "bypassing the system won't do anything, we need to reboot the virtual CSS system!", 4 },
                    { 17, new DateTime(2023, 6, 7, 7, 51, 10, 363, DateTimeKind.Utc).AddTicks(3307), 4, "Try to navigate the PCI array, maybe it will navigate the back-end array!", 4 },
                    { 18, new DateTime(2023, 6, 7, 3, 47, 20, 876, DateTimeKind.Utc).AddTicks(1876), 5, "Try to reboot the SCSI feed, maybe it will reboot the redundant feed!", 5 },
                    { 19, new DateTime(2023, 6, 7, 5, 42, 32, 697, DateTimeKind.Utc).AddTicks(8154), 3, "Try to program the JBOD firewall, maybe it will program the wireless firewall!", 4 },
                    { 20, new DateTime(2023, 6, 7, 8, 19, 39, 354, DateTimeKind.Utc).AddTicks(2777), 2, "Use the haptic GB application, then you can connect the haptic application!", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "GameId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 4, 4, 2 },
                    { 2, 5, 4, 4 },
                    { 3, 4, 1, 5 },
                    { 4, 4, 1, 3 },
                    { 5, 2, 3, 4 },
                    { 6, 5, 3, 1 },
                    { 7, 2, 5, 4 },
                    { 8, 3, 3, 1 },
                    { 9, 5, 4, 1 },
                    { 10, 2, 5, 1 },
                    { 11, 2, 4, 3 },
                    { 12, 3, 1, 1 },
                    { 13, 4, 4, 1 },
                    { 14, 4, 4, 4 },
                    { 15, 3, 3, 1 },
                    { 16, 5, 2, 3 },
                    { 17, 2, 1, 3 },
                    { 18, 4, 3, 5 },
                    { 19, 2, 3, 5 },
                    { 20, 1, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "CreatedAt", "GameId", "UserId", "Score" },
                values: new object[,]
                {
                    { new DateTime(2023, 6, 6, 13, 39, 42, 274, DateTimeKind.Utc).AddTicks(8743), 1, 1, 5 },
                    { new DateTime(2023, 6, 7, 6, 46, 25, 382, DateTimeKind.Utc).AddTicks(502), 2, 1, 9 },
                    { new DateTime(2023, 6, 7, 6, 49, 47, 470, DateTimeKind.Utc).AddTicks(3263), 2, 1, 9 },
                    { new DateTime(2023, 6, 7, 12, 22, 13, 177, DateTimeKind.Utc).AddTicks(8554), 2, 1, 1 },
                    { new DateTime(2023, 6, 7, 4, 40, 11, 62, DateTimeKind.Utc).AddTicks(227), 5, 1, 8 },
                    { new DateTime(2023, 6, 6, 19, 25, 46, 896, DateTimeKind.Utc).AddTicks(2721), 4, 2, 6 },
                    { new DateTime(2023, 6, 7, 2, 14, 5, 508, DateTimeKind.Utc).AddTicks(2005), 5, 2, 2 },
                    { new DateTime(2023, 6, 7, 3, 49, 49, 500, DateTimeKind.Utc).AddTicks(1704), 5, 2, 4 },
                    { new DateTime(2023, 6, 6, 22, 9, 3, 393, DateTimeKind.Utc).AddTicks(1241), 1, 3, 2 },
                    { new DateTime(2023, 6, 7, 10, 8, 16, 49, DateTimeKind.Utc).AddTicks(1377), 1, 3, 1 },
                    { new DateTime(2023, 6, 7, 12, 38, 7, 40, DateTimeKind.Utc).AddTicks(6230), 2, 3, 1 },
                    { new DateTime(2023, 6, 6, 14, 27, 5, 975, DateTimeKind.Utc).AddTicks(1856), 5, 3, 9 },
                    { new DateTime(2023, 6, 6, 21, 51, 29, 773, DateTimeKind.Utc).AddTicks(8429), 2, 4, 3 },
                    { new DateTime(2023, 6, 6, 20, 42, 34, 840, DateTimeKind.Utc).AddTicks(871), 4, 4, 8 },
                    { new DateTime(2023, 6, 7, 1, 18, 52, 303, DateTimeKind.Utc).AddTicks(6063), 5, 4, 5 },
                    { new DateTime(2023, 6, 6, 23, 17, 45, 662, DateTimeKind.Utc).AddTicks(9295), 3, 5, 5 },
                    { new DateTime(2023, 6, 7, 7, 47, 31, 31, DateTimeKind.Utc).AddTicks(1777), 3, 5, 9 },
                    { new DateTime(2023, 6, 6, 18, 14, 31, 395, DateTimeKind.Utc).AddTicks(9625), 4, 5, 9 },
                    { new DateTime(2023, 6, 6, 23, 42, 56, 894, DateTimeKind.Utc).AddTicks(5304), 4, 5, 6 },
                    { new DateTime(2023, 6, 7, 11, 3, 31, 684, DateTimeKind.Utc).AddTicks(9147), 4, 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_GameId",
                table: "Comment",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_CategoryId",
                table: "Game",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_GameId",
                table: "Rating",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGame_GameId",
                table: "UserGame",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UserGame");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
