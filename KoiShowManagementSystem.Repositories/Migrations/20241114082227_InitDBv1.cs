using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiShowManagementSystem.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDBv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tạo bảng "Events" chứa thông tin về các sự kiện
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false), // Tên sự kiện
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false), // Mô tả sự kiện
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false), // Ngày bắt đầu sự kiện
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false), // Ngày kết thúc sự kiện
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false), // Địa điểm sự kiện
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false) // Trạng thái sự kiện
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id); // Khóa chính cho bảng Events
                });

            // Tạo bảng "Users" chứa thông tin người dùng
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false), // Tên đăng nhập
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false), // Mật khẩu
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false), // Email người dùng
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false) // Vai trò của người dùng (Admin, Judge...)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id); // Khóa chính cho bảng Users
                });

            // Tạo bảng "Reports" để lưu các báo cáo liên quan đến sự kiện
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsId = table.Column<int>(type: "int", nullable: false), // Mã sự kiện
                    ReportType = table.Column<string>(type: "nvarchar(max)", nullable: false), // Loại báo cáo
                    ReportData = table.Column<string>(type: "nvarchar(max)", nullable: false) // Dữ liệu báo cáo
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id); // Khóa chính cho bảng Reports
                    table.ForeignKey(
                        name: "FK_Reports_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Liên kết với bảng Events
                });

            // Tạo bảng "JudgeAssignments" để lưu thông tin về phân công giám khảo cho sự kiện
            migrationBuilder.CreateTable(
                name: "JudgeAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false), // Người dùng (giám khảo)
                    EventsId = table.Column<int>(type: "int", nullable: false) // Sự kiện được phân công
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeAssignments", x => x.Id); // Khóa chính cho bảng JudgeAssignments
                    table.ForeignKey(
                        name: "FK_JudgeAssignments_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Liên kết với bảng Events
                    table.ForeignKey(
                        name: "FK_JudgeAssignments_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Liên kết với bảng Users
                });

            // Tạo bảng "Kois" để lưu thông tin về các cá Koi
            migrationBuilder.CreateTable(
                name: "Kois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false), // Chủ sở hữu cá Koi
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false), // Tên cá Koi
                    Variety = table.Column<string>(type: "nvarchar(max)", nullable: false), // Giống cá Koi
                    Size = table.Column<float>(type: "real", nullable: false), // Kích thước cá Koi
                    Age = table.Column<int>(type: "int", nullable: false), // Tuổi cá Koi
                    RegistrationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false) // Trạng thái đăng ký của cá Koi
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kois", x => x.Id); // Khóa chính cho bảng Kois
                    table.ForeignKey(
                        name: "FK_Kois_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Liên kết với bảng Users
                });

            // Tạo bảng "Event_Koi_Participations" để lưu thông tin tham gia của cá Koi vào sự kiện
            migrationBuilder.CreateTable(
                name: "Event_Koi_Participations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsId = table.Column<int>(type: "int", nullable: false), // Sự kiện tham gia
                    KoiId = table.Column<int>(type: "int", nullable: false), // Cá Koi tham gia
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false), // Loại tham gia (ví dụ: hạng mục hình dáng, màu sắc)
                    Score = table.Column<float>(type: "real", nullable: false) // Điểm chấm cho cá Koi
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Koi_Participations", x => x.Id); // Khóa chính cho bảng Event_Koi_Participations
                    table.ForeignKey(
                        name: "FK_Event_Koi_Participations_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Liên kết với bảng Events
                    table.ForeignKey(
                        name: "FK_Event_Koi_Participations_Kois_KoiId",
                        column: x => x.KoiId,
                        principalTable: "Kois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Liên kết với bảng Kois
                });

            // Tạo bảng "Scores" để lưu điểm số của các giám khảo cho từng cá Koi trong sự kiện
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Koi_ParticipationId = table.Column<int>(type: "int", nullable: false), // Mã tham gia sự kiện của cá Koi
                    UsersId = table.Column<int>(type: "int", nullable: false), // Giám khảo chấm điểm
                    ShapeScore = table.Column<float>(type: "real", nullable: false), // Điểm hình dáng
                    ColorScore = table.Column<float>(type: "real", nullable: false), // Điểm màu sắc
                    PatternScore = table.Column<float>(type: "real", nullable: false), // Điểm họa tiết
                    TotalScore = table.Column<float>(type: "real", nullable: false) // Tổng điểm
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id); // Khóa chính cho bảng Scores
                    table.ForeignKey(
                        name: "FK_Scores_Event_Koi_Participations_Event_Koi_ParticipationId",
                        column: x => x.Event_Koi_ParticipationId,
                        principalTable: "Event_Koi_Participations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Liên kết với bảng Event_Koi_Participations
                    table.ForeignKey(
                        name: "FK_Scores_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Liên kết với bảng Users
                });

            // Tạo các chỉ mục để tăng hiệu suất tìm kiếm và truy vấn
            migrationBuilder.CreateIndex(
                name: "IX_Event_Koi_Participations_EventsId",
                table: "Event_Koi_Participations",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Koi_Participations_KoiId",
                table: "Event_Koi_Participations",
                column: "KoiId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeAssignments_EventsId",
                table: "JudgeAssignments",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeAssignments_UsersId",
                table: "JudgeAssignments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Kois_UsersId",
                table: "Kois",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EventsId",
                table: "Reports",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_Event_Koi_ParticipationId",
                table: "Scores",
                column: "Event_Koi_ParticipationId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_UsersId",
                table: "Scores",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa các bảng khi cần roll back migration
            migrationBuilder.DropTable(
                name: "JudgeAssignments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Event_Koi_Participations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Kois");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
