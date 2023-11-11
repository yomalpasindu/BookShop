using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.DataAccess.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Martin Wickramasinghe" },
                    { 2, "F. Scott Fitzgerald" },
                    { 3, "Harper Lee" },
                    { 4, "George Orwell" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Discount" },
                values: new object[,]
                {
                    { 1, "Novel", 0 },
                    { 2, "Transtalions", 0 },
                    { 3, "Kids", 5 }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Description", "Discount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "Famous Book in Sri Lanka", 0, "Madolduwa", 500 },
                    { 2, 2, 2, "A Journey into Tranquility", 10, "Serenity's Embrace", 650 },
                    { 3, 3, 1, "Timeless Epic Adventure", 5, "Echoes of Eternity", 750 },
                    { 4, 4, 3, "Mystical Tales of the Unknown", 15, "Whispers in the Wind", 600 },
                    { 5, 1, 2, "Fate Unveiled", 8, "Chronicles of Destiny", 700 },
                    { 6, 2, 1, "A Tale of Love and Loss", 12, "Silent Echo", 550 },
                    { 7, 3, 3, "Visions of Imagination", 0, "Ephemeral Dreams", 800 },
                    { 8, 4, 2, "A Rollercoaster of Feelings", 10, "Whirlwind of Emotions", 680 },
                    { 9, 1, 1, "Blood-Pumping Thrills", 5, "Crimson Skies", 720 },
                    { 10, 2, 3, "Radiant Tales of Hope", 8, "Luminescent Horizon", 590 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoryId",
                table: "books",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
