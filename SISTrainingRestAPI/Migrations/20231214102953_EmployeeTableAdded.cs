using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISTrainingRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingStaff",
                columns: table => new
                {
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Course = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Training__96D4AB179EE11918", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingStudents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StaffId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Training__3214EC0713D5E96B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TrainingS__Staff__4F7CD00D",
                        column: x => x.StaffId,
                        principalTable: "TrainingStaff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingStudents_StaffId",
                table: "TrainingStudents",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingStudents");

            migrationBuilder.DropTable(
                name: "TrainingStaff");
        }
    }
}
