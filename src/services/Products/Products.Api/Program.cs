using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Products.Api;
using Products.Api.GQL;
using Products.Api.GQL.Mutations;
using Products.Api.GQL.Queries;
using Products.Domain;
using Products.Infrastructure;
using Products.Infrastructure.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddServiceRegistery();
builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.AddMessagingConfiguration();

builder.Services.AddScoped<AppMutations>();
builder.Services.AddScoped<AppQueries>();
builder.Services.AddScoped<AppSchema>();

builder.Services.AddGraphQL().AddSystemTextJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.UseAuthorization();
app.UseHttpsRedirection();
app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");
app.MapControllers();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}