using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NTCore.WebFront.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "action_record",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    data_type = table.Column<int>(nullable: false),
                    site_id = table.Column<int>(nullable: false),
                    content_text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    typeid = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_action_record", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    allow_comment = table.Column<bool>(nullable: false),
                    base_click = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    channel_id = table.Column<int>(nullable: false),
                    click_count = table.Column<int>(nullable: false),
                    text_content = table.Column<string>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    is_hot = table.Column<bool>(nullable: false),
                    is_slide = table.Column<bool>(nullable: false),
                    is_system = table.Column<bool>(nullable: false),
                    is_top = table.Column<bool>(nullable: false),
                    link_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    publish_status = table.Column<int>(type: "tinyint", nullable: false),
                    seo_description = table.Column<string>(maxLength: 255, nullable: false),
                    seo_keywords = table.Column<string>(maxLength: 255, nullable: false),
                    seo_title = table.Column<string>(maxLength: 255, nullable: false),
                    site_id = table.Column<int>(nullable: false),
                    summary = table.Column<string>(maxLength: 4000, nullable: false),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    title_color = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    title_image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "site",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    expire_time = table.Column<DateTime>(nullable: false),
                    site_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    site_state = table.Column<int>(type: "tinyint", nullable: false),
                    site_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    confirmed = table.Column<bool>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    mobile_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    nickname = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    site_id = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "action_record");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "site");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
