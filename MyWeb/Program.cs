using Microsoft.EntityFrameworkCore;
using BookUrBook.DataAccess.Data;
using BookUrBook.DataAccess.Repositories;
using BookUrBook.DataAccess.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;
using BookUrBook.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BookUrBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                            .AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<ApplicationDbContext>(ops =>
                ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(ops =>
            {
                ops.LoginPath = $"/Identity/Account/Login";
                ops.LogoutPath = $"/Identity/Account/Logout";
                ops.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
