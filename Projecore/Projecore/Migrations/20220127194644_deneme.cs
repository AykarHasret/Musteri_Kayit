using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecore.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firma_adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mernis_kontrol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Uyelers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dogumyil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Firmaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyelers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Uyelers_Firmas_Firmaid",
                        column: x => x.Firmaid,
                        principalTable: "Firmas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uyelers_Firmaid",
                table: "Uyelers",
                column: "Firmaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uyelers");

            migrationBuilder.DropTable(
                name: "Firmas");
        }
    }
}
