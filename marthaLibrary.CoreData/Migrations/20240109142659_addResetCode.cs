using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace marthaLibrary.CoreData.Migrations
{
    public partial class addResetCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    BookName = table.Column<string>(type: "text", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookName = table.Column<string>(type: "text", nullable: true),
                    Authors = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    FrontPagePicUrl = table.Column<string>(type: "text", nullable: true),
                    NoOfPages = table.Column<int>(type: "integer", nullable: false),
                    Langauge = table.Column<string>(type: "text", nullable: true),
                    ISBN = table.Column<string>(type: "text", nullable: true),
                    Format = table.Column<string>(type: "text", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifcations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    BookName = table.Column<string>(type: "text", nullable: true),
                    NotificationStatus = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifcations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Authors", "BookName", "DateCreated", "DatePublished", "DateUpdated", "DeletedBy", "Description", "Format", "FrontPagePicUrl", "ISBN", "IsDeleted", "Langauge", "NoOfPages", "Status" },
                values: new object[,]
                {
                    { 1L, null, "The Alchemist", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A shepherd boy travels to Egypt to find treasure and discovers his personal legend.", null, "https://example.com/alchemist.jpg", null, false, null, 0, 0 },
                    { 2L, null, "To Kill a Mockingbird", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A lawyer in the South defends a black man accused of rape.", null, "https://example.com/mockinbird.jpg", null, false, null, 0, 0 },
                    { 3L, null, "The Great Gatsby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A wealthy man tries to win back his lost love in the Jazz Age.", null, "https://example.com/gatsby.jpg", null, false, null, 0, 0 },
                    { 4L, null, "Pride and Prejudice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Bennet sisters navigate love and marriage in Georgian England.", null, "https://example.com/pride.jpg", null, false, null, 0, 0 },
                    { 5L, null, "1984", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A man rebels against a totalitarian government that controls everything.", null, "https://example.com/1984.jpg", null, false, null, 0, 0 },
                    { 6L, null, "The Catcher in the Rye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A teenage boy struggles with adolescence and the adult world.", null, "https://example.com/catcher.jpg", null, false, null, 0, 0 },
                    { 7L, null, "The Hobbit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A hobbit goes on an adventure to help reclaim a dwarven treasure.", null, "https://example.com/hobbit.jpg", null, false, null, 0, 0 },
                    { 8L, null, "The Lord of the Rings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Frodo Baggins carries the One Ring to Mount Doom to destroy it.", null, "https://example.com/lotr.jpg", null, false, null, 0, 0 },
                    { 9L, null, "The Hitchhiker's Guide to the Galaxy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A hapless human and his alien friend travel the galaxy in search of answers.", null, "https://example.com/hitchhiker.jpg", null, false, null, 0, 0 },
                    { 10L, null, "Brave New World", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A dystopian society controls citizens through conditioning and pleasure.", null, "https://example.com/brave.jpg", null, false, null, 0, 0 },
                    { 11L, null, "The Name of the Wind", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A legendary wizard tells his life story to a chronicler in a tavern.", null, "https://example.com/name-wind.jpg", null, false, null, 0, 0 },
                    { 12L, null, "The Girl with the Dragon Tattoo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A journalist investigates a wealthy family and enlists the help of a computer hacker.", null, "https://example.com/dragon-tattoo.jpg", null, false, null, 0, 0 },
                    { 13L, null, "The Hunger Games", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Teenagers compete in a televised death match in a dystopian society.", null, "https://example.com/hunger-games.jpg", null, false, null, 0, 0 },
                    { 14L, null, "The Road", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A father and son journey through a post-apocalyptic world.", null, "https://example.com/road.jpg", null, false, null, 0, 0 },
                    { 15L, null, "The Count of Monte Cristo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A man takes revenge on those who wronged him after being falsely imprisoned.", null, "https://example.com/monte-cristo.jpg", null, false, null, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "DeletedBy", "Email", "IsDeleted", "Name", "PasswordHash", "Role" },
                values: new object[] { new Guid("00578bef-97e5-48ff-871c-19151e2e35af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "martha@elibrary.com", false, "Martha Admin", "$2a$11$wL/Pv4lYZos0rZMbgmVtEu/9JXJQDLl9.Jq9YIb36xUEx6vpQfZ3u", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLogs");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Notifcations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
