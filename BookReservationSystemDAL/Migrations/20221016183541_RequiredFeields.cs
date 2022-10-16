using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReservationSystemDAL.Migrations
{
    public partial class RequiredFeields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksInLibrary");

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("c550f216-10d8-416f-8cad-19a184f103fd"), new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), new Guid("2ffdc4a0-5bff-4ef2-b092-ca613b55cb40") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), new Guid("77e0c355-44a6-4e25-ac14-d7d6439e0b3d") });

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("f1d08916-dcb4-4c80-b6a7-8729000ac5c8"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fbdb9c5d-8e48-4821-887b-9f2570c7d6cd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4bb6d198-3eed-47a6-b9c6-59051e67c8be"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("c550f216-10d8-416f-8cad-19a184f103fd"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("77e0c355-44a6-4e25-ac14-d7d6439e0b3d"));

            migrationBuilder.DeleteData(
                table: "Library",
                keyColumn: "Id",
                keyValue: new Guid("63f88ca5-783b-431b-8033-0daf8c76527f"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("2ffdc4a0-5bff-4ef2-b092-ca613b55cb40"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("127c86df-b07c-4bcb-af71-5c5067e1daa4"));

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("7b0bbcff-9c82-4769-9acb-6ea6a9661c28"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "User",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Review",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Reservation",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Reservation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Library",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CoverArtUrl",
                table: "Book",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BookQuantity",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookQuantity", x => new { x.BookId, x.LibraryId });
                    table.ForeignKey(
                        name: "FK_BookQuantity_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookQuantity_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("2a774a64-525a-44eb-8e7a-fa3addcee172"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("28a10a88-7d53-49d8-9588-90f9bed4e485"), "Kerkeling Hape" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "CoverArtUrl", "ISBN", "Name" },
                values: new object[] { new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", "https://www.knihydobrovsky.cz/thumbs/book-detail-fancy-box/mod_eshop/produkty/m/moje-kocky-cizi-kocky-a-ja-9788024282442.jpg", 9788024282442L, "Moje kočky, cizí kočky a já" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("21578d23-cf8f-456d-b948-911ec43a63a8"), "Satire" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("bbbf1d7a-fee8-497f-9a6c-768162bff79d"), "EUROMEDIA GROUP, a.s." });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7e2bfa6f-9b03-4d7f-bcad-f0c1033868ee"), "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PasswordSalt" },
                values: new object[,]
                {
                    { new Guid("514deb4e-4602-4433-904f-2f050cad7953"), "wmonkman0@zdnet.com", "Westbrook", "Monkman", "RLreUYnARxnE", "" },
                    { new Guid("c6aa8c2d-e5e3-434f-bf75-781012cdee0a"), "mmaxworthy1@ning.com", "Madelene", "Maxworthy", "bo09BbrTa", "" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[] { new Guid("28a10a88-7d53-49d8-9588-90f9bed4e485"), new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47") });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[] { new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), new Guid("bbbf1d7a-fee8-497f-9a6c-768162bff79d") });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), new Guid("21578d23-cf8f-456d-b948-911ec43a63a8") });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { new Guid("9eee9984-6e69-4d25-bf6a-7cfe898d6b24"), new Guid("2a774a64-525a-44eb-8e7a-fa3addcee172"), "Knihy Dobrovsky" });

            migrationBuilder.InsertData(
                table: "BookQuantity",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[] { new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), new Guid("9eee9984-6e69-4d25-bf6a-7cfe898d6b24"), 1, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate", "ReturnDate" },
                values: new object[] { new Guid("fd6c5905-20d2-4cf6-98fb-5241c02b7bbc"), new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), new Guid("c6aa8c2d-e5e3-434f-bf75-781012cdee0a"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("9eee9984-6e69-4d25-bf6a-7cfe898d6b24"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_BookQuantity_LibraryId",
                table: "BookQuantity",
                column: "LibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookQuantity");

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("28a10a88-7d53-49d8-9588-90f9bed4e485"), new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), new Guid("bbbf1d7a-fee8-497f-9a6c-768162bff79d") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"), new Guid("21578d23-cf8f-456d-b948-911ec43a63a8") });

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("fd6c5905-20d2-4cf6-98fb-5241c02b7bbc"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7e2bfa6f-9b03-4d7f-bcad-f0c1033868ee"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("514deb4e-4602-4433-904f-2f050cad7953"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("28a10a88-7d53-49d8-9588-90f9bed4e485"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("8ba2a6e3-8c73-43dc-90b8-311fe917da47"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("21578d23-cf8f-456d-b948-911ec43a63a8"));

            migrationBuilder.DeleteData(
                table: "Library",
                keyColumn: "Id",
                keyValue: new Guid("9eee9984-6e69-4d25-bf6a-7cfe898d6b24"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("bbbf1d7a-fee8-497f-9a6c-768162bff79d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c6aa8c2d-e5e3-434f-bf75-781012cdee0a"));

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("2a774a64-525a-44eb-8e7a-fa3addcee172"));

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Library");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Review",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoverArtUrl",
                table: "Book",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "BooksInLibrary",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksInLibrary", x => new { x.BookId, x.LibraryId });
                    table.ForeignKey(
                        name: "FK_BooksInLibrary_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BooksInLibrary_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("7b0bbcff-9c82-4769-9acb-6ea6a9661c28"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c550f216-10d8-416f-8cad-19a184f103fd"), "Kerkeling Hape" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "CoverArtUrl", "ISBN", "Name" },
                values: new object[] { new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", "https://www.knihydobrovsky.cz/thumbs/book-detail-fancy-box/mod_eshop/produkty/m/moje-kocky-cizi-kocky-a-ja-9788024282442.jpg", 9788024282442L, "Moje kočky, cizí kočky a já" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("77e0c355-44a6-4e25-ac14-d7d6439e0b3d"), "Satire" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2ffdc4a0-5bff-4ef2-b092-ca613b55cb40"), "EUROMEDIA GROUP, a.s." });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fbdb9c5d-8e48-4821-887b-9f2570c7d6cd"), "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PasswordSalt" },
                values: new object[,]
                {
                    { new Guid("127c86df-b07c-4bcb-af71-5c5067e1daa4"), "mmaxworthy1@ning.com", "Madelene", "Maxworthy", "bo09BbrTa", "" },
                    { new Guid("4bb6d198-3eed-47a6-b9c6-59051e67c8be"), "wmonkman0@zdnet.com", "Westbrook", "Monkman", "RLreUYnARxnE", "" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[] { new Guid("c550f216-10d8-416f-8cad-19a184f103fd"), new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea") });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[] { new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), new Guid("2ffdc4a0-5bff-4ef2-b092-ca613b55cb40") });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), new Guid("77e0c355-44a6-4e25-ac14-d7d6439e0b3d") });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId" },
                values: new object[] { new Guid("63f88ca5-783b-431b-8033-0daf8c76527f"), new Guid("7b0bbcff-9c82-4769-9acb-6ea6a9661c28") });

            migrationBuilder.InsertData(
                table: "BooksInLibrary",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[] { new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), new Guid("63f88ca5-783b-431b-8033-0daf8c76527f"), 1, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate" },
                values: new object[] { new Guid("f1d08916-dcb4-4c80-b6a7-8729000ac5c8"), new Guid("d2d8752d-58d0-46d7-bf6f-ce0fe464a5ea"), new Guid("127c86df-b07c-4bcb-af71-5c5067e1daa4"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("63f88ca5-783b-431b-8033-0daf8c76527f"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_BooksInLibrary_LibraryId",
                table: "BooksInLibrary",
                column: "LibraryId");
        }
    }
}
