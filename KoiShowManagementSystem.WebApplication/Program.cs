<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Repositories.Repository;
using KoiShowManagementSystem.Services.Interface;
using KoiShowManagementSystem.Services.Service;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Repositories.Implementation;
using KoiShowManagementSystem.Services;
using KoiShowManagementSystem.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ vào container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Cấu hình DbContext với chuỗi kết nối SQL Server
builder.Services.AddDbContext<KoiShowManagementDbcontextContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KoiShowManagementDbContext")));

// Đăng ký các repository
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICompetitionCategoryRepository, CompetitionCategoryRepository>();
builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IJudgeRepository, JudgeRepository>();
builder.Services.AddScoped<IKoiCompetitionCategoryRepository, KoiCompetitionCategoryRepository>();
builder.Services.AddScoped<IKoiFishRepository, KoiFishRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
=======
﻿var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
>>>>>>> 326395af6a86d8090aa86279419b2334c8bcafb1

// Đăng ký các dịch vụ
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICompetitionCategoryService, CompetitionCategoryService>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IJudgeService, JudgeService>();
builder.Services.AddScoped<IKoiCompetitionCategoryService, KoiCompetitionCategoryService>();
builder.Services.AddScoped<IKoiFishService, KoiFishService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IReportService, ReportService>();

// Đăng ký dịch vụ Identity với IdentityUser (không cần ApplicationUser nữa)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<KoiShowManagementDbcontextContext>()
    .AddDefaultTokenProviders();

// Thêm dịch vụ Authentication và Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Đường dẫn login cho authentication
        options.LogoutPath = "/Account/Logout";  // Đường dẫn logout cho authentication
        options.AccessDeniedPath = "/Home/AccessDenied";  // Đường dẫn nếu bị từ chối truy cập
    });

// Định nghĩa các chính sách quyền cho các vai trò khác nhau
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Judge", policy => policy.RequireRole("Judge"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ManagerOnly", policy => policy.RequireRole("Manager"));
    options.AddPolicy("StaffOnly", policy => policy.RequireRole("Staff"));
    options.AddPolicy("RefereeOnly", policy => policy.RequireRole("Referee"));
});

// Thiết lập pipeline ứng dụng
var app = builder.Build();

<<<<<<< HEAD
// Bật chuyển hướng HTTPS
=======
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

>>>>>>> 326395af6a86d8090aa86279419b2334c8bcafb1
app.UseHttpsRedirection();

// Phục vụ các file tĩnh (hình ảnh, CSS, JS, v.v.) từ thư mục wwwroot
app.UseStaticFiles();

// Thiết lập middleware cho routing, authentication và authorization
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Cấu hình route mặc định cho controller Home và action Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Đường dẫn mặc định cho controller Home và action Index

// Bật Razor Pages
app.MapRazorPages();

<<<<<<< HEAD
// Chạy ứng dụng
app.Run();
=======
app.Run();
>>>>>>> 326395af6a86d8090aa86279419b2334c8bcafb1
