using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BlogCore.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Verificar si la tabla AspNetRoles no existe antes de crearla
            if (!TableExists(migrationBuilder, "AspNetRoles"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetRoles",
                    columns: table => new
                    {
                        Id = table.Column<string>(nullable: false),
                        Name = table.Column<string>(maxLength: 256, nullable: true),
                        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                        ConcurrencyStamp = table.Column<string>(nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    });
            }

            if (!TableExists(migrationBuilder, "AspNetUsers"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetUsers",
                    columns: table => new
                    {
                        Id = table.Column<string>(nullable: false),
                        UserName = table.Column<string>(maxLength: 256, nullable: true),
                        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                        Email = table.Column<string>(maxLength: 256, nullable: true),
                        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                        EmailConfirmed = table.Column<bool>(nullable: false),
                        PasswordHash = table.Column<string>(nullable: true),
                        SecurityStamp = table.Column<string>(nullable: true),
                        ConcurrencyStamp = table.Column<string>(nullable: true),
                        PhoneNumber = table.Column<string>(nullable: true),
                        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                        TwoFactorEnabled = table.Column<bool>(nullable: false),
                        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                        LockoutEnabled = table.Column<bool>(nullable: false),
                        AccessFailedCount = table.Column<int>(nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    });
            }

            if (!TableExists(migrationBuilder, "AspNetRoleClaims"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetRoleClaims",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        RoleId = table.Column<string>(nullable: false),
                        ClaimType = table.Column<string>(nullable: true),
                        ClaimValue = table.Column<string>(nullable: true)
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
            }

            if (!IndexExists(migrationBuilder, "IX_AspNetRoleClaims_RoleId", "AspNetRoleClaims"))
            {
                migrationBuilder.CreateIndex(
                    name: "IX_AspNetRoleClaims_RoleId",
                    table: "AspNetRoleClaims",
                    column: "RoleId");
            }

            if (!TableExists(migrationBuilder, "AspNetUserClaims"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetUserClaims",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        UserId = table.Column<string>(nullable: false),
                        ClaimType = table.Column<string>(nullable: true),
                        ClaimValue = table.Column<string>(nullable: true)
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
            }

            if (!TableExists(migrationBuilder, "AspNetUserLogins"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetUserLogins",
                    columns: table => new
                    {
                        LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                        ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                        ProviderDisplayName = table.Column<string>(nullable: true),
                        UserId = table.Column<string>(nullable: false)
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
            }

            if (!TableExists(migrationBuilder, "AspNetUserRoles"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetUserRoles",
                    columns: table => new
                    {
                        UserId = table.Column<string>(nullable: false),
                        RoleId = table.Column<string>(nullable: false)
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
            }

            if (!TableExists(migrationBuilder, "AspNetUserTokens"))
            {
                migrationBuilder.CreateTable(
                    name: "AspNetUserTokens",
                    columns: table => new
                    {
                        UserId = table.Column<string>(nullable: false),
                        LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                        Name = table.Column<string>(maxLength: 128, nullable: false),
                        Value = table.Column<string>(nullable: true)
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
            }

            if (!IndexExists(migrationBuilder, "RoleNameIndex", "AspNetRoles"))
            {
                migrationBuilder.CreateIndex(
                    name: "RoleNameIndex",
                    table: "AspNetRoles",
                    column: "NormalizedName",
                    unique: true,
                    filter: "[NormalizedName] IS NOT NULL");
            }

            if (!IndexExists(migrationBuilder, "IX_AspNetUserClaims_UserId", "AspNetUserClaims"))
            {
                migrationBuilder.CreateIndex(
                    name: "IX_AspNetUserClaims_UserId",
                    table: "AspNetUserClaims",
                    column: "UserId");
            }

            if (!IndexExists(migrationBuilder, "IX_AspNetUserLogins_UserId", "AspNetUserLogins"))
            {
                migrationBuilder.CreateIndex(
                    name: "IX_AspNetUserLogins_UserId",
                    table: "AspNetUserLogins",
                    column: "UserId");
            }

            if (!IndexExists(migrationBuilder, "IX_AspNetUserRoles_RoleId", "AspNetUserRoles"))
            {
                migrationBuilder.CreateIndex(
                    name: "IX_AspNetUserRoles_RoleId",
                    table: "AspNetUserRoles",
                    column: "RoleId");
            }

            if (!IndexExists(migrationBuilder, "EmailIndex", "AspNetUsers"))
            {
                migrationBuilder.CreateIndex(
                    name: "EmailIndex",
                    table: "AspNetUsers",
                    column: "NormalizedEmail");
            }

            if (!IndexExists(migrationBuilder, "UserNameIndex", "AspNetUsers"))
            {
                migrationBuilder.CreateIndex(
                    name: "UserNameIndex",
                    table: "AspNetUsers",
                    column: "NormalizedUserName",
                    unique: true,
                    filter: "[NormalizedUserName] IS NOT NULL");
            }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }

        private bool TableExists(MigrationBuilder migrationBuilder, string tableName)
        {
            var sql = $"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
            var result = migrationBuilder.Sql(sql).ToString();
            return !string.IsNullOrEmpty(result);
        }

        private bool IndexExists(MigrationBuilder migrationBuilder, string indexName, string tableName)
        {
            var sql = $"SELECT 1 FROM sys.indexes WHERE name = '{indexName}' AND object_id = OBJECT_ID('{tableName}')";
            var result = migrationBuilder.Sql(sql).ToString();
            return !string.IsNullOrEmpty(result);
        }
    }
}
