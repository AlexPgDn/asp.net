using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services,
        ConfigurationManager configuration){

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api for list of contacts"
            });
        });
        services.AddControllers();
        
        var stringconnection = configuration.GetConnectionString("SqliteStringConnection");
        services.AddDbContext<SqlLiteDbContext>(opt => opt.UseSqlite(stringconnection));
        services.AddScoped<IPaginationStorage, SqlitePaginationEfStorage>();
        services.AddScoped<IInitializer, SqliteEfFakerInitializer> ();


        services.AddCors(opt =>
        opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(configuration["client"]);

            }
        ));
        return services;
    }
}