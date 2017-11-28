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
                name: "action_record",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    data_type = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    content_text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    typeid = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_action_record", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assign_room",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assign_time = table.Column<DateTime>(nullable: false),
                    coefficient = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    room_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assign_room", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assign_room_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    coefficient = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    deadline = table.Column<DateTime>(nullable: false),
                    fromtime = table.Column<DateTime>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assign_room_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_request",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assign_userid = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    data_type = table.Column<int>(nullable: false),
                    expect_time = table.Column<DateTime>(nullable: false),
                    finish_status = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    message_text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_request", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_request_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    customer_request_define_id = table.Column<int>(nullable: false),
                    customer_request_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_request_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    appkey = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    background = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    hotel_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    interface_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    role_name = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_room",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    is_checked = table.Column<bool>(type: "bit", maxLength: 30, nullable: false),
                    is_contradiction = table.Column<bool>(type: "bit", maxLength: 30, nullable: false),
                    is_due_in = table.Column<bool>(type: "bit", maxLength: 30, nullable: false),
                    is_due_out = table.Column<bool>(type: "bit", maxLength: 30, nullable: false),
                    is_rush = table.Column<bool>(type: "bit", maxLength: 30, nullable: false),
                    pms_room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    room_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    room_type_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_room", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_supply_define",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    data_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    data_note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    data_type = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_supply_define", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    roleid = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "minibar_consume",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    finish_status = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    is_closed = table.Column<bool>(nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_minibar_consume", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "minibar_cunsume_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    minibar_consume_id = table.Column<int>(nullable: false),
                    minibar_product_id = table.Column<int>(nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_minibar_cunsume_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "minibar_product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    minibar_id = table.Column<int>(nullable: false),
                    package_count = table.Column<int>(nullable: false),
                    product_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    unit_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_minibar_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "minibar_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    minibar_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_minibar_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pms_product_define",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    appkey = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    source = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    token = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    token_effective_second = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pms_product_define", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room_minibar",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    minibar_id = table.Column<int>(maxLength: 30, nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_minibar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room_product_package",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    minibar_product_id = table.Column<int>(nullable: false),
                    package_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    package_count = table.Column<int>(nullable: false),
                    package_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_product_package", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    auth_type = table.Column<int>(type: "smallint", nullable: false),
                    avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    confirmed = table.Column<bool>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    employee_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    mobile_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    nickname = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_group",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    group_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_group_member",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    group_id = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_group_member", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "verification_code",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    mobile_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    request_id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    send_status = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    verify_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verification_code", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "welcome_plan",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    data_type = table.Column<int>(nullable: false),
                    deadline = table.Column<DateTime>(nullable: false),
                    fromtime = table.Column<DateTime>(nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    show_day_type = table.Column<int>(nullable: false),
                    specific_day = table.Column<int>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    welcome_text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_welcome_plan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workload",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    check_time = table.Column<DateTime>(nullable: false),
                    check_userid = table.Column<int>(nullable: false),
                    coefficient = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    create_time = table.Column<DateTime>(nullable: false),
                    creator_id = table.Column<int>(nullable: false),
                    data_sort = table.Column<int>(nullable: false),
                    data_state = table.Column<int>(nullable: false),
                    endto_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    finish_status = table.Column<int>(nullable: false),
                    finish_time = table.Column<DateTime>(nullable: false),
                    from_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    hotel_id = table.Column<int>(nullable: false),
                    is_checked = table.Column<bool>(nullable: false),
                    message_text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    relation_id = table.Column<int>(nullable: false),
                    receiver_userid = table.Column<int>(nullable: false),
                    room_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    start_time = table.Column<DateTime>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false),
                    updater_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false),
                    work_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workload", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "action_record");

            migrationBuilder.DropTable(
                name: "assign_room");

            migrationBuilder.DropTable(
                name: "assign_room_history");

            migrationBuilder.DropTable(
                name: "customer_request");

            migrationBuilder.DropTable(
                name: "customer_request_item");

            migrationBuilder.DropTable(
                name: "hotel");

            migrationBuilder.DropTable(
                name: "hotel_role");

            migrationBuilder.DropTable(
                name: "hotel_room");

            migrationBuilder.DropTable(
                name: "hotel_supply_define");

            migrationBuilder.DropTable(
                name: "hotel_user");

            migrationBuilder.DropTable(
                name: "minibar_consume");

            migrationBuilder.DropTable(
                name: "minibar_cunsume_item");

            migrationBuilder.DropTable(
                name: "minibar_product");

            migrationBuilder.DropTable(
                name: "minibar_type");

            migrationBuilder.DropTable(
                name: "pms_product_define");

            migrationBuilder.DropTable(
                name: "room_minibar");

            migrationBuilder.DropTable(
                name: "room_product_package");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_group");

            migrationBuilder.DropTable(
                name: "user_group_member");

            migrationBuilder.DropTable(
                name: "verification_code");

            migrationBuilder.DropTable(
                name: "welcome_plan");

            migrationBuilder.DropTable(
                name: "workload");
        }
    }
}
