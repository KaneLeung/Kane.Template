using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FurionTemplate.Migrations.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_City_ParentId",
                        column: x => x.ParentId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Remark = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniqueName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Account = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    QQ = table.Column<string>(type: "TEXT", nullable: true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPost",
                columns: table => new
                {
                    PersonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPost", x => new { x.PersonsId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_PersonPost_Person_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPost_Post_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleSecurity",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecurityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSecurity", x => new { x.RoleId, x.SecurityId });
                    table.ForeignKey(
                        name: "FK_RoleSecurity_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSecurity_Security_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Security",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedTime", "IsDeleted", "Name", "ParentId", "UpdatedTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 8, 20, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), false, "中国", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Remark" },
                values: new object[] { 1, "超级管理员", "拥有所有权限" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "Remark" },
                values: new object[] { 2, "普通人", "没有关联权限" });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "UniqueName" },
                values: new object[] { 1, "ViewRoles" });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "UniqueName" },
                values: new object[] { 2, "ViewSecuries" });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "UniqueName" },
                values: new object[] { 3, "GetRoles" });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "UniqueName" },
                values: new object[] { 4, "InsertRole" });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "UniqueName" },
                values: new object[] { 5, "GiveUserRole" });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "UniqueName" },
                values: new object[] { 6, "GiveRoleSecurity" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Password" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "Password" },
                values: new object[] { 2, "Furion", "dotnetchina" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedTime", "IsDeleted", "Name", "ParentId", "UpdatedTime" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2020, 8, 20, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), false, "广东省", 1, null });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedTime", "IsDeleted", "Name", "ParentId", "UpdatedTime" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(2020, 8, 20, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), false, "浙江省", 1, null });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedTime", "IsDeleted", "Name", "ParentId", "UpdatedTime" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2020, 8, 20, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), false, "中山市", 2, null });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedTime", "IsDeleted", "Name", "ParentId", "UpdatedTime" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2020, 8, 20, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), false, "珠海市", 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_Children_PersonId",
                table: "Children",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ParentId",
                table: "City",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonPost_PostsId",
                table: "PersonPost",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSecurity_SecurityId",
                table: "RoleSecurity",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PersonDetail");

            migrationBuilder.DropTable(
                name: "PersonPost");

            migrationBuilder.DropTable(
                name: "RoleSecurity");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Security");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
