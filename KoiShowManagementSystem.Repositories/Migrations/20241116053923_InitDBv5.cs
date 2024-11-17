using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiShowManagementSystem.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDBv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thêm cột "PhotoPath" vào bảng "Kois"
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",  // Tên cột cần thêm
                table: "Kois",      // Tên bảng
                type: "nvarchar(max)",  // Kiểu dữ liệu của cột
                nullable: true);    // Cột có thể null
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa cột "PhotoPath" khỏi bảng "Kois" nếu rollback migration
            migrationBuilder.DropColumn(
                name: "PhotoPath",  // Tên cột cần xóa
                table: "Kois");     // Tên bảng
        }
    }
}
