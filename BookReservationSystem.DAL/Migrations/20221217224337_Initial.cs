using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReservationSystem.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    City = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CoverArtPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Isbn = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Library_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenres_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPublishers",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPublishers", x => new { x.BooksId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_AuthorPublishers_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorPublishers_Publisher_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("1f04ef82-3e9a-4e11-8d4d-9727479067ec"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9c47739a-55b7-4720-af7b-723a5a87ab4f"), "85a76cd6-68d2-4dc3-95ac-eb5b2977bd6c", "Admin", "ADMIN" },
                    { new Guid("d93e3e1a-0e04-47cb-8304-cdbc3de237b0"), "ccf2a196-e7e5-427c-908f-52899e64793b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("11f27436-d044-46ef-9312-2d1929bf8951"), 0, "725bd15d-2ac0-4865-982b-baacce8dc60c", "wmonkman0@zdnet.com", false, "Westbrook", "Monkman", false, null, null, null, "RLreUYnARxnE", null, false, null, false, "monkman" },
                    { new Guid("18d38541-b5e9-46bf-9e01-e23820d41c23"), 0, "f76cba7e-dc6e-41ec-b08a-f0ad6283ff76", "demo@gmail.com", false, "demo", "demo", false, null, "DEMO@GMAIL.COM", "DEMO", "AQAAAAEAACcQAAAAEI56EuIXWNrKlnYOdNxWJx+bnMJ0WWTjpo3Mn3P7HPBGV78AQjb9BJomuebALvEIqQ==", null, false, "8a8678e1-1e82-4804-afd9-dfe676e95909", false, "demo" },
                    { new Guid("2e258e7f-9aed-456f-915f-f2e6b6441c4f"), 0, "301fa062-b74a-437e-822b-34d4a591e90a", "mmaxworthy1@ning.com", false, "Madelene", "Maxworthy", false, null, null, null, "bo09BbrTa", null, false, null, false, "maxworthy" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("050d99a9-6760-41ac-93cb-e67c4b798a4c"), "Lars Kepler" },
                    { new Guid("13394916-877f-4df9-ad6e-9b26ef38b3a7"), "Stephen King" },
                    { new Guid("65da7131-03ea-4694-950b-02dbebf19315"), "Kerkeling Hape" },
                    { new Guid("88f9dc03-8aa7-475f-9d3b-de221768a27d"), "Bram Stoker" },
                    { new Guid("d5a43459-9ae3-4b34-9f45-bb516850d9a7"), "John Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "CoverArtPath", "Isbn", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("42885498-cda8-44c5-8b65-ddfd04fb435b"), "peepo", "~/book_covers/the-shining.jpg", 9788055138343L, "Shining", 0f },
                    { new Guid("5924ddf1-c262-4f86-a588-4eba55e56ac7"), "Toto je příběh o tom, kterak se Pytlík vydal za dobrodružstvím a shledal, že náhle dělá a říká naprosto neočekávané věci… Bilbo Pytlík je hobit, který se těší z pohodlnéh a skromného života a jen zřídkakdy putuje dále než do své spižírny ve Dně pytle. Jeho spokojené bytí je však narušeno, když se jednoho dne u jeho prahu objeví čaroděj Gandalf v doprovodu třinácti trpaslíků a vezmou ho s sebou na cestu \"tam a zase zpátky\". Mají v úmyslu uloupit poklad mocného Šmaka, velikého a velmi nebezpečného draka... ", "~/book_covers/hobbit.jpg", 9788025707418L, "Hobbit", 0f },
                    { new Guid("8d4bd570-567b-418f-83b3-db5c8c3e584b"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", "~/book_covers/kockybookcover.jpg", 9788024282442L, "Moje kočky, cizí kočky a já", 0f },
                    { new Guid("c7b2b1a0-417e-49b8-845e-aee1ecbcbc4d"), "", "~/book_covers/dracula.jpg", 9780141199337L, "Dracula", 0f },
                    { new Guid("de9d095f-49ca-411d-8093-4ac8c22d568f"), "Joona Linna se znovu ocitá v ohrožení života a zachránit ho může jedině Saga Bauerová.", "~/book_covers/pavouk.jpg", 9788027513765L, "Pavouk", 0f }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ffd43f0-443b-4efa-b9f3-06be2b8c4804"), "Detective" },
                    { new Guid("3c3b9369-39fd-4fb2-9671-d80443431e10"), "Comic" },
                    { new Guid("54734ffc-e04e-4b2d-ae46-4ca85d339666"), "Beletry" },
                    { new Guid("937288f1-02de-4c21-9ad5-5dc10ab4e5e2"), "Satire" },
                    { new Guid("e685d73e-a7e4-4bbd-8677-8a758103bf73"), "Horor" },
                    { new Guid("ff543c3d-6379-4c82-8b51-e7709e00e017"), "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06d7f2a8-16a6-46f7-af15-6c0d9e9c7a72"), "ARGO" },
                    { new Guid("97442271-3b8d-4d13-b33b-0cb9a7de91b5"), "Ikar" },
                    { new Guid("becc55c3-6626-4c57-b7df-812bfa98cee5"), "EUROMEDIA GROUP, a.s." },
                    { new Guid("dc335b71-c22b-4783-9a0b-94f35aae97d3"), "Host" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("050d99a9-6760-41ac-93cb-e67c4b798a4c"), new Guid("de9d095f-49ca-411d-8093-4ac8c22d568f") },
                    { new Guid("13394916-877f-4df9-ad6e-9b26ef38b3a7"), new Guid("42885498-cda8-44c5-8b65-ddfd04fb435b") },
                    { new Guid("65da7131-03ea-4694-950b-02dbebf19315"), new Guid("8d4bd570-567b-418f-83b3-db5c8c3e584b") },
                    { new Guid("88f9dc03-8aa7-475f-9d3b-de221768a27d"), new Guid("c7b2b1a0-417e-49b8-845e-aee1ecbcbc4d") },
                    { new Guid("d5a43459-9ae3-4b34-9f45-bb516850d9a7"), new Guid("5924ddf1-c262-4f86-a588-4eba55e56ac7") }
                });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[,]
                {
                    { new Guid("42885498-cda8-44c5-8b65-ddfd04fb435b"), new Guid("97442271-3b8d-4d13-b33b-0cb9a7de91b5") },
                    { new Guid("5924ddf1-c262-4f86-a588-4eba55e56ac7"), new Guid("06d7f2a8-16a6-46f7-af15-6c0d9e9c7a72") },
                    { new Guid("8d4bd570-567b-418f-83b3-db5c8c3e584b"), new Guid("becc55c3-6626-4c57-b7df-812bfa98cee5") },
                    { new Guid("c7b2b1a0-417e-49b8-845e-aee1ecbcbc4d"), new Guid("06d7f2a8-16a6-46f7-af15-6c0d9e9c7a72") },
                    { new Guid("de9d095f-49ca-411d-8093-4ac8c22d568f"), new Guid("dc335b71-c22b-4783-9a0b-94f35aae97d3") }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("42885498-cda8-44c5-8b65-ddfd04fb435b"), new Guid("e685d73e-a7e4-4bbd-8677-8a758103bf73") },
                    { new Guid("5924ddf1-c262-4f86-a588-4eba55e56ac7"), new Guid("ff543c3d-6379-4c82-8b51-e7709e00e017") },
                    { new Guid("8d4bd570-567b-418f-83b3-db5c8c3e584b"), new Guid("937288f1-02de-4c21-9ad5-5dc10ab4e5e2") },
                    { new Guid("c7b2b1a0-417e-49b8-845e-aee1ecbcbc4d"), new Guid("e685d73e-a7e4-4bbd-8677-8a758103bf73") },
                    { new Guid("de9d095f-49ca-411d-8093-4ac8c22d568f"), new Guid("54734ffc-e04e-4b2d-ae46-4ca85d339666") }
                });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), new Guid("1f04ef82-3e9a-4e11-8d4d-9727479067ec"), "Knihy Dobrovský" });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Id",
                values: new object[]
                {
                    new Guid("9c47739a-55b7-4720-af7b-723a5a87ab4f"),
                    new Guid("d93e3e1a-0e04-47cb-8304-cdbc3de237b0")
                });

            migrationBuilder.InsertData(
                table: "BookQuantity",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[,]
                {
                    { new Guid("42885498-cda8-44c5-8b65-ddfd04fb435b"), new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5924ddf1-c262-4f86-a588-4eba55e56ac7"), new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), 0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8d4bd570-567b-418f-83b3-db5c8c3e584b"), new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c7b2b1a0-417e-49b8-845e-aee1ecbcbc4d"), new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("de9d095f-49ca-411d-8093-4ac8c22d568f"), new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate", "ReturnDate" },
                values: new object[] { new Guid("a35621c4-3368-4fc7-81be-bee03e0fc910"), new Guid("8d4bd570-567b-418f-83b3-db5c8c3e584b"), new Guid("2e258e7f-9aed-456f-915f-f2e6b6441c4f"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("32edbd50-8a11-4a78-8630-7a9f6713ea48"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BooksId",
                table: "AuthorBooks",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublishers_PublishersId",
                table: "AuthorPublishers",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenresId",
                table: "BookGenres",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_BookQuantity_LibraryId",
                table: "BookQuantity",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Library_AddressId",
                table: "Library",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LibraryId",
                table: "Reservation",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookId",
                table: "Review",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "AuthorPublishers");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "BookQuantity");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
