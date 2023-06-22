using EntityFramework.EntityFrameworkCore;
using EntityFramework.Interfaces;
using EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskReporter.Business.Interfaces;
using TaskReporter.Business.Services;

namespace TaskReporter;

public static class BuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<TaskReporterDBContext>(c =>
        {
            c.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
        });
        builder.Services.AddTransient<IDailyReportService, DailyReportService>();
        builder.Services.AddTransient<IDailyReportRepository, DailyReportRepository>();
        builder.Services.AddTransient<IWeeklyReportService, WeeklyReportService>();
        builder.Services.AddTransient<IWeeklyReportRepository, WeeklyReportRepository>();
        builder.Services.AddTransient<IMonthlyReportService, MonthlyReportService>();
        builder.Services.AddTransient<IMonthlyReportReposity, MonthlyReportRepository>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
    }
    
    public static void ConfigureEnvironments(this WebApplicationBuilder builder)
    {
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    }


}