using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMToolMapperAdminPanel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllFeatures",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllFeatures", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "MappingHistoryDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MappingId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    MappingStatus = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingHistoryDetail", x => x.DetailId);
                });

            migrationBuilder.CreateTable(
                name: "PMTool",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMTool", x => x.ToolId);
                });

            migrationBuilder.CreateTable(
                name: "ToolFeatureCategories",
                columns: table => new
                {
                    FeatureCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureCategoryName = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolFeatureCategories", x => x.FeatureCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Paswword = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ToolFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    AllFeaturesFeatureId = table.Column<int>(type: "int", nullable: true),
                    FeatureCategoryId = table.Column<int>(type: "int", nullable: false),
                    ToolFeatureCategoriesFeatureCategoryId = table.Column<int>(type: "int", nullable: true),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    PMToolToolId = table.Column<int>(type: "int", nullable: true),
                    FeatureUrl = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FeatureStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolFeatures_AllFeatures_AllFeaturesFeatureId",
                        column: x => x.AllFeaturesFeatureId,
                        principalTable: "AllFeatures",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToolFeatures_PMTool_PMToolToolId",
                        column: x => x.PMToolToolId,
                        principalTable: "PMTool",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToolFeatures_ToolFeatureCategories_ToolFeatureCategoriesFeatureCategoryId",
                        column: x => x.ToolFeatureCategoriesFeatureCategoryId,
                        principalTable: "ToolFeatureCategories",
                        principalColumn: "FeatureCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MappingHistory",
                columns: table => new
                {
                    MappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldToolId = table.Column<int>(type: "int", nullable: false),
                    NewToolId = table.Column<int>(type: "int", nullable: false),
                    PMToolToolId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserLoginUserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingHistory", x => x.MappingId);
                    table.ForeignKey(
                        name: "FK_MappingHistory_PMTool_PMToolToolId",
                        column: x => x.PMToolToolId,
                        principalTable: "PMTool",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MappingHistory_UserLogin_UserLoginUserId",
                        column: x => x.UserLoginUserId,
                        principalTable: "UserLogin",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MigrationHistory",
                columns: table => new
                {
                    Migrationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldToolId = table.Column<int>(type: "int", nullable: false),
                    NewToolId = table.Column<int>(type: "int", nullable: false),
                    PMToolToolId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserLoginUserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationHistory", x => x.Migrationid);
                    table.ForeignKey(
                        name: "FK_MigrationHistory_PMTool_PMToolToolId",
                        column: x => x.PMToolToolId,
                        principalTable: "PMTool",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigrationHistory_UserLogin_UserLoginUserId",
                        column: x => x.UserLoginUserId,
                        principalTable: "UserLogin",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PMTool",
                columns: new[] { "ToolId", "ToolName" },
                values: new object[,]
                {
                    { 1, "TFS" },
                    { 2, "Jira" }
                });

            migrationBuilder.InsertData(
                table: "ToolFeatureCategories",
                columns: new[] { "FeatureCategoryId", "FeatureCategoryName" },
                values: new object[,]
                {
                    { 1, "Common basic features" },
                    { 2, "Common advanced features" },
                    { 3, "Extra features of destination tool" }
                });

            migrationBuilder.InsertData(
                table: "UserLogin",
                columns: new[] { "UserId", "Date", "Paswword", "UserFullName", "UserName", "UserRole" },
                values: new object[] { 1, new DateTime(2021, 7, 6, 1, 38, 46, 118, DateTimeKind.Local).AddTicks(8887), "1234$", "Sam Perera", "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistory_PMToolToolId",
                table: "MappingHistory",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MappingHistory_UserLoginUserId",
                table: "MappingHistory",
                column: "UserLoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationHistory_PMToolToolId",
                table: "MigrationHistory",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationHistory_UserLoginUserId",
                table: "MigrationHistory",
                column: "UserLoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_AllFeaturesFeatureId",
                table: "ToolFeatures",
                column: "AllFeaturesFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_PMToolToolId",
                table: "ToolFeatures",
                column: "PMToolToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolFeatures_ToolFeatureCategoriesFeatureCategoryId",
                table: "ToolFeatures",
                column: "ToolFeatureCategoriesFeatureCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MappingHistory");

            migrationBuilder.DropTable(
                name: "MappingHistoryDetail");

            migrationBuilder.DropTable(
                name: "MigrationHistory");

            migrationBuilder.DropTable(
                name: "ToolFeatures");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "AllFeatures");

            migrationBuilder.DropTable(
                name: "PMTool");

            migrationBuilder.DropTable(
                name: "ToolFeatureCategories");
        }
    }
}
