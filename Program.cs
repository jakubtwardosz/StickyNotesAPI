using Microsoft.EntityFrameworkCore;
using StickyNotesApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaj us³ugi do kontenera.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DataContext")));

// Konfiguracja CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Umo¿liwia ¿¹dania z dowolnego Ÿród³a
              .AllowAnyHeader()  // Umo¿liwia dowolne nag³ówki
              .AllowAnyMethod(); // Umo¿liwia dowolne metody HTTP
    });
});

// Dodaj us³ugi Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfiguracja potoku ¿¹dañ HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// U¿yj CORS przed `UseAuthorization`
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
