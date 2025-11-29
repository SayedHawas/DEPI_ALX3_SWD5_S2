using Day8MVCDemo.Services;
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

            //D i version
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceCategory, ServiceCategory>();
            //-----------------------------------------------------------------------
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

            //app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                 pattern: "{controller=Site}/{action=index}/{id?}")
                //pattern: "{controller=Users}/{action=Login}/{id?}")
                //pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            //https://localhost:7015/Category/edit/4

            #region Custom Milleware
            //app.Use(async (HttpContext, next) =>
            //{
            //    //Execute 
            //    await HttpContext.Response.WriteAsync("1-Write from MiddleWare  \n");
            //    //Call the Next Middleware
            //    await next.Invoke();
            //    //Call When Back with Response
            //    await HttpContext.Response.WriteAsync("5-Write from MiddleWare  \n");
            //});

            //app.Use(async (HttpContext, next) =>
            //{
            //    //Execute 
            //    await HttpContext.Response.WriteAsync("2-Write from MiddleWare  \n");
            //    //Call the Next Middleware
            //    await next();
            //    //Call When Back with Response
            //    await HttpContext.Response.WriteAsync("4-Write from MiddleWare  \n");
            //});

            //app.Map("/Products/index", apiApp =>
            //{
            //    apiApp.Use(async (context, next) =>
            //    {
            //        context.Response.WriteAsync("Products / Index Processing request \n");
            //        await next();
            //    });

            //    apiApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Products/Index \n");
            //    });
            //});


            //app.Run(async (HttpContext) =>
            //{
            //    //Execute 
            //    await HttpContext.Response.WriteAsync("3-Write from MiddleWare Terminator  \n");

            //});

            #endregion

            app.Run();
        }
    }
}
