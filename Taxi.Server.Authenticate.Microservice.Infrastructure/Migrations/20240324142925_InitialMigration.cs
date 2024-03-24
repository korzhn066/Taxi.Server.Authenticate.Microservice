using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taxi.Server.Authenticate.Microservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    NumberRatingChanges = table.Column<int>(type: "int", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "CandidateDrivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDrivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateDrivers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateDriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_CandidateDrivers_CandidateDriverId",
                        column: x => x.CandidateDriverId,
                        principalTable: "CandidateDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e445865-a24d-4543-a6c6-9443d048cdb9", null, "Driver", "DRIVER" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", null, "Client", "CLIENT" },
                    { "9e445865-a24d-4543-a6c6-9443d048cdb9", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NumberRatingChanges", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rating", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e445865-a24d-4543-a6c6-9443d048cdb9", 0, "6c008792-9dd6-4718-87cb-4cb7652dff5a", null, false, false, null, "admin", null, "ADMIN", 1, "AQAAAAIAAYagAAAAECch2lLeq6Vxd4o5RjgiHxKRlue1Q//sWAyUiyhX0w18HPSYK+K875XCMphN0qsj6A==", "+375336481213", false, 5f, "8c999248-71c7-4211-9170-e2e762a60a53", false, "admin" },
                    { "2e445865-a24d-4543-a6c6-9443d048cdb9", 0, "76986608-9b3a-49c7-926f-bc5288d3a42f", null, false, false, null, "user1", null, "USER1", 1, "AQAAAAIAAYagAAAAEFi//6mnXjgNFOFJbWEaJNA7CoJBniSLb3d4IHzwToF7UV40BgeZPVMQV3vWPiGIug==", "+375336481213", false, 5f, "411b44e7-df62-49f5-9528-27ee3aa7d508", false, "user1" },
                    { "3e445865-a24d-4543-a6c6-9443d048cdb9", 0, "ec1001de-855f-4c31-9344-d5b0ebc3d964", null, false, false, null, "user2", null, "USER2", 1, "AQAAAAIAAYagAAAAEMoM0f95ZTNoafbVxfeERg2uKFEspElbLJOV1spkYJ57VutSM82B93806GqAkipuFA==", "+375336481213", false, 5f, "c089e7da-b6e1-40f7-aa6f-889c934d6f53", false, "user2" },
                    { "4e445865-a24d-4543-a6c6-9443d048cdb9", 0, "997f53d9-27d1-448c-a224-eec7428dee6f", null, false, false, null, "driver1", null, "DRIVER1", 1, "AQAAAAIAAYagAAAAEGo6y9cG+rbI9940gD+d8rKmio3umjeK98Wlv3zzgSbYFYOGYep1jfcGegd6W0/CiQ==", "+375336481213", false, 5f, "4e1970ef-9231-480c-b348-03613e2c0c4a", false, "driver1" },
                    { "5e445865-a24d-4543-a6c6-9443d048cdb9", 0, "cdfaee5f-0b5a-4af9-9366-e653b567118a", null, false, false, null, "driver2", null, "DRIVER2", 1, "AQAAAAIAAYagAAAAEJE4SroJ/9anICFQQy7sNfqKaHeGVujvpHh7BmYyJ8OfsW6y3CfbqVhuCtoALmGLiQ==", "+375336481213", false, 5f, "da67b528-1008-4fd4-82e1-28da5e754bf8", false, "driver2" },
                    { "6e445865-a24d-4543-a6c6-9443d048cdb9", 0, "c6f4b427-b454-45da-bd87-dfcb21e1a8af", null, false, false, null, "candidate1", null, "CANDIDATE1", 1, "AQAAAAIAAYagAAAAEHvpAkS/a9tYHpKBmavXVXQ/w6JtgD0/ps4vjuKOXLAoRcitazAmP0/NMynkS1PjbQ==", "+375336481213", false, 5f, "fa2e647f-6a46-4817-bdfe-6995373f87e6", false, "candidate1" },
                    { "7e445865-a24d-4543-a6c6-9443d048cdb9", 0, "9959ac63-3b8a-4d9b-8e43-23f7f8698ac2", null, false, false, null, "candidate2", null, "CANDIDATE2", 1, "AQAAAAIAAYagAAAAELg5tnXvp2zR28yuDCR+ZD/igryO+IaHsZIDhMBxVRj0sov7dpa0pOVURXqbJVLTWA==", "+375336481213", false, 5f, "23a30c65-3c97-4022-be1d-6df629806901", false, "candidate2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "1e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "9e445865-a24d-4543-a6c6-9443d048cdb9", "1e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "3e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "0e445865-a24d-4543-a6c6-9443d048cdb9", "4e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "4e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "0e445865-a24d-4543-a6c6-9443d048cdb9", "5e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "6e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "7e445865-a24d-4543-a6c6-9443d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "CandidateDrivers",
                columns: new[] { "Id", "ApplicationUserId", "Message", "Status" },
                values: new object[,]
                {
                    { 1, "6e445865-a24d-4543-a6c6-9443d048cdb9", null, 0 },
                    { 2, "7e445865-a24d-4543-a6c6-9443d048cdb9", "Вы не отправили фото прав", 0 }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "CandidateDriverId", "FilePath" },
                values: new object[,]
                {
                    { 1, 1, "1.jpg" },
                    { 2, 1, "1.jpg" },
                    { 3, 2, "1.jpg" }
                });

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
                name: "IX_CandidateDrivers_ApplicationUserId",
                table: "CandidateDrivers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CandidateDriverId",
                table: "Photos",
                column: "CandidateDriverId");
        }

        /// <inheritdoc />
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
                name: "Photos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CandidateDrivers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
