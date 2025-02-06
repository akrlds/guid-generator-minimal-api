var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/guid", (bool uppercase = false, bool hyphens = true) =>
{
    string guid = Guid.NewGuid().ToString();
    if (!hyphens)
    {
        guid = guid.Replace("-", "");
    }
    if (uppercase)
    {
        guid = guid.ToUpper();
    }
    return Results.Ok(new { Guid = guid });
})
.WithName("GetGuid")
.WithOpenApi();

await app.RunAsync();