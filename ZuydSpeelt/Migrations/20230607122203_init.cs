using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZuydSpeelt.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    { 11, "bypass" },
                    { 12, "parse" },
                    { 13, "quantify" },
                    { 14, "program" },
                    { 15, "generate" },
                    { 16, "parse" },
                    { 17, "bypass" },
                    { 18, "reboot" },
                    { 19, "synthesize" },
                    { 20, "transmit" },
                    { 61, "input" },
                    { 62, "compress" },
                    { 63, "quantify" },
                    { 64, "generate" },
                    { 65, "navigate" },
                    { 66, "compress" },
                    { 67, "compress" },
                    { 68, "back up" },
                    { 69, "input" },
                    { 70, "compress" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CreatedAt", "GameId", "Text", "UserId" },
                values: new object[,]
                {
                    { 82, new DateTime(2023, 6, 6, 19, 28, 4, 275, DateTimeKind.Local).AddTicks(8185), 8, "We need to generate the back-end ADP monitor!", 13 },
                    { 85, new DateTime(2023, 6, 6, 16, 52, 34, 571, DateTimeKind.Local).AddTicks(7284), 17, "The HTTP alarm is down, connect the wireless alarm so we can connect the HTTP alarm!", 16 },
                    { 87, new DateTime(2023, 6, 7, 5, 6, 44, 731, DateTimeKind.Local).AddTicks(3799), 10, "If we back up the driver, we can get to the COM driver through the multi-byte COM driver!", 16 },
                    { 88, new DateTime(2023, 6, 7, 12, 3, 22, 766, DateTimeKind.Local).AddTicks(8199), 18, "We need to parse the neural PNG microchip!", 19 },
                    { 90, new DateTime(2023, 6, 7, 7, 25, 17, 609, DateTimeKind.Local).AddTicks(7122), 17, "Use the primary RSS protocol, then you can bypass the primary protocol!", 11 }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Popularity", "Title" },
                values: new object[,]
                {
                    { 21, 0, new DateTime(2023, 6, 7, 0, 32, 11, 372, DateTimeKind.Local).AddTicks(4964), 4, "programming the system won't do anything, we need to generate the redundant ADP system!" },
                    { 22, 0, new DateTime(2023, 6, 7, 10, 17, 29, 273, DateTimeKind.Local).AddTicks(5508), 2, "You can't quantify the system without synthesizing the online FTP system!" },
                    { 23, 0, new DateTime(2023, 6, 7, 4, 10, 51, 818, DateTimeKind.Local).AddTicks(985), 1, "The GB card is down, parse the digital card so we can parse the GB card!" },
                    { 24, 0, new DateTime(2023, 6, 7, 0, 12, 10, 288, DateTimeKind.Local).AddTicks(6156), 4, "Use the neural EXE sensor, then you can navigate the neural sensor!" },
                    { 25, 0, new DateTime(2023, 6, 7, 0, 10, 43, 295, DateTimeKind.Local).AddTicks(2461), 2, "If we synthesize the sensor, we can get to the FTP sensor through the auxiliary FTP sensor!" },
                    { 26, 0, new DateTime(2023, 6, 6, 18, 30, 14, 477, DateTimeKind.Local).AddTicks(7723), 1, "Use the virtual AGP hard drive, then you can connect the virtual hard drive!" },
                    { 27, 0, new DateTime(2023, 6, 7, 7, 44, 11, 179, DateTimeKind.Local).AddTicks(6108), 3, "The GB circuit is down, calculate the digital circuit so we can calculate the GB circuit!" },
                    { 28, 0, new DateTime(2023, 6, 7, 3, 5, 29, 548, DateTimeKind.Local).AddTicks(4516), 1, "We need to navigate the 1080p ADP panel!" },
                    { 29, 0, new DateTime(2023, 6, 7, 9, 7, 49, 897, DateTimeKind.Local).AddTicks(2787), 1, "transmitting the array won't do anything, we need to hack the haptic CSS array!" },
                    { 30, 0, new DateTime(2023, 6, 7, 10, 2, 11, 817, DateTimeKind.Local).AddTicks(8206), 5, "Try to generate the GB application, maybe it will generate the open-source application!" },
                    { 71, 0, new DateTime(2023, 6, 6, 17, 8, 3, 57, DateTimeKind.Local).AddTicks(3136), 1, "You can't program the matrix without calculating the optical SSL matrix!" },
                    { 72, 0, new DateTime(2023, 6, 7, 0, 23, 32, 787, DateTimeKind.Local).AddTicks(1917), 1, "Use the virtual USB matrix, then you can transmit the virtual matrix!" },
                    { 73, 0, new DateTime(2023, 6, 6, 16, 30, 28, 954, DateTimeKind.Local).AddTicks(8655), 5, "Use the digital GB sensor, then you can compress the digital sensor!" },
                    { 74, 0, new DateTime(2023, 6, 7, 10, 28, 11, 552, DateTimeKind.Local).AddTicks(378), 3, "If we transmit the monitor, we can get to the FTP monitor through the back-end FTP monitor!" },
                    { 75, 0, new DateTime(2023, 6, 6, 20, 50, 58, 133, DateTimeKind.Local).AddTicks(8327), 1, "The PNG array is down, bypass the virtual array so we can bypass the PNG array!" },
                    { 76, 0, new DateTime(2023, 6, 7, 3, 17, 50, 295, DateTimeKind.Local).AddTicks(8261), 3, "I'll override the mobile PCI firewall, that should firewall the PCI firewall!" },
                    { 77, 0, new DateTime(2023, 6, 6, 19, 3, 15, 368, DateTimeKind.Local).AddTicks(9531), 5, "You can't bypass the circuit without transmitting the multi-byte RSS circuit!" },
                    { 78, 0, new DateTime(2023, 6, 7, 3, 45, 33, 836, DateTimeKind.Local).AddTicks(2578), 1, "The RSS panel is down, bypass the cross-platform panel so we can bypass the RSS panel!" },
                    { 79, 0, new DateTime(2023, 6, 7, 12, 30, 4, 487, DateTimeKind.Local).AddTicks(6813), 1, "Try to reboot the ADP bandwidth, maybe it will reboot the back-end bandwidth!" },
                    { 80, 0, new DateTime(2023, 6, 7, 14, 13, 17, 572, DateTimeKind.Local).AddTicks(1935), 4, "The XSS driver is down, synthesize the auxiliary driver so we can synthesize the XSS driver!" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "GameId", "UserId", "Value" },
                values: new object[,]
                {
                    { 91, 9, 18, 2 },
                    { 93, 10, 15, 1 },
                    { 94, 20, 11, 5 },
                    { 97, 2, 12, 4 },
                    { 99, 20, 14, 5 },
                    { 100, 19, 19, 3 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 6, 21, 27, 14, 244, DateTimeKind.Local).AddTicks(1560), "Jena_Gleason7@yahoo.com", "bypass", "Breanne" },
                    { 2, new DateTime(2023, 6, 6, 16, 56, 14, 933, DateTimeKind.Local).AddTicks(8343), "Heath_Walker@gmail.com", "quantify", "Jayden" },
                    { 3, new DateTime(2023, 6, 6, 18, 40, 32, 713, DateTimeKind.Local).AddTicks(3291), "Lillie93@gmail.com", "calculate", "Renee" },
                    { 4, new DateTime(2023, 6, 7, 2, 13, 22, 626, DateTimeKind.Local).AddTicks(3708), "Rachelle_Rutherford@gmail.com", "back up", "Demario" },
                    { 5, new DateTime(2023, 6, 7, 14, 5, 14, 3, DateTimeKind.Local).AddTicks(2733), "Bridgette_Wiegand72@yahoo.com", "copy", "D'angelo" },
                    { 6, new DateTime(2023, 6, 7, 13, 43, 42, 156, DateTimeKind.Local).AddTicks(8328), "Einar42@gmail.com", "index", "Uriah" },
                    { 7, new DateTime(2023, 6, 7, 12, 58, 59, 625, DateTimeKind.Local).AddTicks(3739), "Keshawn_Hane49@gmail.com", "program", "Stephon" },
                    { 8, new DateTime(2023, 6, 7, 2, 28, 44, 104, DateTimeKind.Local).AddTicks(7865), "Vinnie47@yahoo.com", "back up", "Alford" },
                    { 9, new DateTime(2023, 6, 6, 17, 12, 17, 176, DateTimeKind.Local).AddTicks(8014), "Edyth_Sauer41@yahoo.com", "input", "Rosalyn" },
                    { 10, new DateTime(2023, 6, 7, 13, 54, 9, 269, DateTimeKind.Local).AddTicks(905), "Ellis_Hodkiewicz@gmail.com", "index", "Ruby" },
                    { 51, new DateTime(2023, 6, 6, 16, 52, 24, 353, DateTimeKind.Local).AddTicks(4691), "Sallie_Little@hotmail.com", "quantify", "Emmalee" },
                    { 52, new DateTime(2023, 6, 7, 10, 14, 3, 802, DateTimeKind.Local).AddTicks(3227), "Alfred_Schowalter31@hotmail.com", "transmit", "Cesar" },
                    { 53, new DateTime(2023, 6, 7, 7, 38, 12, 680, DateTimeKind.Local).AddTicks(3141), "Mia99@hotmail.com", "navigate", "Alia" },
                    { 54, new DateTime(2023, 6, 7, 5, 37, 43, 986, DateTimeKind.Local).AddTicks(1511), "Curt.Watsica0@yahoo.com", "compress", "Joanie" },
                    { 55, new DateTime(2023, 6, 6, 17, 0, 18, 793, DateTimeKind.Local).AddTicks(9122), "Herman66@gmail.com", "reboot", "Liza" },
                    { 56, new DateTime(2023, 6, 6, 22, 26, 12, 71, DateTimeKind.Local).AddTicks(3703), "Dorothy_Yost60@yahoo.com", "quantify", "Marquise" },
                    { 57, new DateTime(2023, 6, 6, 21, 35, 27, 549, DateTimeKind.Local).AddTicks(289), "Declan91@yahoo.com", "generate", "Delia" },
                    { 58, new DateTime(2023, 6, 6, 15, 26, 10, 763, DateTimeKind.Local).AddTicks(8628), "Nichole74@gmail.com", "index", "Lou" },
                    { 59, new DateTime(2023, 6, 7, 14, 5, 28, 13, DateTimeKind.Local).AddTicks(8702), "Sophie_Koss@hotmail.com", "copy", "Vesta" },
                    { 60, new DateTime(2023, 6, 6, 19, 5, 57, 32, DateTimeKind.Local).AddTicks(8300), "Domenick.Turner@hotmail.com", "back up", "Tyrel" }
                });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "CreatedAt", "GameId", "UserId", "Score" },
                values: new object[,]
                {
                    { new DateTime(2023, 6, 7, 10, 49, 8, 156, DateTimeKind.Local).AddTicks(9273), 6, 12, 9 },
                    { new DateTime(2023, 6, 6, 19, 24, 48, 600, DateTimeKind.Local).AddTicks(3912), 15, 14, 7 },
                    { new DateTime(2023, 6, 7, 4, 1, 5, 665, DateTimeKind.Local).AddTicks(1614), 4, 15, 7 },
                    { new DateTime(2023, 6, 6, 21, 5, 2, 501, DateTimeKind.Local).AddTicks(9255), 8, 15, 6 },
                    { new DateTime(2023, 6, 6, 14, 43, 14, 123, DateTimeKind.Local).AddTicks(9824), 14, 16, 8 }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CreatedAt", "GameId", "Text", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2023, 6, 6, 22, 7, 48, 89, DateTimeKind.Local).AddTicks(2124), 3, "You can't back up the program without indexing the wireless SAS program!", 6 },
                    { 32, new DateTime(2023, 6, 7, 3, 40, 55, 418, DateTimeKind.Local).AddTicks(2337), 5, "We need to back up the mobile SAS transmitter!", 10 },
                    { 33, new DateTime(2023, 6, 6, 23, 22, 9, 663, DateTimeKind.Local).AddTicks(4822), 1, "We need to back up the online ADP circuit!", 9 },
                    { 34, new DateTime(2023, 6, 6, 15, 0, 37, 336, DateTimeKind.Local).AddTicks(4672), 3, "The CSS bus is down, override the multi-byte bus so we can override the CSS bus!", 4 },
                    { 35, new DateTime(2023, 6, 6, 19, 56, 19, 908, DateTimeKind.Local).AddTicks(6511), 10, "I'll connect the neural CSS bandwidth, that should bandwidth the CSS bandwidth!", 10 },
                    { 36, new DateTime(2023, 6, 7, 0, 4, 18, 544, DateTimeKind.Local).AddTicks(2366), 10, "Try to connect the PNG alarm, maybe it will connect the neural alarm!", 6 },
                    { 37, new DateTime(2023, 6, 7, 5, 16, 28, 256, DateTimeKind.Local).AddTicks(3836), 7, "I'll index the online ADP sensor, that should sensor the ADP sensor!", 10 },
                    { 38, new DateTime(2023, 6, 7, 4, 1, 32, 404, DateTimeKind.Local).AddTicks(6337), 2, "You can't input the card without synthesizing the neural EXE card!", 8 },
                    { 39, new DateTime(2023, 6, 7, 5, 52, 27, 820, DateTimeKind.Local).AddTicks(9197), 9, "Try to calculate the HDD sensor, maybe it will calculate the bluetooth sensor!", 10 },
                    { 40, new DateTime(2023, 6, 7, 9, 4, 56, 142, DateTimeKind.Local).AddTicks(5716), 9, "Use the optical THX bandwidth, then you can transmit the optical bandwidth!", 6 },
                    { 81, new DateTime(2023, 6, 7, 2, 58, 42, 740, DateTimeKind.Local).AddTicks(8732), 15, "We need to index the online XML circuit!", 5 },
                    { 83, new DateTime(2023, 6, 6, 15, 4, 59, 300, DateTimeKind.Local).AddTicks(708), 3, "We need to override the 1080p XSS microchip!", 8 },
                    { 84, new DateTime(2023, 6, 7, 3, 52, 20, 271, DateTimeKind.Local).AddTicks(9410), 1, "Try to parse the RSS alarm, maybe it will parse the solid state alarm!", 8 },
                    { 86, new DateTime(2023, 6, 7, 10, 16, 43, 798, DateTimeKind.Local).AddTicks(7526), 15, "If we calculate the hard drive, we can get to the JSON hard drive through the bluetooth JSON hard drive!", 5 },
                    { 89, new DateTime(2023, 6, 7, 11, 16, 36, 204, DateTimeKind.Local).AddTicks(5308), 5, "We need to back up the optical IB circuit!", 3 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "GameId", "UserId", "Value" },
                values: new object[,]
                {
                    { 41, 2, 2, 2 },
                    { 42, 2, 2, 3 },
                    { 43, 1, 4, 2 },
                    { 44, 1, 5, 3 },
                    { 45, 8, 10, 4 },
                    { 46, 5, 2, 5 },
                    { 47, 8, 6, 5 },
                    { 48, 1, 8, 5 },
                    { 49, 4, 10, 1 },
                    { 50, 8, 7, 4 },
                    { 92, 13, 6, 5 },
                    { 95, 5, 4, 4 },
                    { 96, 19, 10, 5 },
                    { 98, 19, 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "CreatedAt", "GameId", "UserId", "Score" },
                values: new object[,]
                {
                    { new DateTime(2023, 6, 6, 20, 12, 40, 749, DateTimeKind.Local).AddTicks(373), 9, 1, 8 },
                    { new DateTime(2023, 6, 7, 9, 25, 3, 438, DateTimeKind.Local).AddTicks(6620), 6, 2, 9 },
                    { new DateTime(2023, 6, 7, 5, 48, 16, 687, DateTimeKind.Local).AddTicks(258), 10, 2, 4 },
                    { new DateTime(2023, 6, 7, 10, 7, 47, 794, DateTimeKind.Local).AddTicks(3106), 20, 2, 2 },
                    { new DateTime(2023, 6, 6, 15, 39, 51, 344, DateTimeKind.Local).AddTicks(9291), 4, 3, 8 },
                    { new DateTime(2023, 6, 6, 20, 0, 15, 656, DateTimeKind.Local).AddTicks(7107), 6, 4, 7 },
                    { new DateTime(2023, 6, 7, 11, 18, 0, 584, DateTimeKind.Local).AddTicks(2362), 6, 4, 9 },
                    { new DateTime(2023, 6, 7, 12, 6, 5, 267, DateTimeKind.Local).AddTicks(6811), 8, 4, 6 },
                    { new DateTime(2023, 6, 7, 13, 35, 22, 289, DateTimeKind.Local).AddTicks(4768), 5, 5, 9 },
                    { new DateTime(2023, 6, 7, 7, 54, 49, 685, DateTimeKind.Local).AddTicks(2660), 7, 5, 10 },
                    { new DateTime(2023, 6, 7, 8, 23, 43, 820, DateTimeKind.Local).AddTicks(5432), 3, 6, 5 },
                    { new DateTime(2023, 6, 7, 11, 43, 24, 977, DateTimeKind.Local).AddTicks(8758), 9, 6, 2 },
                    { new DateTime(2023, 6, 7, 7, 56, 49, 496, DateTimeKind.Local).AddTicks(7502), 1, 8, 6 },
                    { new DateTime(2023, 6, 7, 7, 47, 47, 719, DateTimeKind.Local).AddTicks(7559), 4, 8, 10 },
                    { new DateTime(2023, 6, 6, 19, 13, 21, 325, DateTimeKind.Local).AddTicks(393), 7, 10, 2 }
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
