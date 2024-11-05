using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Btl_web_nc.Migrations
{
    /// <inheritdoc />
    public partial class fixCascadeBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "types",
                columns: table => new
                {
                    typeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_users_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "roleId");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    postId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    area = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.postId);
                    table.ForeignKey(
                        name: "FK_posts_types_typeId",
                        column: x => x.typeId,
                        principalTable: "types",
                        principalColumn: "typeId");
                    table.ForeignKey(
                        name: "FK_posts_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "favourites",
                columns: table => new
                {
                    favouriteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    postId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favourites", x => x.favouriteId);
                    table.ForeignKey(
                        name: "FK_favourites_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "postId");
                    table.ForeignKey(
                        name: "FK_favourites_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "notifies",
                columns: table => new
                {
                    notifyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    postId = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifies", x => x.notifyId);
                    table.ForeignKey(
                        name: "FK_notifies_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "postId");
                    table.ForeignKey(
                        name: "FK_notifies_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_favourites_postId",
                table: "favourites",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_favourites_userId",
                table: "favourites",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_notifies_postId",
                table: "notifies",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_notifies_userId",
                table: "notifies",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_typeId",
                table: "posts",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_userId",
                table: "posts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleId",
                table: "users",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favourites");

            migrationBuilder.DropTable(
                name: "notifies");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
