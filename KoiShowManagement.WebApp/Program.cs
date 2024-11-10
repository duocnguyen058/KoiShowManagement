using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Repositories.Repository;
using KoiShowManagement.Services.Interface;
using KoiShowManagement.Services.Service;
using KoiShowManagementSystem.Repositories;
using KoiShowManagementSystem.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//DI
builder.Services.AddDbContext<KoiShowManagementDbContext>();
//DI Repositories
builder.Services.AddScoped<ICompetitionResultRepository, CompetitionResultRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IKoiRepository, KoiRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IRefereeRepository, RefereeRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IScoreKoiRepository, ScoreKoiRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IUserReportRepository, UserReportRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


//DI Services
builder.Services.AddScoped<ICompetitionResultService, CompetitionResultService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IRefereeService, RefereeService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IScoreKoiService, ScoreKoiService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IUserReportService, UserReportService>();
builder.Services.AddScoped<IUserService, UserService>();




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
