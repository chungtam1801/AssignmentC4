using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class AddClothesProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Clothes_ClothesID",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetil_Clothes_ClothesID",
                table: "CartDetil");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "ClothesID",
                table: "CartDetil",
                newName: "ClothesDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetil_ClothesID",
                table: "CartDetil",
                newName: "IX_CartDetil_ClothesDetailID");

            migrationBuilder.RenameColumn(
                name: "ClothesID",
                table: "BillDetail",
                newName: "ClothesDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetail_ClothesID",
                table: "BillDetail",
                newName: "IX_BillDetail_ClothesDetailID");

            migrationBuilder.AddColumn<Guid>(
                name: "ClothesTypeID",
                table: "Clothes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ClothesTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DadTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothesTypes_ClothesTypes_DadTypeID",
                        column: x => x.DadTypeID,
                        principalTable: "ClothesTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClothesDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClothesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothesDetails_Clothes_ClothesID",
                        column: x => x.ClothesID,
                        principalTable: "Clothes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothesDetails_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothesDetails_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ClothesTypeID",
                table: "Clothes",
                column: "ClothesTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesDetails_ClothesID",
                table: "ClothesDetails",
                column: "ClothesID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesDetails_ColorID",
                table: "ClothesDetails",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesDetails_SizeID",
                table: "ClothesDetails",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesTypes_DadTypeID",
                table: "ClothesTypes",
                column: "DadTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_ClothesDetails_ClothesDetailID",
                table: "BillDetail",
                column: "ClothesDetailID",
                principalTable: "ClothesDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetil_ClothesDetails_ClothesDetailID",
                table: "CartDetil",
                column: "ClothesDetailID",
                principalTable: "ClothesDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClothesTypes_ClothesTypeID",
                table: "Clothes",
                column: "ClothesTypeID",
                principalTable: "ClothesTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_ClothesDetails_ClothesDetailID",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetil_ClothesDetails_ClothesDetailID",
                table: "CartDetil");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClothesTypes_ClothesTypeID",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "ClothesDetails");

            migrationBuilder.DropTable(
                name: "ClothesTypes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_ClothesTypeID",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ClothesTypeID",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "ClothesDetailID",
                table: "CartDetil",
                newName: "ClothesID");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetil_ClothesDetailID",
                table: "CartDetil",
                newName: "IX_CartDetil_ClothesID");

            migrationBuilder.RenameColumn(
                name: "ClothesDetailID",
                table: "BillDetail",
                newName: "ClothesID");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetail_ClothesDetailID",
                table: "BillDetail",
                newName: "IX_BillDetail_ClothesID");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Clothes_ClothesID",
                table: "BillDetail",
                column: "ClothesID",
                principalTable: "Clothes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetil_Clothes_ClothesID",
                table: "CartDetil",
                column: "ClothesID",
                principalTable: "Clothes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
