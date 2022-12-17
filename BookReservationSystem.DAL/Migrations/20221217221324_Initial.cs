using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReservationSystem.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Book",
                newName: "Rating");

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("d9b6ea89-dd10-41a2-bc3f-bf71e112934b"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ba55a223-88f2-4d77-96b7-b9036c4a6ad0"), "be01e308-827e-4988-9029-fd4cc6468a30", "Admin", "ADMIN" },
                    { new Guid("d6332ae5-b39c-46f6-add4-94e18ebfdf91"), "8491ff56-8e9b-4b09-82c6-4b669076a4a4", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("29aad8c0-309c-433d-be8a-5dc642821d38"), 0, "a7c9fbe2-f7bc-4a6a-b621-1ac53239869b", "wmonkman0@zdnet.com", false, "Westbrook", "Monkman", false, null, null, null, "RLreUYnARxnE", null, false, null, false, "monkman" },
                    { new Guid("355016a2-b3ff-49cf-9adb-313f5b2cb9f7"), 0, "33cc1c19-46ac-4f61-8280-958824736011", "mmaxworthy1@ning.com", false, "Madelene", "Maxworthy", false, null, null, null, "bo09BbrTa", null, false, null, false, "maxworthy" },
                    { new Guid("b8d0fdb6-95f1-4fce-8570-6ea6f06c91ab"), 0, "e5c65505-200f-4fc5-809c-8e174f2562f3", "demo@gmail.com", false, "demo", "demo", false, null, "DEMO@GMAIL.COM", "DEMO", "AQAAAAEAACcQAAAAEI56EuIXWNrKlnYOdNxWJx+bnMJ0WWTjpo3Mn3P7HPBGV78AQjb9BJomuebALvEIqQ==", null, false, "e248bd99-22c0-4b99-b980-ec9d1bc19c8d", false, "demo" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6cfa4cd0-11e2-42bc-991f-3cc2cf637fc2"), "Bram Stoker" },
                    { new Guid("799c7694-cf68-4858-91f5-d2691d197809"), "Stephen King" },
                    { new Guid("85a2f316-bd30-4d69-b2d7-408db01444a9"), "Kerkeling Hape" },
                    { new Guid("8cec3254-80a7-4845-bbb1-14e860eeade1"), "Lars Kepler" },
                    { new Guid("a45865a6-8808-435d-9954-b99049ba3816"), "John Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "CoverArtPath", "Isbn", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", "~/book_covers/kockybookcover.jpg", 9788024282442L, "Moje kočky, cizí kočky a já", 0f },
                    { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), "", "~/book_covers/dracula.jpg", 9780141199337L, "Dracula", 0f },
                    { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), "Toto je příběh o tom, kterak se Pytlík vydal za dobrodružstvím a shledal, že náhle dělá a říká naprosto neočekávané věci… Bilbo Pytlík je hobit, který se těší z pohodlnéh a skromného života a jen zřídkakdy putuje dále než do své spižírny ve Dně pytle. Jeho spokojené bytí je však narušeno, když se jednoho dne u jeho prahu objeví čaroděj Gandalf v doprovodu třinácti trpaslíků a vezmou ho s sebou na cestu \"tam a zase zpátky\". Mají v úmyslu uloupit poklad mocného Šmaka, velikého a velmi nebezpečného draka... ", "~/book_covers/hobbit.jpg", 9788025707418L, "Hobbit", 0f },
                    { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), "Joona Linna se znovu ocitá v ohrožení života a zachránit ho může jedině Saga Bauerová.", "~/book_covers/pavouk.jpg", 9788027513765L, "Pavouk", 0f },
                    { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), "peepo", "~/book_covers/the-shining.jpg", 9788055138343L, "Shining", 0f }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3ddbed50-59b2-43ed-bcb6-a61f817d1c07"), "Satire" },
                    { new Guid("5587a2d2-d22f-4c20-a556-889229aa51af"), "Comic" },
                    { new Guid("5bf88eed-f98e-459e-a443-15bf9f692a79"), "Horor" },
                    { new Guid("a49ec5fe-d376-408d-a942-4e9fe129aa65"), "Detective" },
                    { new Guid("abdb1c5f-78c1-4426-9448-f1e7efd1d7ed"), "Fantasy" },
                    { new Guid("b46fbe19-ae1a-4dcf-9f4a-2e2ca63e1625"), "Beletry" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3e9ab122-453e-4ba4-8dd1-9462dfbaf591"), "Host" },
                    { new Guid("beeba881-7fd2-43b9-9987-188800166aab"), "ARGO" },
                    { new Guid("ca973918-90d8-4890-8496-22d6030de945"), "Ikar" },
                    { new Guid("fa77df0f-a5bb-4725-aa2e-b552242bfc61"), "EUROMEDIA GROUP, a.s." }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("6cfa4cd0-11e2-42bc-991f-3cc2cf637fc2"), new Guid("971397be-d444-4c04-9fa0-96e105e7f75f") },
                    { new Guid("799c7694-cf68-4858-91f5-d2691d197809"), new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2") },
                    { new Guid("85a2f316-bd30-4d69-b2d7-408db01444a9"), new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212") },
                    { new Guid("8cec3254-80a7-4845-bbb1-14e860eeade1"), new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0") },
                    { new Guid("a45865a6-8808-435d-9954-b99049ba3816"), new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519") }
                });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[,]
                {
                    { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("fa77df0f-a5bb-4725-aa2e-b552242bfc61") },
                    { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), new Guid("beeba881-7fd2-43b9-9987-188800166aab") },
                    { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), new Guid("beeba881-7fd2-43b9-9987-188800166aab") },
                    { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), new Guid("3e9ab122-453e-4ba4-8dd1-9462dfbaf591") },
                    { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), new Guid("ca973918-90d8-4890-8496-22d6030de945") }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("3ddbed50-59b2-43ed-bcb6-a61f817d1c07") },
                    { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), new Guid("5bf88eed-f98e-459e-a443-15bf9f692a79") },
                    { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), new Guid("abdb1c5f-78c1-4426-9448-f1e7efd1d7ed") },
                    { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), new Guid("b46fbe19-ae1a-4dcf-9f4a-2e2ca63e1625") },
                    { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), new Guid("5bf88eed-f98e-459e-a443-15bf9f692a79") }
                });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), new Guid("d9b6ea89-dd10-41a2-bc3f-bf71e112934b"), "Knihy Dobrovský" });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Id",
                values: new object[]
                {
                    new Guid("ba55a223-88f2-4d77-96b7-b9036c4a6ad0"),
                    new Guid("d6332ae5-b39c-46f6-add4-94e18ebfdf91")
                });

            migrationBuilder.InsertData(
                table: "BookQuantity",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[,]
                {
                    { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), 0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), 2, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate", "ReturnDate" },
                values: new object[] { new Guid("e994f727-4e5b-4ccb-9cc3-f649e9e0893b"), new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("355016a2-b3ff-49cf-9adb-313f5b2cb9f7"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("29aad8c0-309c-433d-be8a-5dc642821d38"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8d0fdb6-95f1-4fce-8570-6ea6f06c91ab"));

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("6cfa4cd0-11e2-42bc-991f-3cc2cf637fc2"), new Guid("971397be-d444-4c04-9fa0-96e105e7f75f") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("799c7694-cf68-4858-91f5-d2691d197809"), new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("85a2f316-bd30-4d69-b2d7-408db01444a9"), new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("8cec3254-80a7-4845-bbb1-14e860eeade1"), new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { new Guid("a45865a6-8808-435d-9954-b99049ba3816"), new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("fa77df0f-a5bb-4725-aa2e-b552242bfc61") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), new Guid("beeba881-7fd2-43b9-9987-188800166aab") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), new Guid("beeba881-7fd2-43b9-9987-188800166aab") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), new Guid("3e9ab122-453e-4ba4-8dd1-9462dfbaf591") });

            migrationBuilder.DeleteData(
                table: "AuthorPublishers",
                keyColumns: new[] { "BooksId", "PublishersId" },
                keyValues: new object[] { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), new Guid("ca973918-90d8-4890-8496-22d6030de945") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("3ddbed50-59b2-43ed-bcb6-a61f817d1c07") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), new Guid("5bf88eed-f98e-459e-a443-15bf9f692a79") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), new Guid("abdb1c5f-78c1-4426-9448-f1e7efd1d7ed") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), new Guid("b46fbe19-ae1a-4dcf-9f4a-2e2ca63e1625") });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), new Guid("5bf88eed-f98e-459e-a443-15bf9f692a79") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04") });

            migrationBuilder.DeleteData(
                table: "BookQuantity",
                keyColumns: new[] { "BookId", "LibraryId" },
                keyValues: new object[] { new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"), new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04") });

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("5587a2d2-d22f-4c20-a556-889229aa51af"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("a49ec5fe-d376-408d-a942-4e9fe129aa65"));

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("e994f727-4e5b-4ccb-9cc3-f649e9e0893b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ba55a223-88f2-4d77-96b7-b9036c4a6ad0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d6332ae5-b39c-46f6-add4-94e18ebfdf91"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ba55a223-88f2-4d77-96b7-b9036c4a6ad0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6332ae5-b39c-46f6-add4-94e18ebfdf91"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("355016a2-b3ff-49cf-9adb-313f5b2cb9f7"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("6cfa4cd0-11e2-42bc-991f-3cc2cf637fc2"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("799c7694-cf68-4858-91f5-d2691d197809"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("85a2f316-bd30-4d69-b2d7-408db01444a9"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("8cec3254-80a7-4845-bbb1-14e860eeade1"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("a45865a6-8808-435d-9954-b99049ba3816"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("4af06947-d197-4f1b-a23e-b2e661f4e212"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("971397be-d444-4c04-9fa0-96e105e7f75f"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("9bd8ef8a-33f6-4003-8395-3122e42fb519"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("e3b0ca13-9e46-4745-966a-e686a8cfe1b0"));

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: new Guid("ffc13f78-81af-4bb1-b88c-ef4d5eabe6c2"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("3ddbed50-59b2-43ed-bcb6-a61f817d1c07"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("5bf88eed-f98e-459e-a443-15bf9f692a79"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("abdb1c5f-78c1-4426-9448-f1e7efd1d7ed"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("b46fbe19-ae1a-4dcf-9f4a-2e2ca63e1625"));

            migrationBuilder.DeleteData(
                table: "Library",
                keyColumn: "Id",
                keyValue: new Guid("ea09cd4c-a8eb-480a-9df9-b14d88e84d04"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("3e9ab122-453e-4ba4-8dd1-9462dfbaf591"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("beeba881-7fd2-43b9-9987-188800166aab"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("ca973918-90d8-4890-8496-22d6030de945"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("fa77df0f-a5bb-4725-aa2e-b552242bfc61"));

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("d9b6ea89-dd10-41a2-bc3f-bf71e112934b"));

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Book",
                newName: "AverageRating");

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
    }
}
