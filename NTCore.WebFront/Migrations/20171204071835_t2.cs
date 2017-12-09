using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NTCore.WebFront.Migrations
{
    public partial class t2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "workload_step",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "workload",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "welcome_plan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "verification_code",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "user_group_member",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "user_group",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "user",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "room_product_package",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "room_minibar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "repair_place_define",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "pms_product_define",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "minibar_type",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "minibar_product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "minibar_cunsume_item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "minibar_consume",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "message_template",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "message_receiver",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "message_center",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "hotel_user",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "hotel_supply_define",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "hotel_room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "hotel_role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "hotel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "customer_request_item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "duration_seconds",
                table: "customer_request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "customer_request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "attachment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "assign_room_history",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "assign_room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "is_disable",
                table: "action_record",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "workload_step");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "workload");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "welcome_plan");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "verification_code");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "user_group_member");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "user_group");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "room_product_package");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "room_minibar");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "repair_place_define");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "pms_product_define");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "minibar_type");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "minibar_product");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "minibar_cunsume_item");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "minibar_consume");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "message_template");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "message_receiver");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "message_center");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "hotel_user");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "hotel_supply_define");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "hotel_room");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "hotel_role");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "customer_request_item");

            migrationBuilder.DropColumn(
                name: "duration_seconds",
                table: "customer_request");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "customer_request");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "attachment");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "assign_room_history");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "assign_room");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "action_record");
        }
    }
}
