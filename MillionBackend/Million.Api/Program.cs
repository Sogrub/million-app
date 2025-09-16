using Million.Infrastructure.Database;
using Million.Api.Middlewares;

namespace Million.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Million API",
                Version = "v1",
                Description = "Api for manage properties",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Diego Burgos",
                    Email = "diegoaburgos1@gmail.com",
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");
        app.UseCors("FrontendPolicy");
        app.UseErrorHandling();
        app.UseRequestLogging();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<IMongoDbContext>();
            await DatabaseSeeder.SeedAsync(dbContext.Database);
        }

        app.Run();
    }
}
