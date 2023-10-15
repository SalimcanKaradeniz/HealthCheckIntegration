var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddHealthChecksUI(settings =>
    {
        settings.AddHealthCheckEndpoint("Account API", "https://localhost:7084/health");
        settings.AddHealthCheckEndpoint("Product API", "https://localhost:7111/health");
    }).AddPostgreSqlStorage(connectionString: builder.Configuration.GetConnectionString("MonitoringSQLServer"));


var app = builder.Build();

app.UseHealthChecksUI(options => options.UIPath = "/health-ui");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
