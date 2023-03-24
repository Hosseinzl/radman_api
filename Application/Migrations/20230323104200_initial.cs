using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productCounts = table.Column<int>(type: "int", nullable: false),
                    predefinedCategoryType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "credits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "eventType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "file",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "friends",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friends", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    min = table.Column<int>(type: "int", nullable: false),
                    max = table.Column<int>(type: "int", nullable: false),
                    isMaxInfinity = table.Column<bool>(type: "bit", nullable: false),
                    colorHex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pointState",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pointState", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rewardDetails",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rewardId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rewardDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rewards",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    miniDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isFavorite = table.Column<bool>(type: "bit", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sellCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rewards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sortTypes",
                columns: table => new
                {
                    key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    persianName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sortTypes", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    stateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.stateId);
                });

            migrationBuilder.CreateTable(
                name: "transactionType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otpExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "generalinfos",
                columns: table => new
                {
                    generalInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creditId = table.Column<int>(type: "int", nullable: false),
                    totalCash = table.Column<int>(type: "int", nullable: false),
                    totalAsset = table.Column<int>(type: "int", nullable: false),
                    totalStock = table.Column<int>(type: "int", nullable: false),
                    remainingDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalinfos", x => x.generalInfoId);
                    table.ForeignKey(
                        name: "FK_generalinfos_credits_creditId",
                        column: x => x.creditId,
                        principalTable: "credits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolioItems",
                columns: table => new
                {
                    portfoloItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idOfCredit = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    Creditid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioItems", x => x.portfoloItemId);
                    table.ForeignKey(
                        name: "FK_portfolioItems_credits_Creditid",
                        column: x => x.Creditid,
                        principalTable: "credits",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_portfolioItems_credits_idOfCredit",
                        column: x => x.idOfCredit,
                        principalTable: "credits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "friendInvitations",
                columns: table => new
                {
                    invitationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    isMale = table.Column<bool>(type: "bit", nullable: false),
                    moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recivedPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendInvitations", x => x.invitationId);
                    table.ForeignKey(
                        name: "FK_friendInvitations_friends_UserId",
                        column: x => x.UserId,
                        principalTable: "friends",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invitationStatistics",
                columns: table => new
                {
                    invitationStatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    totalInvitationPoint = table.Column<int>(type: "int", nullable: false),
                    acceptedCount = table.Column<int>(type: "int", nullable: false),
                    waitingCount = table.Column<int>(type: "int", nullable: false),
                    totalSentInvitationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invitationStatistics", x => x.invitationStatisticsId);
                    table.ForeignKey(
                        name: "FK_invitationStatistics_friends_idUser",
                        column: x => x.idUser,
                        principalTable: "friends",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    competitorCounts = table.Column<int>(type: "int", nullable: false),
                    yourPoint = table.Column<int>(type: "int", nullable: false),
                    totalCount = table.Column<int>(type: "int", nullable: false),
                    isUserAttend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitions_states_stateId",
                        column: x => x.stateId,
                        principalTable: "states",
                        principalColumn: "stateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profiles_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pointInfos",
                columns: table => new
                {
                    pointId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    profileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    pointsToLevel = table.Column<int>(type: "int", nullable: false),
                    activeLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activeLevelPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pointInfos", x => x.pointId);
                    table.ForeignKey(
                        name: "FK_pointInfos_profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_id",
                table: "categories",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_competitions_id",
                table: "competitions",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_competitions_stateId",
                table: "competitions",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_credits_id",
                table: "credits",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_eventType_id",
                table: "eventType",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_file_id",
                table: "file",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_friendInvitations_UserId",
                table: "friendInvitations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_friends_id",
                table: "friends",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generalinfos_creditId",
                table: "generalinfos",
                column: "creditId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grades_id",
                table: "grades",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invitationStatistics_idUser",
                table: "invitationStatistics",
                column: "idUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pointInfos_profileId",
                table: "pointInfos",
                column: "profileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pointState_id",
                table: "pointState",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItems_Creditid",
                table: "portfolioItems",
                column: "Creditid");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItems_idOfCredit",
                table: "portfolioItems",
                column: "idOfCredit");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_userId",
                table: "profiles",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rewardDetails_id",
                table: "rewardDetails",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rewards_id",
                table: "rewards",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_states_stateId",
                table: "states",
                column: "stateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactionType_id",
                table: "transactionType",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_id",
                table: "users",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "competitions");

            migrationBuilder.DropTable(
                name: "eventType");

            migrationBuilder.DropTable(
                name: "file");

            migrationBuilder.DropTable(
                name: "friendInvitations");

            migrationBuilder.DropTable(
                name: "generalinfos");

            migrationBuilder.DropTable(
                name: "grades");

            migrationBuilder.DropTable(
                name: "invitationStatistics");

            migrationBuilder.DropTable(
                name: "pointInfos");

            migrationBuilder.DropTable(
                name: "pointState");

            migrationBuilder.DropTable(
                name: "portfolioItems");

            migrationBuilder.DropTable(
                name: "rewardDetails");

            migrationBuilder.DropTable(
                name: "rewards");

            migrationBuilder.DropTable(
                name: "sortTypes");

            migrationBuilder.DropTable(
                name: "transactionType");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "friends");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "credits");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
