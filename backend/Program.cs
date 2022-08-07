using backend.Clients;
using backend.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ISpotifyApiClient, SpotifyApiClient>();
builder.Services.Configure<SpotifyClientSettings>(builder.Configuration.GetSection("SpotifyClientSettings"));

builder.Services.AddCors(options => options.AddPolicy("LocalCorsPolicy",
    builder =>
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("https://localhost:3000")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("LocalCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
