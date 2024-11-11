using KoiShowManagementSystem.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đọc cấu hình từ appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Đăng ký DbContext với cấu hình từ appsettings.json
builder.Services.AddDbContext<KoiShowManagementDbcontextContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KoiShowManagementDbContext")));

// Thêm các dịch vụ khác nếu có
builder.Services.AddRazorPages();

var app = builder.Build();

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
