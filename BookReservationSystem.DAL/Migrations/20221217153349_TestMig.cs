using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReservationSystem.DAL.Migrations
{
    public partial class TestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1447ef0d-129b-4713-b1c1-44d9647b9b97"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4366cf83-3567-45c2-9d74-4b5bb66705d6"));

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("2eb889de-5559-4e4a-be22-ce13d3cbeb66"), new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("9b439bde-626c-4300-84ae-8179a45108c4"), new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("dc8d15af-fb5a-412a-8fce-806e13dfd02f"), new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("e0148911-65fe-470f-9e22-56388d0e6ee5"), new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("fca5b072-0845-4920-bd9c-e646bbcb9340"), new Guid("f821efaa-f511-4b2f-a659-48803290ed9c") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), new Guid("c7f66efd-6949-4239-bfbb-881d5bdfe5da") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), new Guid("2445a74c-6c2c-4a6a-ac46-031142aa998b") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), new Guid("52aace75-e28b-4435-bb95-3f40d9a6c0d0") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("9cf2c2b5-2261-40b8-b776-b5228ec28adb") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), new Guid("2445a74c-6c2c-4a6a-ac46-031142aa998b") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), new Guid("17b979cb-ce86-462d-8d6d-4524f96146dd") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), new Guid("17b979cb-ce86-462d-8d6d-4524f96146dd") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), new Guid("31c5180a-abb0-4590-b83f-abfb3e5b7b0f") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("cebf2a6f-546f-45e5-b31a-401f63023da9") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), new Guid("cec4a462-a31e-46df-b2ab-40b23ffad851") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), new Guid("503c472b-e993-46fc-8339-ae321b66120a") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), new Guid("503c472b-e993-46fc-8339-ae321b66120a") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), new Guid("503c472b-e993-46fc-8339-ae321b66120a") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("503c472b-e993-46fc-8339-ae321b66120a") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), new Guid("503c472b-e993-46fc-8339-ae321b66120a") });

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("566a24af-3bf9-4480-b4f7-88d0da7ab080"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("d893ed98-334f-41d4-b2fe-18fd2e079064"));

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("767445a9-42bc-4ee1-b103-9c01d6f510d4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4687fc0f-fb27-42ca-a661-6634b81d511d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("550c94e9-8b01-4f17-b05b-1e03d6e8e651"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4687fc0f-fb27-42ca-a661-6634b81d511d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("550c94e9-8b01-4f17-b05b-1e03d6e8e651"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("04ab692a-ac83-4901-9eaf-d0b7de5fb17c"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("2eb889de-5559-4e4a-be22-ce13d3cbeb66"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("9b439bde-626c-4300-84ae-8179a45108c4"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("dc8d15af-fb5a-412a-8fce-806e13dfd02f"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("e0148911-65fe-470f-9e22-56388d0e6ee5"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("fca5b072-0845-4920-bd9c-e646bbcb9340"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("17b979cb-ce86-462d-8d6d-4524f96146dd"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("31c5180a-abb0-4590-b83f-abfb3e5b7b0f"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("cebf2a6f-546f-45e5-b31a-401f63023da9"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("cec4a462-a31e-46df-b2ab-40b23ffad851"));

            migrationBuilder.DeleteData(
                table: "Library",
                keyColumn: "Id",
                keyValue: new Guid("503c472b-e993-46fc-8339-ae321b66120a"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("2445a74c-6c2c-4a6a-ac46-031142aa998b"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("52aace75-e28b-4435-bb95-3f40d9a6c0d0"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("9cf2c2b5-2261-40b8-b776-b5228ec28adb"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("c7f66efd-6949-4239-bfbb-881d5bdfe5da"));

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("09e49638-929d-42cc-9072-b1d4bc4753a5"));

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("453eb8df-b3f8-4116-a972-e531088a79fc"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a1da8ec-0873-416e-beef-ac93a3e695d1"), "28758a0d-e225-445a-b11c-e7eb74d708ba", "User", "USER" },
                    { new Guid("9aea0ff7-68c1-4517-943a-fcdfd3204a90"), "f9c1382e-9817-4de1-836f-4c921fb69639", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("188deb04-0fa9-4df0-9ef6-6b7e2cb15af2"), 0, "1ab0f734-f8de-418a-9637-828b17984d3b", "mmaxworthy1@ning.com", false, "Madelene", "Maxworthy", false, null, null, null, "bo09BbrTa", null, false, null, false, "maxworthy" },
                    { new Guid("226391f5-314f-4d06-a47b-077a7a477ca6"), 0, "0d63c9d3-8400-497f-921a-961123659d9e", "demo@gmail.com", false, "demo", "demo", false, null, "DEMO@GMAIL.COM", "DEMO", "AQAAAAEAACcQAAAAEI56EuIXWNrKlnYOdNxWJx+bnMJ0WWTjpo3Mn3P7HPBGV78AQjb9BJomuebALvEIqQ==", null, false, "57fa57e3-eaa0-4b54-baa1-97993777fc06", false, "demo" },
                    { new Guid("8c0a847b-08c1-4622-b3ed-77c3dda3531a"), 0, "855a678b-4839-4d09-9e32-8007ec394e85", "wmonkman0@zdnet.com", false, "Westbrook", "Monkman", false, null, null, null, "RLreUYnARxnE", null, false, null, false, "monkman" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("47163982-b575-41cf-a58c-2811f8d03371"), "Lars Kepler" },
                    { new Guid("4dcd31c6-f7ee-45b7-be22-2810f0e01dbc"), "Stephen King" },
                    { new Guid("a85e21f4-a3f2-415a-98c2-7238430d6483"), "John Tolkien" },
                    { new Guid("b3adf8f8-d3e6-4150-8ee9-3348e0eb47cb"), "Bram Stoker" },
                    { new Guid("fa2fbd16-db26-4de3-8dd1-3ad31d5ff928"), "Kerkeling Hape" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "AverageRating", "CoverArtPath", "Isbn", "Name" },
                values: new object[,]
                {
                    { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), "", 0f, "~/book_covers/dracula.jpg", 9780141199337L, "Dracula" },
                    { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), "Toto je příběh o tom, kterak se Pytlík vydal za dobrodružstvím a shledal, že náhle dělá a říká naprosto neočekávané věci… Bilbo Pytlík je hobit, který se těší z pohodlnéh a skromného života a jen zřídkakdy putuje dále než do své spižírny ve Dně pytle. Jeho spokojené bytí je však narušeno, když se jednoho dne u jeho prahu objeví čaroděj Gandalf v doprovodu třinácti trpaslíků a vezmou ho s sebou na cestu \"tam a zase zpátky\". Mají v úmyslu uloupit poklad mocného Šmaka, velikého a velmi nebezpečného draka... ", 0f, "~/book_covers/hobbit.jpg", 9788025707418L, "Hobbit" },
                    { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), "Joona Linna se znovu ocitá v ohrožení života a zachránit ho může jedině Saga Bauerová.", 0f, "~/book_covers/pavouk.jpg", 9788027513765L, "Pavouk" },
                    { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), "peepo", 0f, "~/book_covers/the-shining.jpg", 9788055138343L, "Shining" },
                    { new Guid("9d11f146-f6af-4220-8963-941375d72796"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", 0f, "~/book_covers/kockybookcover.jpg", 9788024282442L, "Moje kočky, cizí kočky a já" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0990dbf0-2684-4734-bc4c-c8daef8c309c"), "Comic" },
                    { new Guid("0d5dde14-dccc-4525-92cd-285c2787de0a"), "Horor" },
                    { new Guid("b0b71879-23e8-43dd-89a0-7af6d42b5cc8"), "Detective" },
                    { new Guid("be69de21-7115-4a6f-991a-e43dbd6e4178"), "Beletry" },
                    { new Guid("bfc4f4e4-2e43-437e-ab20-ba02e83f4a50"), "Satire" },
                    { new Guid("f1013404-9a88-45b7-9c02-c70618897af7"), "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("145522ff-cdb0-45dd-b7df-e2fc81d85c0e"), "Ikar" },
                    { new Guid("3ea4139d-f1c4-45ac-b8b1-343c786d1593"), "EUROMEDIA GROUP, a.s." },
                    { new Guid("5f09769b-45b2-42a8-bc10-a67d7d77d849"), "Host" },
                    { new Guid("63329b85-bd29-4f91-b91e-537cc406f053"), "ARGO" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("47163982-b575-41cf-a58c-2811f8d03371"), new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc") },
                    { new Guid("4dcd31c6-f7ee-45b7-be22-2810f0e01dbc"), new Guid("98bac83d-1254-43a1-a4db-d2a24566d930") },
                    { new Guid("a85e21f4-a3f2-415a-98c2-7238430d6483"), new Guid("55c2988e-5365-46a7-bf35-04babe516ccb") },
                    { new Guid("b3adf8f8-d3e6-4150-8ee9-3348e0eb47cb"), new Guid("0227fd3b-628a-49d2-ab28-310865072fd8") },
                    { new Guid("fa2fbd16-db26-4de3-8dd1-3ad31d5ff928"), new Guid("9d11f146-f6af-4220-8963-941375d72796") }
                });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[,]
                {
                    { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), new Guid("63329b85-bd29-4f91-b91e-537cc406f053") },
                    { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), new Guid("63329b85-bd29-4f91-b91e-537cc406f053") },
                    { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), new Guid("5f09769b-45b2-42a8-bc10-a67d7d77d849") },
                    { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), new Guid("145522ff-cdb0-45dd-b7df-e2fc81d85c0e") },
                    { new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("3ea4139d-f1c4-45ac-b8b1-343c786d1593") }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), new Guid("0d5dde14-dccc-4525-92cd-285c2787de0a") },
                    { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), new Guid("f1013404-9a88-45b7-9c02-c70618897af7") },
                    { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), new Guid("be69de21-7115-4a6f-991a-e43dbd6e4178") },
                    { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), new Guid("0d5dde14-dccc-4525-92cd-285c2787de0a") },
                    { new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("bfc4f4e4-2e43-437e-ab20-ba02e83f4a50") }
                });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), new Guid("453eb8df-b3f8-4116-a972-e531088a79fc"), "Knihy Dobrovský" });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0a1da8ec-0873-416e-beef-ac93a3e695d1"),
                    new Guid("9aea0ff7-68c1-4517-943a-fcdfd3204a90")
                });

            migrationBuilder.InsertData(
                table: "BookQuantity",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[,]
                {
                    { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), 0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate", "ReturnDate" },
                values: new object[] { new Guid("a9bb8f10-cf66-4277-9d75-7930a6fac426"), new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("188deb04-0fa9-4df0-9ef6-6b7e2cb15af2"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("226391f5-314f-4d06-a47b-077a7a477ca6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c0a847b-08c1-4622-b3ed-77c3dda3531a"));

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("47163982-b575-41cf-a58c-2811f8d03371"), new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("4dcd31c6-f7ee-45b7-be22-2810f0e01dbc"), new Guid("98bac83d-1254-43a1-a4db-d2a24566d930") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("a85e21f4-a3f2-415a-98c2-7238430d6483"), new Guid("55c2988e-5365-46a7-bf35-04babe516ccb") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("b3adf8f8-d3e6-4150-8ee9-3348e0eb47cb"), new Guid("0227fd3b-628a-49d2-ab28-310865072fd8") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("fa2fbd16-db26-4de3-8dd1-3ad31d5ff928"), new Guid("9d11f146-f6af-4220-8963-941375d72796") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), new Guid("63329b85-bd29-4f91-b91e-537cc406f053") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), new Guid("63329b85-bd29-4f91-b91e-537cc406f053") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), new Guid("5f09769b-45b2-42a8-bc10-a67d7d77d849") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), new Guid("145522ff-cdb0-45dd-b7df-e2fc81d85c0e") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("3ea4139d-f1c4-45ac-b8b1-343c786d1593") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), new Guid("0d5dde14-dccc-4525-92cd-285c2787de0a") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), new Guid("f1013404-9a88-45b7-9c02-c70618897af7") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), new Guid("be69de21-7115-4a6f-991a-e43dbd6e4178") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), new Guid("0d5dde14-dccc-4525-92cd-285c2787de0a") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("bfc4f4e4-2e43-437e-ab20-ba02e83f4a50") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("9d11f146-f6af-4220-8963-941375d72796"), new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022") });

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("0990dbf0-2684-4734-bc4c-c8daef8c309c"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("b0b71879-23e8-43dd-89a0-7af6d42b5cc8"));

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("a9bb8f10-cf66-4277-9d75-7930a6fac426"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0a1da8ec-0873-416e-beef-ac93a3e695d1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9aea0ff7-68c1-4517-943a-fcdfd3204a90"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a1da8ec-0873-416e-beef-ac93a3e695d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9aea0ff7-68c1-4517-943a-fcdfd3204a90"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("188deb04-0fa9-4df0-9ef6-6b7e2cb15af2"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("47163982-b575-41cf-a58c-2811f8d03371"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("4dcd31c6-f7ee-45b7-be22-2810f0e01dbc"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("a85e21f4-a3f2-415a-98c2-7238430d6483"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("b3adf8f8-d3e6-4150-8ee9-3348e0eb47cb"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("fa2fbd16-db26-4de3-8dd1-3ad31d5ff928"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("0227fd3b-628a-49d2-ab28-310865072fd8"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("55c2988e-5365-46a7-bf35-04babe516ccb"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("67b52446-1bd4-4e16-b415-7d8ec2a8f4dc"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("98bac83d-1254-43a1-a4db-d2a24566d930"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("9d11f146-f6af-4220-8963-941375d72796"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("0d5dde14-dccc-4525-92cd-285c2787de0a"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("be69de21-7115-4a6f-991a-e43dbd6e4178"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("bfc4f4e4-2e43-437e-ab20-ba02e83f4a50"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("f1013404-9a88-45b7-9c02-c70618897af7"));

            migrationBuilder.DeleteData(
                table: "Library",
                keyColumn: "Id",
                keyValue: new Guid("920710b4-30ea-43cc-9c86-cebe1b1a4022"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("145522ff-cdb0-45dd-b7df-e2fc81d85c0e"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("3ea4139d-f1c4-45ac-b8b1-343c786d1593"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("5f09769b-45b2-42a8-bc10-a67d7d77d849"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("63329b85-bd29-4f91-b91e-537cc406f053"));

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("453eb8df-b3f8-4116-a972-e531088a79fc"));

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("09e49638-929d-42cc-9072-b1d4bc4753a5"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4687fc0f-fb27-42ca-a661-6634b81d511d"), "4ab27566-2430-4a00-8367-d4b5fe4ec765", "Admin", "ADMIN" },
                    { new Guid("550c94e9-8b01-4f17-b05b-1e03d6e8e651"), "b9b95e9d-9839-499e-a2f0-fed18364a65d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("04ab692a-ac83-4901-9eaf-d0b7de5fb17c"), 0, "184efb74-65fc-4f97-9c4d-8015d4ce0b6e", "mmaxworthy1@ning.com", false, "Madelene", "Maxworthy", false, null, null, null, "bo09BbrTa", null, false, null, false, "maxworthy" },
                    { new Guid("1447ef0d-129b-4713-b1c1-44d9647b9b97"), 0, "c4cbdfa8-b617-46e0-9b79-db07fbc346cd", "wmonkman0@zdnet.com", false, "Westbrook", "Monkman", false, null, null, null, "RLreUYnARxnE", null, false, null, false, "monkman" },
                    { new Guid("4366cf83-3567-45c2-9d74-4b5bb66705d6"), 0, "ace4dcc5-7327-4c9a-90dd-f288c1db98da", "demo@gmail.com", false, "demo", "demo", false, null, "DEMO@GMAIL.COM", "DEMO", "AQAAAAEAACcQAAAAEI56EuIXWNrKlnYOdNxWJx+bnMJ0WWTjpo3Mn3P7HPBGV78AQjb9BJomuebALvEIqQ==", null, false, "5f37f3ad-b473-41ce-89b4-4cdccf7f2367", false, "demo" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2eb889de-5559-4e4a-be22-ce13d3cbeb66"), "Bram Stoker" },
                    { new Guid("9b439bde-626c-4300-84ae-8179a45108c4"), "Stephen King" },
                    { new Guid("dc8d15af-fb5a-412a-8fce-806e13dfd02f"), "Kerkeling Hape" },
                    { new Guid("e0148911-65fe-470f-9e22-56388d0e6ee5"), "Lars Kepler" },
                    { new Guid("fca5b072-0845-4920-bd9c-e646bbcb9340"), "John Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "AverageRating", "CoverArtPath", "Isbn", "Name" },
                values: new object[,]
                {
                    { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), "peepo", 0f, "~/book_covers/the-shining.jpg", 9788055138343L, "Shining" },
                    { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), "", 0f, "~/book_covers/dracula.jpg", 9780141199337L, "Dracula" },
                    { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), "Joona Linna se znovu ocitá v ohrožení života a zachránit ho může jedině Saga Bauerová.", 0f, "~/book_covers/pavouk.jpg", 9788027513765L, "Pavouk" },
                    { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", 0f, "~/book_covers/kockybookcover.jpg", 9788024282442L, "Moje kočky, cizí kočky a já" },
                    { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), "Toto je příběh o tom, kterak se Pytlík vydal za dobrodružstvím a shledal, že náhle dělá a říká naprosto neočekávané věci… Bilbo Pytlík je hobit, který se těší z pohodlnéh a skromného života a jen zřídkakdy putuje dále než do své spižírny ve Dně pytle. Jeho spokojené bytí je však narušeno, když se jednoho dne u jeho prahu objeví čaroděj Gandalf v doprovodu třinácti trpaslíků a vezmou ho s sebou na cestu \"tam a zase zpátky\". Mají v úmyslu uloupit poklad mocného Šmaka, velikého a velmi nebezpečného draka... ", 0f, "~/book_covers/hobbit.jpg", 9788025707418L, "Hobbit" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17b979cb-ce86-462d-8d6d-4524f96146dd"), "Horor" },
                    { new Guid("31c5180a-abb0-4590-b83f-abfb3e5b7b0f"), "Beletry" },
                    { new Guid("566a24af-3bf9-4480-b4f7-88d0da7ab080"), "Comic" },
                    { new Guid("cebf2a6f-546f-45e5-b31a-401f63023da9"), "Satire" },
                    { new Guid("cec4a462-a31e-46df-b2ab-40b23ffad851"), "Fantasy" },
                    { new Guid("d893ed98-334f-41d4-b2fe-18fd2e079064"), "Detective" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2445a74c-6c2c-4a6a-ac46-031142aa998b"), "ARGO" },
                    { new Guid("52aace75-e28b-4435-bb95-3f40d9a6c0d0"), "Host" },
                    { new Guid("9cf2c2b5-2261-40b8-b776-b5228ec28adb"), "EUROMEDIA GROUP, a.s." },
                    { new Guid("c7f66efd-6949-4239-bfbb-881d5bdfe5da"), "Ikar" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("2eb889de-5559-4e4a-be22-ce13d3cbeb66"), new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819") },
                    { new Guid("9b439bde-626c-4300-84ae-8179a45108c4"), new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30") },
                    { new Guid("dc8d15af-fb5a-412a-8fce-806e13dfd02f"), new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda") },
                    { new Guid("e0148911-65fe-470f-9e22-56388d0e6ee5"), new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9") },
                    { new Guid("fca5b072-0845-4920-bd9c-e646bbcb9340"), new Guid("f821efaa-f511-4b2f-a659-48803290ed9c") }
                });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[,]
                {
                    { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), new Guid("c7f66efd-6949-4239-bfbb-881d5bdfe5da") },
                    { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), new Guid("2445a74c-6c2c-4a6a-ac46-031142aa998b") },
                    { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), new Guid("52aace75-e28b-4435-bb95-3f40d9a6c0d0") },
                    { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("9cf2c2b5-2261-40b8-b776-b5228ec28adb") },
                    { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), new Guid("2445a74c-6c2c-4a6a-ac46-031142aa998b") }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), new Guid("17b979cb-ce86-462d-8d6d-4524f96146dd") },
                    { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), new Guid("17b979cb-ce86-462d-8d6d-4524f96146dd") },
                    { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), new Guid("31c5180a-abb0-4590-b83f-abfb3e5b7b0f") },
                    { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("cebf2a6f-546f-45e5-b31a-401f63023da9") },
                    { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), new Guid("cec4a462-a31e-46df-b2ab-40b23ffad851") }
                });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { new Guid("503c472b-e993-46fc-8339-ae321b66120a"), new Guid("09e49638-929d-42cc-9072-b1d4bc4753a5"), "Knihy Dobrovský" });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Id",
                values: new object[]
                {
                    new Guid("4687fc0f-fb27-42ca-a661-6634b81d511d"),
                    new Guid("550c94e9-8b01-4f17-b05b-1e03d6e8e651")
                });

            migrationBuilder.InsertData(
                table: "BookQuantity",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[,]
                {
                    { new Guid("29bd34a6-b05f-4001-bec6-12d889bd1d30"), new Guid("503c472b-e993-46fc-8339-ae321b66120a"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a334bc2c-58d3-475a-9d4c-292e9ebf4819"), new Guid("503c472b-e993-46fc-8339-ae321b66120a"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b36afd57-97c5-40fb-98aa-54827ffa06e9"), new Guid("503c472b-e993-46fc-8339-ae321b66120a"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("503c472b-e993-46fc-8339-ae321b66120a"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f821efaa-f511-4b2f-a659-48803290ed9c"), new Guid("503c472b-e993-46fc-8339-ae321b66120a"), 0, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate", "ReturnDate" },
                values: new object[] { new Guid("767445a9-42bc-4ee1-b103-9c01d6f510d4"), new Guid("ce9fe02a-e822-4362-b77d-4c3c84db6cda"), new Guid("04ab692a-ac83-4901-9eaf-d0b7de5fb17c"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("503c472b-e993-46fc-8339-ae321b66120a"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified), null });
        }
    }
}
