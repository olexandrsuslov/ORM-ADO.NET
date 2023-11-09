using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpswebapi.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HouseholdStore");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "HouseholdStore",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                schema: "HouseholdStore",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "HouseholdStore",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SalesCoupons",
                schema: "HouseholdStore",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CouponID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "HouseholdStore",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "HouseholdStore",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "HouseholdStore",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderID);
                    table.ForeignKey(
                        name: "orders_ibfk_1",
                        column: x => x.CustomerID,
                        principalSchema: "HouseholdStore",
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HouseholdStore",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "employees_ibfk_1",
                        column: x => x.RoleID,
                        principalSchema: "HouseholdStore",
                        principalTable: "EmployeeRoles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "UserAuthentication",
                schema: "HouseholdStore",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserRoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.UserID);
                    table.ForeignKey(
                        name: "userauthentication_ibfk_1",
                        column: x => x.UserRoleID,
                        principalSchema: "HouseholdStore",
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "HouseholdStore",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "orderdetails_ibfk_1",
                        column: x => x.OrderID,
                        principalSchema: "HouseholdStore",
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "HouseholdStore",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    CouponID = table.Column<int>(type: "int", nullable: true),
                    OrderDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProductID);
                    table.ForeignKey(
                        name: "products_ibfk_1",
                        column: x => x.CategoryID,
                        principalSchema: "HouseholdStore",
                        principalTable: "ProductCategories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "products_ibfk_2",
                        column: x => x.CouponID,
                        principalSchema: "HouseholdStore",
                        principalTable: "SalesCoupons",
                        principalColumn: "CouponID");
                    table.ForeignKey(
                        name: "products_ibfk_3",
                        column: x => x.OrderDetailID,
                        principalSchema: "HouseholdStore",
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailID");
                });

            migrationBuilder.CreateTable(
                name: "SupplierProducts",
                schema: "HouseholdStore",
                columns: table => new
                {
                    SupplierProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    SupplierPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SupplierProductID);
                    table.ForeignKey(
                        name: "supplierproducts_ibfk_1",
                        column: x => x.SupplierID,
                        principalSchema: "HouseholdStore",
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                    table.ForeignKey(
                        name: "supplierproducts_ibfk_2",
                        column: x => x.ProductID,
                        principalSchema: "HouseholdStore",
                        principalTable: "Products",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "RoleID",
                schema: "HouseholdStore",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "OrderID",
                schema: "HouseholdStore",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "ProductID",
                schema: "HouseholdStore",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "CustomerID",
                schema: "HouseholdStore",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "CategoryID",
                schema: "HouseholdStore",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "CouponID",
                schema: "HouseholdStore",
                table: "Products",
                column: "CouponID");

            migrationBuilder.CreateIndex(
                name: "OrderDetailID",
                schema: "HouseholdStore",
                table: "Products",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "CouponCode",
                schema: "HouseholdStore",
                table: "SalesCoupons",
                column: "CouponCode",
                unique: true,
                filter: "[CouponCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ProductID",
                schema: "HouseholdStore",
                table: "SupplierProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "SupplierID",
                schema: "HouseholdStore",
                table: "SupplierProducts",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "UserName",
                schema: "HouseholdStore",
                table: "UserAuthentication",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserRoleID",
                schema: "HouseholdStore",
                table: "UserAuthentication",
                column: "UserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "SupplierProducts",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "UserAuthentication",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "EmployeeRoles",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "SalesCoupons",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "HouseholdStore");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "HouseholdStore");
        }
    }
}
