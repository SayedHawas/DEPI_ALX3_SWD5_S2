using Microsoft.EntityFrameworkCore;

namespace Day8MVCDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Add ConnectionString 
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                 pattern: "{controller=Site}/{action=index}/{id?}")
                //pattern: "{controller=Users}/{action=Login}/{id?}")
                //pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            //https://localhost:7015/Category/edit/4
            app.Run();
        }
    }
}
