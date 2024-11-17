using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiShowManagementSystem.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDBv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Xóa cột "EnventsId" trong bảng "JudgeAssignments"
            // Ghi chú: Đoạn mã này loại bỏ cột "EnventsId" không còn sử dụng trong bảng "JudgeAssignments"
            migrationBuilder.DropColumn(
                name: "EnventsId",  // Tên cột cần xóa
                table: "JudgeAssignments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Thêm lại cột "EnventsId" vào bảng "JudgeAssignments"
            // Ghi chú: Đoạn mã này sẽ phục hồi cột "EnventsId" vào bảng "JudgeAssignments" trong trường hợp rollback migration
            migrationBuilder.AddColumn<int>(
                name: "EnventsId",  // Tên cột cần thêm lại
                table: "JudgeAssignments",
                type: "int",  // Loại dữ liệu của cột
                nullable: false,  // Cột không được để null
                defaultValue: 0);  // Giá trị mặc định khi không có dữ liệu
        }
    }
}
