using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1",new OpenApiInfo{
        Title = "Api for list of contacts"
    });
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IStorage, Sqlitestorage>();

builder.Services.AddCors(opt => 
opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins(args[0]);

    }
));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.UseCors("CorsPolicy");
app.Run(); 
