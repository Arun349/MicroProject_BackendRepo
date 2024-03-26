using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalAppointment",
                columns: table => new
                {
                    FinalAppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileModel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProblemDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepairStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    repairShopShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalAppointment", x => x.FinalAppointmentId);
                    table.ForeignKey(
                        name: "FK_FinalAppointment_RepairShop_repairShopShopId",
                        column: x => x.repairShopShopId,
                        principalTable: "RepairShop",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalAppointment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinalService",
                columns: table => new
                {
                    FinalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    repairShopShopId = table.Column<int>(type: "int", nullable: false),
                    FinalAppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalService", x => x.FinalServiceId);
                    table.ForeignKey(
                        name: "FK_FinalService_FinalAppointment_FinalAppointmentId",
                        column: x => x.FinalAppointmentId,
                        principalTable: "FinalAppointment",
                        principalColumn: "FinalAppointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalService_RepairShop_repairShopShopId",
                        column: x => x.repairShopShopId,
                        principalTable: "RepairShop",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalService_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FinalAppointment_UserId",
                table: "FinalAppointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalAppointment_repairShopShopId",
                table: "FinalAppointment",
                column: "repairShopShopId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalService_FinalAppointmentId",
                table: "FinalService",
                column: "FinalAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalService_UserId",
                table: "FinalService",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalService_repairShopShopId",
                table: "FinalService",
                column: "repairShopShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalService");

            migrationBuilder.DropTable(
                name: "FinalAppointment");
        }
    }
}
