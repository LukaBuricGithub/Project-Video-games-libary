using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBuricLuka.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Publishers_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearFounded = table.Column<int>(type: "int", nullable: false),
                    CityProjectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Developers_Cities_CityProjectID",
                        column: x => x.CityProjectID,
                        principalTable: "Cities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingExperience = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublisherID = table.Column<int>(type: "int", nullable: true),
                    DeveloperID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VideoGames_Developers_DeveloperID",
                        column: x => x.DeveloperID,
                        principalTable: "Developers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_VideoGames_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "France" },
                    { 3, "England" },
                    { 4, "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Lyon" },
                    { 2, 4, "Montreal" },
                    { 3, 1, "Irvin" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Bethesda Softworks" },
                    { 2, 2, "Ubisoft" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "ID", "CityProjectID", "Name", "Website", "YearFounded" },
                values: new object[] { 1, 1, "Arkane studios", "https://www.arkane-studios.com/en", 1999 });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "ID", "CityProjectID", "Name", "Website", "YearFounded" },
                values: new object[] { 2, 2, "Ubisoft Montreal", "https://montreal.ubisoft.com/en/", 1997 });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "ID", "CityProjectID", "Name", "Website", "YearFounded" },
                values: new object[] { 3, 3, "Obsidian Entertainment", "https://www.obsidian.net/", 2003 });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "ID", "DeveloperID", "Genre", "Name", "PublisherID", "Rating", "ReleaseDate", "Website" },
                values: new object[] { 1, 2, "FPS, Multiplayer, Team-based, Action", "Tom Clancy's Rainbow Six Siege", 2, 7.9000000000000004, new DateTime(2015, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.ubisoft.com/en-gb/game/rainbow-six/siege" });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "ID", "DeveloperID", "Genre", "Name", "PublisherID", "Rating", "ReleaseDate", "Website" },
                values: new object[] { 2, 1, "FPS, Sci-fi, Space, Immersive Sim, Singleplayer", "Prey", 1, 8.1999999999999993, new DateTime(2017, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://bethesda.net/en/game/prey" });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "ID", "DeveloperID", "Genre", "Name", "PublisherID", "Rating", "ReleaseDate", "Website" },
                values: new object[] { 3, 3, "Open World, Post-apocalyptic, RPG, Singleplayer", "Fallout: New Vegas", 1, 8.4000000000000004, new DateTime(2010, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fallout.bethesda.net/en/games/fallout-new-vegas" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CityID",
                table: "Client",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_CityProjectID",
                table: "Developers",
                column: "CityProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ClientID",
                table: "Meeting",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_CountryID",
                table: "Publishers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_DeveloperID",
                table: "VideoGames",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherID",
                table: "VideoGames",
                column: "PublisherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "VideoGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
