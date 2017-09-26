using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NTCore.WebFront.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    confirmed = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creator_id = table.Column<int>(type: "int", nullable: false),
                    data_state = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    mobile_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    update_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updater_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "varchar(32)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
