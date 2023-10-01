using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        /// 

        protected override void Up(MigrationBuilder migrationBuilder) { }
        /*protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    custid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contactname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contacttitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    titleofcourtesy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    hiredate = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    mgrid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empid);
                    table.ForeignKey(
                        name: "FK_Employees_Employees",
                        column: x => x.mgrid,
                        principalTable: "Employees",
                        principalColumn: "empid");
                });

            migrationBuilder.CreateTable(
                name: "Nums",
                columns: table => new
                {
                    n = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nums", x => x.n);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    shipperid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.shipperid);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplierid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contactname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contacttitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierid);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    testid = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.testid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custid = table.Column<int>(type: "int", nullable: true),
                    empid = table.Column<int>(type: "int", nullable: false),
                    orderdate = table.Column<DateTime>(type: "date", nullable: false),
                    requireddate = table.Column<DateTime>(type: "date", nullable: false),
                    shippeddate = table.Column<DateTime>(type: "date", nullable: true),
                    shipperid = table.Column<int>(type: "int", nullable: false),
                    freight = table.Column<decimal>(type: "money", nullable: false),
                    shipname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    shipaddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    shipcity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    shipregion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    shippostalcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    shipcountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderid);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.custid,
                        principalTable: "Customers",
                        principalColumn: "custid");
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.empid,
                        principalTable: "Employees",
                        principalColumn: "empid");
                    table.ForeignKey(
                        name: "FK_Orders_Shippers",
                        column: x => x.shipperid,
                        principalTable: "Shippers",
                        principalColumn: "shipperid");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplierid = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    unitprice = table.Column<decimal>(type: "money", nullable: false),
                    discontinued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productid);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "categoryid");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers",
                        column: x => x.supplierid,
                        principalTable: "Suppliers",
                        principalColumn: "supplierid");
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    testid = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    studentid = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    score = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => new { x.testid, x.studentid });
                    table.ForeignKey(
                        name: "FK_Scores_Tests",
                        column: x => x.testid,
                        principalTable: "Tests",
                        principalColumn: "testid");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    unitprice = table.Column<decimal>(type: "money", nullable: false),
                    qty = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))"),
                    discount = table.Column<decimal>(type: "numeric(4,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.orderid, x.productid });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.orderid,
                        principalTable: "Orders",
                        principalColumn: "orderid");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "productid");
                });

            migrationBuilder.CreateIndex(
                name: "idx_nc_categoryname",
                table: "Categories",
                column: "categoryname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_city",
                table: "Customers",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "idx_nc_companyname",
                table: "Customers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_postalcode",
                table: "Customers",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "idx_nc_region",
                table: "Customers",
                column: "region");

            migrationBuilder.CreateIndex(
                name: "idx_nc_lastname",
                table: "Employees",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_postalcode",
                table: "Employees",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_mgrid",
                table: "Employees",
                column: "mgrid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_orderid",
                table: "OrderDetails",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_productid",
                table: "OrderDetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_custid",
                table: "Orders",
                column: "custid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_empid",
                table: "Orders",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_orderdate",
                table: "Orders",
                column: "orderdate");

            migrationBuilder.CreateIndex(
                name: "idx_nc_shippeddate",
                table: "Orders",
                column: "shippeddate");

            migrationBuilder.CreateIndex(
                name: "idx_nc_shipperid",
                table: "Orders",
                column: "shipperid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_shippostalcode",
                table: "Orders",
                column: "shippostalcode");

            migrationBuilder.CreateIndex(
                name: "idx_nc_categoryid",
                table: "Products",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_productname",
                table: "Products",
                column: "productname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_supplierid",
                table: "Products",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "idx_nc_testid_score",
                table: "Scores",
                columns: new[] { "testid", "score" });

            migrationBuilder.CreateIndex(
                name: "idx_nc_companyname",
                table: "Suppliers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "idx_nc_postalcode",
                table: "Suppliers",
                column: "postalcode");
        }*/

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nums");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
