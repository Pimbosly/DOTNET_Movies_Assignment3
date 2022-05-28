using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp_WebAPI_Assignment3.Migrations
{
    public partial class InitRelationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FranchiseId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Movie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseYear",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Trailer",
                table: "Movie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "The Pim", "Pim Westervoort", "Male", "www.picturepim.com" },
                    { 2, "Master of .NET", "Warren West", "Male", "www.picturewarren.com" },
                    { 3, "Master of Javascript", "Dewald Els", "Male", "www.picturedewald.com" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Movies about a superhero in a batcostume", "Batman Trilogy" },
                    { 2, "Movies about a flying superhero in a cape", "Superman Trilogy" },
                    { 3, "Movies about a detective solving mysteries", "Holmes" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CharacterId", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, 3, "batman director", 1, "Action", "www.batmanpicture.com", new DateTime(2003, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman", "www.batmantrailer.com" },
                    { 2, 2, "superman director", 2, "Action", "www.supermanpicture.com", new DateTime(2002, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superman", "www.supermantrailer.com" },
                    { 3, 1, "holmes director", 3, "Detective, Action", "www.holmespicture.com", new DateTime(2010, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sherlock Holmes", "www.holmestrailer.com" },
                    { 4, 2, "IT director", 3, "Horror", "www.itpicture.com", new DateTime(2012, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "www.ittrailer.com" },
                    { 5, 1, "stardust director", 2, "Fantasy, Adventure", "www.stardustpicture.com", new DateTime(2009, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stardust", "www.stardusttrailer.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CharacterId",
                table: "Movie",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Character_CharacterId",
                table: "Movie",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Franchise_FranchiseId",
                table: "Movie",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Character_CharacterId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Franchise_FranchiseId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CharacterId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie");

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Trailer",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
