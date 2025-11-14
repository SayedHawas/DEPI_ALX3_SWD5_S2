using Day4WebApiWithDataDemo.Services.Impelement;
using Day4WebApiWithDataDemo.UnitOfWorks;
namespace Day4WebApiWithDataDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            //builder.Services.AddControllers().AddJsonOptions(option =>
            //{
            //    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});

            //Add DI For DbContext
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //Service DI
            //builder.Services.AddSingleton<DepartmentRepository>();
            //builder.Services.AddScoped<DepartmentRepository>();
            //builder.Services.AddTransient<DepartmentRepository>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceDepartment, ServiceDepartment>();
            builder.Services.AddScoped<IServiceClient, ServiceClient>();

            //Add Cors Option 
            builder.Services.AddCors(options =>
            options.AddPolicy("MyCors",
            CorsPolicyBuilder =>
            {
                CorsPolicyBuilder.AllowAnyOrigin();
            }));


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyCors");

            app.MapControllers();

            app.Run();
        }
    }
}
