using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalEquipment.Web.Migrations
{
    public partial class create01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryTitle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "FormContact",
                columns: table => new
                {
                    FormContact_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormContact", x => x.FormContact_Id);
                });

            migrationBuilder.CreateTable(
                name: "FormContactModel",
                columns: table => new
                {
                    FormContactModel_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormContactModel", x => x.FormContactModel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Lang_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageTitle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Lang_Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    About_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Summary = table.Column<string>(nullable: false),
                    Describtion = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 50, nullable: true),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.About_Id);
                    table.ForeignKey(
                        name: "FK_AboutUs_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Contact_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(nullable: false),
                    Mobil = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    TelegramId = table.Column<string>(nullable: false),
                    InstagrmId = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    LangID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Contact_Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Languages_LangID",
                        column: x => x.LangID,
                        principalTable: "Languages",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    SpecialProduct = table.Column<bool>(nullable: false),
                    ProductForDisplay = table.Column<bool>(nullable: false),
                    Lang_Id = table.Column<int>(nullable: false),
                    Category_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Languages_Lang_Id",
                        column: x => x.Lang_Id,
                        principalTable: "Languages",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Service_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tittle = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 50, nullable: true),
                    Lang_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Service_Id);
                    table.ForeignKey(
                        name: "FK_Service_Languages_Lang_Id",
                        column: x => x.Lang_Id,
                        principalTable: "Languages",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderImage",
                columns: table => new
                {
                    SliderImage_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(maxLength: 50, nullable: true),
                    Lang_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImage", x => x.SliderImage_Id);
                    table.ForeignKey(
                        name: "FK_SliderImage_Languages_Lang_Id",
                        column: x => x.Lang_Id,
                        principalTable: "Languages",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesType",
                columns: table => new
                {
                    ServicesType_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tittle = table.Column<string>(nullable: true),
                    Service_Id = table.Column<int>(nullable: false),
                    LanguageLang_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesType", x => x.ServicesType_Id);
                    table.ForeignKey(
                        name: "FK_ServicesType_Languages_LanguageLang_Id",
                        column: x => x.LanguageLang_Id,
                        principalTable: "Languages",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesType_Service_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Service",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUs_LangId",
                table: "AboutUs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LangID",
                table: "Contacts",
                column: "LangID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_Id",
                table: "Products",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Lang_Id",
                table: "Products",
                column: "Lang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Lang_Id",
                table: "Service",
                column: "Lang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesType_LanguageLang_Id",
                table: "ServicesType",
                column: "LanguageLang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesType_Service_Id",
                table: "ServicesType",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SliderImage_Lang_Id",
                table: "SliderImage",
                column: "Lang_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "FormContact");

            migrationBuilder.DropTable(
                name: "FormContactModel");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ServicesType");

            migrationBuilder.DropTable(
                name: "SliderImage");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
