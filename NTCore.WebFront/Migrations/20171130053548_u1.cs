using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NTCore.WebFront.Migrations
{
    public partial class u1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "endto_status",
                table: "workload",
                newName: "to_status");

            migrationBuilder.AddColumn<int>(
                name: "work_seconds",
                table: "workload",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "auth_type",
                table: "user",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "smallint");

            migrationBuilder.AddColumn<bool>(
                name: "work_ready",
                table: "user",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "coefficient",
                table: "hotel_room",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "is_cleaning",
                table: "hotel_room",
                type: "bit",
                maxLength: 30,
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    dir_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    full_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    relation_id = table.Column<int>(nullable: false),
                    relation_Type = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "message_center",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    template_text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_center", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "message_receiver",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    message_center_id = table.Column<int>(nullable: false),
                    send_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_receiver", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "message_template",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    group_type = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    template_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    template_text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_template", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "repair_place_define",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: false),
                    place_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair_place_define", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workload_step",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    step_type = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false),
                    workload_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workload_step", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "message_center");

            migrationBuilder.DropTable(
                name: "message_receiver");

            migrationBuilder.DropTable(
                name: "message_template");

            migrationBuilder.DropTable(
                name: "repair_place_define");

            migrationBuilder.DropTable(
                name: "workload_step");

            migrationBuilder.DropColumn(
                name: "work_seconds",
                table: "workload");

            migrationBuilder.DropColumn(
                name: "work_ready",
                table: "user");

            migrationBuilder.DropColumn(
                name: "coefficient",
                table: "hotel_room");

            migrationBuilder.DropColumn(
                name: "is_cleaning",
                table: "hotel_room");

            migrationBuilder.RenameColumn(
                name: "to_status",
                table: "workload",
                newName: "endto_status");

            migrationBuilder.AlterColumn<int>(
                name: "auth_type",
                table: "user",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
