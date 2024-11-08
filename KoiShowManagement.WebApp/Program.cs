using Microsoft.AspNetCore.Authentication.Cookies;
using KoiShowManagement.WebApp;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ Razor Pages và Authentication
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Đường dẫn trang đăng nhập
        options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn khi quyền truy cập bị từ chối
    });

var app = builder.Build();

// Cấu hình Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware cho Authentication và Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages(); // Đảm bảo bạn có MapRazorPages() ở đây.

app.Run();
