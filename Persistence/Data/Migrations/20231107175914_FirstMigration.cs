using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persontype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCountryFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdCountry",
                        column: x => x.IdCountryFk,
                        principalTable: "country",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdStateFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdState",
                        column: x => x.IdStateFk,
                        principalTable: "state",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdentiNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdPersonTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdCityFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdCity",
                        column: x => x.IdCityFk,
                        principalTable: "city",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdPersonType",
                        column: x => x.IdPersonTypeFk,
                        principalTable: "persontype",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_IdState",
                table: "city",
                column: "IdStateFk");

            migrationBuilder.CreateIndex(
                name: "Name",
                table: "city",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name1",
                table: "country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_IdCity",
                table: "customer",
                column: "IdCityFk");

            migrationBuilder.CreateIndex(
                name: "FK_IdPersonType",
                table: "customer",
                column: "IdPersonTypeFk");

            migrationBuilder.CreateIndex(
                name: "IdentiNumber",
                table: "customer",
                column: "IdentiNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name2",
                table: "persontype",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_IdCountry",
                table: "state",
                column: "IdCountryFk");

            migrationBuilder.CreateIndex(
                name: "Name3",
                table: "state",
                column: "Name",
                unique: true); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "persontype");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "country"); */
        }
    }
}
