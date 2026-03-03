using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KolevDiamond.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestmentCoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Coin unique identifier")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, comment: "Name of the coin")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false, comment: "Server file system image path")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Type of metal"),
                    Weight = table.Column<double>(type: "double", nullable: false, comment: "Weight of the metal in grams"),
                    Purity = table.Column<double>(type: "double", nullable: false, comment: "Purity of the metal expressed as a ratio"),
                    Quality = table.Column<int>(type: "int", nullable: false, comment: "Quality of the metal"),
                    Circulation = table.Column<int>(type: "int", nullable: false, comment: "Number of pieces in circulation"),
                    Diameter = table.Column<double>(type: "double", nullable: false, comment: "Diameter of the coin in millimeters"),
                    LegalTender = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Legal tender value in the specified currency")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Manufacturer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Manufacturer of the coin")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Packaging = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "Packaging for the coin")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsForSale = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Is the item for sale")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentCoins", x => x.Id);
                },
                comment: "Investment coin specifications")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestmentDiamonds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Diamond unique identifier")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, comment: "Name of the diamond")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false, comment: "Server file system image path")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    Carats = table.Column<double>(type: "double", nullable: false, comment: "How much carats is the diamond"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "What color is the diamond"),
                    Clarity = table.Column<int>(type: "int", nullable: false, comment: "What clarity is the diamond"),
                    Cut = table.Column<int>(type: "int", nullable: false, comment: "How well the diamond is cut"),
                    CertifyingLaboratory = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "The certifying gemological laboratory")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Proportions = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "The proportions of the diamond")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsForSale = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Is the item for sale")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentDiamonds", x => x.Id);
                },
                comment: "Investment diamond specifications")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MetalBars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Metal bar unique identifier")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, comment: "Name of the metal bar")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false, comment: "Server file system image path")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Type of metal"),
                    Weight = table.Column<double>(type: "double", nullable: false, comment: "Weight of the metal bar in grams"),
                    Dimensions = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "Dimensions of the metal bar (length x width)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Purity = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Purity of the metal expressed in carat for gold or sample for silver")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsForSale = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Is the item for sale")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalBars", x => x.Id);
                },
                comment: "Metal bar specifications")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Necklaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Necklace unique identifier")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, comment: "Name of the necklace")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false, comment: "Server file system image path")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Metal, which necklace is made of"),
                    Carats = table.Column<double>(type: "double", nullable: false, comment: "How much carats is the main diamond used in the necklace"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "What color is the main diamond"),
                    Clarity = table.Column<int>(type: "int", nullable: false, comment: "What clarity is the main diamond in the necklace"),
                    Cut = table.Column<int>(type: "int", nullable: false, comment: "How well the diamond is cut"),
                    Purity = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Purity of the metal expressed in carat for gold or sample for silver")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Length = table.Column<double>(type: "double", nullable: false, comment: "Length of the necklace in millimeters"),
                    IsForSale = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Is the item for sale")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Necklaces", x => x.Id);
                },
                comment: "Necklace specifications")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Ring unique identifier")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, comment: "Name of the ring")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false, comment: "Server file system image path")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    Metal = table.Column<int>(type: "int", nullable: false, comment: "Metal, which ring is made of"),
                    Carats = table.Column<double>(type: "double", nullable: false, comment: "How much carats is the main diamond used in the ring"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "What color is the main diamond"),
                    Clarity = table.Column<int>(type: "int", nullable: false, comment: "What clarity is the main diamond in the ring"),
                    Cut = table.Column<int>(type: "int", nullable: false, comment: "How well the diamond is cut"),
                    Purity = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Purity of the metal expressed in carat for gold or sample for silver")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsForSale = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Is the item for sale")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rings", x => x.Id);
                },
                comment: "Ring specifications")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "50d6a46c-509a-4475-acac-8dc98a0d6580", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOf9x4e/wieOkLhwXaB3K0AD634/yK1hiixaZVzCvxe/01ozOuNNXTsnRCGPUTI93Q==", null, false, "4825edaf-0d26-4095-be0b-b913cedb0430", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "InvestmentCoins",
                columns: new[] { "Id", "Circulation", "Diameter", "ImagePath", "IsForSale", "LegalTender", "Manufacturer", "Metal", "Name", "Packaging", "Price", "Purity", "Quality", "Weight" },
                values: new object[,]
                {
                    { 1, 10000, 22.050000000000001, "https://upload.wikimedia.org/wikipedia/commons/3/3a/1959_sovereign_Elizabeth_II_obverse.jpg", true, "GBP 1", "The Royal Mint", 2, "Gold Sovereign", "Protective Capsule", 1000.00m, 0.91669999999999996, 1, 7.9800000000000004 },
                    { 2, 5000, 40.600000000000001, "https://assets.goldeneaglecoin.com/resource/productimages/2020-SE-obv.jpg", true, "USD 1", "United States Mint", 1, "Silver Eagle", "Plastic Tube", 50.00m, 0.999, 1, 31.100000000000001 },
                    { 3, 1000, 30.0, "https://media.tavid.ee/v7/_product_catalog_/1-oz-canadian-maple-leaf-silver-coin/canadian_maple_leaf_1oz_silver_coin_reverse.jpg?height=960&width=960&func=cropfit", true, "CAD 50", "Royal Canadian Mint", 1, "Silver Maple Leaf", "Assay Card", 500.00m, 0.99950000000000006, 3, 31.100000000000001 }
                });

            migrationBuilder.InsertData(
                table: "InvestmentDiamonds",
                columns: new[] { "Id", "Carats", "CertifyingLaboratory", "Clarity", "Colour", "Cut", "ImagePath", "IsForSale", "Name", "Price", "Proportions" },
                values: new object[,]
                {
                    { 1, 1.0, "GIA", 3, 2, 1, "https://www.diamondbanc.com/wp-content/uploads/2019/01/shutterstock_32731492-1024x681.jpg", true, "Round Brilliant Diamond", 5000.00m, "Excellent" },
                    { 2, 1.5, "IGI", 6, 4, 2, "https://www.qualitydiamonds.co.uk/media/1132/princess-diamond-top.png", true, "Princess Cut Diamond", 7000.00m, "Very Good" },
                    { 3, 2.0, "HRD", 7, 3, 3, "https://www.capediamonds.co.za/wp-content/uploads/2020/09/Emerald-Cut-Diamonds-Cape-Diamonds-Cape-Town-South-Africa.jpg", true, "Emerald Cut Diamond", 10000.00m, "Good" }
                });

            migrationBuilder.InsertData(
                table: "MetalBars",
                columns: new[] { "Id", "Dimensions", "ImagePath", "IsForSale", "Metal", "Name", "Price", "Purity", "Weight" },
                values: new object[,]
                {
                    { 1, "27 x 47 mm", "https://m.media-amazon.com/images/I/61ICiCEk3TL._AC_UF894,1000_QL80_.jpg", true, 2, "Gold Bar", 15000.00m, "24 Karat", 1000.0 },
                    { 2, "20 x 40 mm", "https://www.monex.com/wp-content/uploads/2023/06/1-kilo-silver-bar-side.png", true, 1, "Silver Bar", 500.00m, "999.9/1000", 1000.0 },
                    { 3, "25 x 50 mm", "https://images.squarespace-cdn.com/content/v1/5719f32620c64744b886bcd2/1612970177011-TLIGBQ4ZDOODFX0TOR42/rose-gold-bar.png", true, 4, "Rose Gold Bar", 20000.00m, "24 Karat", 1000.0 }
                });

            migrationBuilder.InsertData(
                table: "Necklaces",
                columns: new[] { "Id", "Carats", "Clarity", "Colour", "Cut", "ImagePath", "IsForSale", "Length", "Metal", "Name", "Price", "Purity" },
                values: new object[,]
                {
                    { 1, 2.5, 5, 4, 1, "https://i.etsystatic.com/6244698/r/il/8121e9/1697727663/il_570xN.1697727663_9elj.jpg", true, 450.0, 2, "Diamond Solitaire Necklace", 1500.00m, "18K" },
                    { 2, 3.0, 7, 14, 2, "https://media.beaverbrooks.co.uk/i/beaverbrooks/G105854_0", true, 500.0, 1, "Sapphire Halo Necklace", 2000.00m, "925" },
                    { 3, 2.7999999999999998, 4, 1, 1, "https://haverhill.com/cdn/shop/products/image_11085d78-83fb-429b-a153-15a90bc9ee30_1200x1200.jpg?v=1705428203", true, 480.0, 1, "Emerald Pendant Necklace", 1800.00m, "925" }
                });

            migrationBuilder.InsertData(
                table: "Rings",
                columns: new[] { "Id", "Carats", "Clarity", "Colour", "Cut", "ImagePath", "IsForSale", "Metal", "Name", "Price", "Purity" },
                values: new object[,]
                {
                    { 1, 1.5, 5, 4, 2, "https://www.tanishq.co.in/on/demandware.static/-/Sites-Tanishq-product-catalog/default/dw5721e8ec/images/hi-res/50D2FFFFRAA02_1.jpg", true, 2, "Gold Diamond Ring", 1000.00m, "18K" },
                    { 2, 4.0, 3, 4, 1, "https://4.imimg.com/data4/QW/YU/FUSIONI-3520335/prod-image.jpg", true, 2, "Gold Ring With Crown Diamond", 10020.00m, "18K" },
                    { 3, 3.0, 5, 4, 1, "https://love-and-co.com/cdn/shop/files/CR591-LGD_lifestyle.jpg?v=1697793277&width=2000", true, 4, "Rose Gold Diamond Ring", 12000.00m, "18K" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);
        }

        /// <inheritdoc />
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
                name: "InvestmentCoins");

            migrationBuilder.DropTable(
                name: "InvestmentDiamonds");

            migrationBuilder.DropTable(
                name: "MetalBars");

            migrationBuilder.DropTable(
                name: "Necklaces");

            migrationBuilder.DropTable(
                name: "Rings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
