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
                values: new object[] { new Guid("5eb0f010-11ec-4fad-a883-7a998356a18d"), "Brno", "CZ", " 60200", "Joštová", 6 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1fdde2a1-6bc6-48dc-af86-3b7d81d29cdb"), "e5cb5e2c-49a1-4945-b63c-6b70e77661ef", "Admin", "ADMIN" },
                    { new Guid("7afa6103-b034-4356-80b0-bd5754dfe654"), "656e800a-d2ae-4707-9790-50a631157dd2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3b17bca4-60bd-4a6c-af6b-fe23fbf92194"), 0, "836b158c-189f-4051-b6f1-693bb5991283", "demo@gmail.com", false, "demo", "demo", false, null, "DEMO@GMAIL.COM", "DEMO", "AQAAAAEAACcQAAAAEI56EuIXWNrKlnYOdNxWJx+bnMJ0WWTjpo3Mn3P7HPBGV78AQjb9BJomuebALvEIqQ==", null, false, "98f74f71-efdd-4bed-99d3-d1b2dca96da2", false, "demo" },
                    { new Guid("4a82a356-363b-4757-bed8-45347a15cbc9"), 0, "46ca9f49-854a-4063-a4a4-85989f4e2eec", "mmaxworthy1@ning.com", false, "Madelene", "Maxworthy", false, null, null, null, "bo09BbrTa", null, false, null, false, "maxworthy" },
                    { new Guid("914fe78e-3210-4360-b478-8d8df581d414"), 0, "43b28490-a793-4df7-9ac4-dd39f1b0929e", "wmonkman0@zdnet.com", false, "Westbrook", "Monkman", false, null, null, null, "RLreUYnARxnE", null, false, null, false, "monkman" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("356f9c16-1a57-4958-ab1c-c19ffd482a65"), "Kerkeling Hape" },
                    { new Guid("51922d0a-8ada-44f9-8756-cb576c5d199f"), "Lars Kepler" },
                    { new Guid("7bf6003e-38e2-4256-b62f-36357991c838"), "Stephen King" },
                    { new Guid("dcc7b4c7-1b26-41b6-ad64-f4bed4e0b319"), "Bram Stoker" },
                    { new Guid("f21f47ff-49dc-4dfe-ae3f-af5c3b799a23"), "John Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Abstract", "CoverArtPath", "Isbn", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("064c4555-721b-433e-97b0-54e048f88dbc"), "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.", "~/book_covers/kockybookcover.jpg", 9788024282442L, "Moje kočky, cizí kočky a já", 0f },
                    { new Guid("2df8c950-d19a-421f-ac5f-2d92efa43ac5"), "Joona Linna se znovu ocitá v ohrožení života a zachránit ho může jedině Saga Bauerová.", "~/book_covers/pavouk.jpg", 9788027513765L, "Pavouk", 0f },
                    { new Guid("578bb6f1-2358-4084-aadc-6b70af0a6ba4"), "Toto je příběh o tom, kterak se Pytlík vydal za dobrodružstvím a shledal, že náhle dělá a říká naprosto neočekávané věci… Bilbo Pytlík je hobit, který se těší z pohodlnéh a skromného života a jen zřídkakdy putuje dále než do své spižírny ve Dně pytle. Jeho spokojené bytí je však narušeno, když se jednoho dne u jeho prahu objeví čaroděj Gandalf v doprovodu třinácti trpaslíků a vezmou ho s sebou na cestu \"tam a zase zpátky\". Mají v úmyslu uloupit poklad mocného Šmaka, velikého a velmi nebezpečného draka... ", "~/book_covers/hobbit.jpg", 9788025707418L, "Hobbit", 0f },
                    { new Guid("902ccd45-9784-4644-9031-a1403eebd1da"), "peepo", "~/book_covers/the-shining.jpg", 9788055138343L, "Shining", 0f },
                    { new Guid("f92eb26a-3e98-490b-b355-5eac69a3d407"), "", "~/book_covers/dracula.jpg", 9780141199337L, "Dracula", 0f }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d633a91-6779-4d17-8d1a-fa377cde4fe6"), "Fantasy" },
                    { new Guid("12499ca3-4cc3-4fa3-8007-d5bd03524d3e"), "Comic" },
                    { new Guid("5251e5bf-9d3f-4409-bc6f-59128cfd7a11"), "Horor" },
                    { new Guid("576da5a8-3f25-48ed-bdf0-3c0f5210cc71"), "Beletry" },
                    { new Guid("7100f309-d0d9-4319-b408-dedbbf0a5541"), "Satire" },
                    { new Guid("c438ad4a-aa61-4a73-b541-35fe13c4f6f3"), "Detective" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2abe5f05-e279-4914-b991-0fd9fe4e3bc4"), "EUROMEDIA GROUP, a.s." },
                    { new Guid("567db8d6-a278-49da-b9b7-0890f64c9b36"), "Ikar" },
                    { new Guid("7875c728-b9eb-4445-b89a-8aa7e7b1b3b4"), "ARGO" },
                    { new Guid("900ed9bb-14d7-42a9-a9d8-9307f3e57877"), "Host" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { new Guid("356f9c16-1a57-4958-ab1c-c19ffd482a65"), new Guid("064c4555-721b-433e-97b0-54e048f88dbc") },
                    { new Guid("51922d0a-8ada-44f9-8756-cb576c5d199f"), new Guid("2df8c950-d19a-421f-ac5f-2d92efa43ac5") },
                    { new Guid("7bf6003e-38e2-4256-b62f-36357991c838"), new Guid("902ccd45-9784-4644-9031-a1403eebd1da") },
                    { new Guid("dcc7b4c7-1b26-41b6-ad64-f4bed4e0b319"), new Guid("f92eb26a-3e98-490b-b355-5eac69a3d407") },
                    { new Guid("f21f47ff-49dc-4dfe-ae3f-af5c3b799a23"), new Guid("578bb6f1-2358-4084-aadc-6b70af0a6ba4") }
                });

            migrationBuilder.InsertData(
                table: "AuthorPublishers",
                columns: new[] { "BooksId", "PublishersId" },
                values: new object[,]
                {
                    { new Guid("064c4555-721b-433e-97b0-54e048f88dbc"), new Guid("2abe5f05-e279-4914-b991-0fd9fe4e3bc4") },
                    { new Guid("2df8c950-d19a-421f-ac5f-2d92efa43ac5"), new Guid("900ed9bb-14d7-42a9-a9d8-9307f3e57877") },
                    { new Guid("578bb6f1-2358-4084-aadc-6b70af0a6ba4"), new Guid("7875c728-b9eb-4445-b89a-8aa7e7b1b3b4") },
                    { new Guid("902ccd45-9784-4644-9031-a1403eebd1da"), new Guid("567db8d6-a278-49da-b9b7-0890f64c9b36") },
                    { new Guid("f92eb26a-3e98-490b-b355-5eac69a3d407"), new Guid("7875c728-b9eb-4445-b89a-8aa7e7b1b3b4") }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { new Guid("064c4555-721b-433e-97b0-54e048f88dbc"), new Guid("7100f309-d0d9-4319-b408-dedbbf0a5541") },
                    { new Guid("2df8c950-d19a-421f-ac5f-2d92efa43ac5"), new Guid("576da5a8-3f25-48ed-bdf0-3c0f5210cc71") },
                    { new Guid("578bb6f1-2358-4084-aadc-6b70af0a6ba4"), new Guid("0d633a91-6779-4d17-8d1a-fa377cde4fe6") },
                    { new Guid("902ccd45-9784-4644-9031-a1403eebd1da"), new Guid("5251e5bf-9d3f-4409-bc6f-59128cfd7a11") },
                    { new Guid("f92eb26a-3e98-490b-b355-5eac69a3d407"), new Guid("5251e5bf-9d3f-4409-bc6f-59128cfd7a11") }
                });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), new Guid("5eb0f010-11ec-4fad-a883-7a998356a18d"), "Knihy Dobrovský" });

            migrationBuilder.InsertData(
                table: "Roles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1fdde2a1-6bc6-48dc-af86-3b7d81d29cdb"),
                    new Guid("7afa6103-b034-4356-80b0-bd5754dfe654")
                });

            migrationBuilder.InsertData(
                table: "BookQuantity",
                columns: new[] { "BookId", "LibraryId", "Count", "Id" },
                values: new object[,]
                {
                    { new Guid("064c4555-721b-433e-97b0-54e048f88dbc"), new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2df8c950-d19a-421f-ac5f-2d92efa43ac5"), new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("578bb6f1-2358-4084-aadc-6b70af0a6ba4"), new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), 0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("902ccd45-9784-4644-9031-a1403eebd1da"), new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f92eb26a-3e98-490b-b355-5eac69a3d407"), new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), 2, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CustomerId", "DueDate", "LibraryId", "PickupDate", "ReservationDate", "ReturnDate" },
                values: new object[] { new Guid("c5997489-e3f5-4157-9003-1c53971c43ab"), new Guid("064c4555-721b-433e-97b0-54e048f88dbc"), new Guid("4a82a356-363b-4757-bed8-45347a15cbc9"), new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new Guid("8c591b4c-2ecf-4596-a56e-07ec3accd979"), null, new DateTime(2022, 10, 1, 18, 40, 1, 0, DateTimeKind.Unspecified), null });

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
                name: "IX_Book_Isbn",
                table: "Book",
                column: "Isbn",
                unique: true);

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
