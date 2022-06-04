using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projects.Infrastructure.Persistence.Migrations
{
    public partial class changeObjectModelConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Colour_Code",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Songs",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Artists",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Albums",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Albums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Albums",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Colour_Code",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Songs",
                type: "image",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Artists",
                type: "image",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Albums",
                type: "image",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
