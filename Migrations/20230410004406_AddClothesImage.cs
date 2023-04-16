using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class AddClothesImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothesDetails_Colors_ColorID",
                table: "ClothesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothesDetails_Sizes_SizeID",
                table: "ClothesDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "SizeID",
                table: "ClothesDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ColorID",
                table: "ClothesDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImamgeLocation",
                table: "Clothes",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesDetails_Colors_ColorID",
                table: "ClothesDetails",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesDetails_Sizes_SizeID",
                table: "ClothesDetails",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothesDetails_Colors_ColorID",
                table: "ClothesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothesDetails_Sizes_SizeID",
                table: "ClothesDetails");

            migrationBuilder.DropColumn(
                name: "ImamgeLocation",
                table: "Clothes");

            migrationBuilder.AlterColumn<Guid>(
                name: "SizeID",
                table: "ClothesDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ColorID",
                table: "ClothesDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesDetails_Colors_ColorID",
                table: "ClothesDetails",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothesDetails_Sizes_SizeID",
                table: "ClothesDetails",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "ID");
        }
    }
}
