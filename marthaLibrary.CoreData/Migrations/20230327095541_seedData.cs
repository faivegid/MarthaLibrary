using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace marthaLibrary.CoreData.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "BookName", "DateCreated", "DateUpdated", "DeletedBy", "Description", "FrontPagePicUrl", "IsDeleted", "Status" },
                values: new object[,]
                {
                    { 1L, "Paulo Coelho", "The Alchemist", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A shepherd boy travels to Egypt to find treasure and discovers his personal legend.", "https://example.com/alchemist.jpg", false, 0 },
                    { 2L, "Harper Lee", "To Kill a Mockingbird", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A lawyer in the South defends a black man accused of rape.", "https://example.com/mockinbird.jpg", false, 0 },
                    { 3L, "F. Scott Fitzgerald", "The Great Gatsby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A wealthy man tries to win back his lost love in the Jazz Age.", "https://example.com/gatsby.jpg", false, 0 },
                    { 4L, "Jane Austen", "Pride and Prejudice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Bennet sisters navigate love and marriage in Georgian England.", "https://example.com/pride.jpg", false, 0 },
                    { 5L, "George Orwell", "1984", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A man rebels against a totalitarian government that controls everything.", "https://example.com/1984.jpg", false, 0 },
                    { 6L, "J.D. Salinger", "The Catcher in the Rye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A teenage boy struggles with adolescence and the adult world.", "https://example.com/catcher.jpg", false, 0 },
                    { 7L, "J.R.R. Tolkien", "The Hobbit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A hobbit goes on an adventure to help reclaim a dwarven treasure.", "https://example.com/hobbit.jpg", false, 0 },
                    { 8L, "J.R.R. Tolkien", "The Lord of the Rings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Frodo Baggins carries the One Ring to Mount Doom to destroy it.", "https://example.com/lotr.jpg", false, 0 },
                    { 9L, "Douglas Adams", "The Hitchhiker's Guide to the Galaxy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A hapless human and his alien friend travel the galaxy in search of answers.", "https://example.com/hitchhiker.jpg", false, 0 },
                    { 10L, "Aldous Huxley", "Brave New World", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A dystopian society controls citizens through conditioning and pleasure.", "https://example.com/brave.jpg", false, 0 },
                    { 11L, "Patrick Rothfuss", "The Name of the Wind", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A legendary wizard tells his life story to a chronicler in a tavern.", "https://example.com/name-wind.jpg", false, 0 },
                    { 12L, "Stieg Larsson", "The Girl with the Dragon Tattoo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A journalist investigates a wealthy family and enlists the help of a computer hacker.", "https://example.com/dragon-tattoo.jpg", false, 0 },
                    { 13L, "Suzanne Collins", "The Hunger Games", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Teenagers compete in a televised death match in a dystopian society.", "https://example.com/hunger-games.jpg", false, 0 },
                    { 14L, "Cormac McCarthy", "The Road", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A father and son journey through a post-apocalyptic world.", "https://example.com/road.jpg", false, 0 },
                    { 15L, "Alexandre Dumas", "The Count of Monte Cristo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A man takes revenge on those who wronged him after being falsely imprisoned.", "https://example.com/monte-cristo.jpg", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "DeletedBy", "Email", "IsDeleted", "Name", "PasswordHash", "Role" },
                values: new object[] { new Guid("cf49e46c-6b77-4219-95e2-3e8226226e36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "martha@elibrary.com", false, "Martha Admin", "$2a$11$YRh/zfwN/M/zHX6ZdtOuY.YmlE1F0A8Une6DbIbPS2fNBMd26RI5G", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf49e46c-6b77-4219-95e2-3e8226226e36"));
        }
    }
}
