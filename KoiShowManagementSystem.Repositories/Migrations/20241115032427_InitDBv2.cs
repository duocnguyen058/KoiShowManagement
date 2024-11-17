using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiShowManagementSystem.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDBv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thay đổi kiểu dữ liệu của cột 'Username' trong bảng 'Users' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'Role' trong bảng 'Users' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'Email' trong bảng 'Users' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'ReportType' trong bảng 'Reports' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "ReportType",
                table: "Reports",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'ReportData' trong bảng 'Reports' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "ReportData",
                table: "Reports",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'Variety' trong bảng 'Kois' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "Variety",
                table: "Kois",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'RegistrationStatus' trong bảng 'Kois' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationStatus",
                table: "Kois",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'Status' trong bảng 'Events' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Events",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Thay đổi kiểu dữ liệu của cột 'Category' trong bảng 'Event_Koi_Participations' từ nvarchar(max) thành nvarchar(100)
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Event_Koi_Participations",
                type: "nvarchar(100)", // Kiểu dữ liệu mới
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Khôi phục kiểu dữ liệu của cột 'Username' về nvarchar(max) trong bảng 'Users'
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'Role' về nvarchar(max) trong bảng 'Users'
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'Email' về nvarchar(max) trong bảng 'Users'
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'ReportType' về nvarchar(max) trong bảng 'Reports'
            migrationBuilder.AlterColumn<string>(
                name: "ReportType",
                table: "Reports",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'ReportData' về nvarchar(max) trong bảng 'Reports'
            migrationBuilder.AlterColumn<string>(
                name: "ReportData",
                table: "Reports",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'Variety' về nvarchar(max) trong bảng 'Kois'
            migrationBuilder.AlterColumn<string>(
                name: "Variety",
                table: "Kois",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'RegistrationStatus' về nvarchar(max) trong bảng 'Kois'
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationStatus",
                table: "Kois",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'Status' về nvarchar(max) trong bảng 'Events'
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Events",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            // Khôi phục kiểu dữ liệu của cột 'Category' về nvarchar(max) trong bảng 'Event_Koi_Participations'
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Event_Koi_Participations",
                type: "nvarchar(max)", // Kiểu dữ liệu cũ
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");
        }
    }
}
