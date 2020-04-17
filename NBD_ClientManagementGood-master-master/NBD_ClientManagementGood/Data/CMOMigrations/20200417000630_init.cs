using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBD_ClientManagementGood.Data.CMOMigrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CMO");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "CMO",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "DesignBudget",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentHours = table.Column<int>(nullable: false),
                    EstHours = table.Column<int>(nullable: false),
                    HoursTotal = table.Column<int>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignBudget", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DesignDaily",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stage = table.Column<string>(maxLength: 1, nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    Task = table.Column<string>(maxLength: 250, nullable: false),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignDaily", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LabourDepartments",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DepartmentDescription = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourDepartments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LabourReport",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourReport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Unit = table.Column<string>(maxLength: 10, nullable: false),
                    List = table.Column<int>(nullable: false),
                    OIS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    LastOrdered = table.Column<DateTime>(nullable: false),
                    AvgNet = table.Column<int>(nullable: false),
                    List = table.Column<int>(nullable: false),
                    OIS = table.Column<int>(nullable: false),
                    IS_OB = table.Column<int>(nullable: false),
                    OOO = table.Column<int>(nullable: false),
                    OO_OB = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pottery",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Features = table.Column<string>(maxLength: 100, nullable: false),
                    List = table.Column<int>(nullable: false),
                    OIS = table.Column<int>(nullable: false),
                    IS_OB = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pottery", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductionWorkReport",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionWorkReport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "CMO",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 30, nullable: false),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalSchema: "CMO",
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    Size = table.Column<string>(maxLength: 100, nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Net = table.Column<double>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    InstallDate = table.Column<DateTime>(nullable: false),
                    ProductionWorkReportID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_ProductionWorkReport_ProductionWorkReportID",
                        column: x => x.ProductionWorkReportID,
                        principalSchema: "CMO",
                        principalTable: "ProductionWorkReport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourUnits",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    EstCost = table.Column<int>(nullable: false),
                    TaskName = table.Column<string>(maxLength: 100, nullable: false),
                    TaskDescription = table.Column<string>(maxLength: 1000, nullable: false),
                    ProductionWorkReportID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourUnits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LabourUnits_ProductionWorkReport_ProductionWorkReportID",
                        column: x => x.ProductionWorkReportID,
                        principalSchema: "CMO",
                        principalTable: "ProductionWorkReport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourStaffs",
                schema: "CMO",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    LabourDeparmentID = table.Column<int>(nullable: false),
                    LabourDepartmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourStaffs", x => new { x.LabourDeparmentID, x.StaffID });
                    table.ForeignKey(
                        name: "FK_LabourStaffs_LabourDepartments_LabourDepartmentID",
                        column: x => x.LabourDepartmentID,
                        principalSchema: "CMO",
                        principalTable: "LabourDepartments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabourStaffs_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalSchema: "CMO",
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "CMO",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormalName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    eMail = table.Column<string>(maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityID",
                        column: x => x.CityID,
                        principalSchema: "CMO",
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "CMO",
                columns: table => new
                {
                    MaterialID = table.Column<int>(nullable: false),
                    PlantID = table.Column<int>(nullable: false),
                    PotteryID = table.Column<int>(nullable: false),
                    ToolID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => new { x.ItemID, x.MaterialID, x.PlantID, x.PotteryID, x.ToolID });
                    table.ForeignKey(
                        name: "FK_Product_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "CMO",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalSchema: "CMO",
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Plant_PlantID",
                        column: x => x.PlantID,
                        principalSchema: "CMO",
                        principalTable: "Plant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Pottery_PotteryID",
                        column: x => x.PotteryID,
                        principalSchema: "CMO",
                        principalTable: "Pottery",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Tools_ToolID",
                        column: x => x.ToolID,
                        principalSchema: "CMO",
                        principalTable: "Tools",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "CMO",
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlueprintCode = table.Column<string>(maxLength: 12, nullable: false),
                    EstStart = table.Column<DateTime>(nullable: false),
                    EstEnd = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "CMO",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvBids",
                schema: "CMO",
                columns: table => new
                {
                    BidID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvBids", x => new { x.BidID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_InvBids_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "CMO",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvBids_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "CMO",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                schema: "CMO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProEstHourly = table.Column<double>(nullable: false),
                    ProEstMaterialCost = table.Column<double>(nullable: false),
                    ProEstTotalHours = table.Column<double>(nullable: false),
                    ProBidPercent = table.Column<double>(nullable: false),
                    BidID = table.Column<int>(nullable: false),
                    LabourDepartmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Productions_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "CMO",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productions_LabourDepartments_LabourDepartmentID",
                        column: x => x.LabourDepartmentID,
                        principalSchema: "CMO",
                        principalTable: "LabourDepartments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labours",
                schema: "CMO",
                columns: table => new
                {
                    ProductionID = table.Column<int>(nullable: false),
                    LabourUnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labours", x => new { x.LabourUnitID, x.ProductionID });
                    table.ForeignKey(
                        name: "FK_Labours_LabourUnits_LabourUnitID",
                        column: x => x.LabourUnitID,
                        principalSchema: "CMO",
                        principalTable: "LabourUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labours_Productions_ProductionID",
                        column: x => x.ProductionID,
                        principalSchema: "CMO",
                        principalTable: "Productions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionItems",
                schema: "CMO",
                columns: table => new
                {
                    ProductionID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionItems", x => new { x.ItemID, x.ProductionID });
                    table.ForeignKey(
                        name: "FK_ProductionItems_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "CMO",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionItems_Productions_ProductionID",
                        column: x => x.ProductionID,
                        principalSchema: "CMO",
                        principalTable: "Productions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectID",
                schema: "CMO",
                table: "Bids",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                schema: "CMO",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityID",
                schema: "CMO",
                table: "Clients",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Phone",
                schema: "CMO",
                table: "Clients",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_eMail",
                schema: "CMO",
                table: "Clients",
                column: "eMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvBids_ItemID",
                schema: "CMO",
                table: "InvBids",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProductionWorkReportID",
                schema: "CMO",
                table: "Item",
                column: "ProductionWorkReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_ProductionID",
                schema: "CMO",
                table: "Labours",
                column: "ProductionID");

            migrationBuilder.CreateIndex(
                name: "IX_LabourStaffs_LabourDepartmentID",
                schema: "CMO",
                table: "LabourStaffs",
                column: "LabourDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LabourStaffs_StaffID",
                schema: "CMO",
                table: "LabourStaffs",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_LabourUnits_ProductionWorkReportID",
                schema: "CMO",
                table: "LabourUnits",
                column: "ProductionWorkReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MaterialID",
                schema: "CMO",
                table: "Product",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PlantID",
                schema: "CMO",
                table: "Product",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PotteryID",
                schema: "CMO",
                table: "Product",
                column: "PotteryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ToolID",
                schema: "CMO",
                table: "Product",
                column: "ToolID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionItems_ProductionID",
                schema: "CMO",
                table: "ProductionItems",
                column: "ProductionID");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_BidID",
                schema: "CMO",
                table: "Productions",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_LabourDepartmentID",
                schema: "CMO",
                table: "Productions",
                column: "LabourDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                schema: "CMO",
                table: "Projects",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignBudget",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "DesignDaily",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "InvBids",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "LabourReport",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Labours",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "LabourStaffs",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "ProductionItems",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "LabourUnits",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Material",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Plant",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Pottery",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Tools",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Productions",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "ProductionWorkReport",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "LabourDepartments",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "CMO");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "CMO");
        }
    }
}
