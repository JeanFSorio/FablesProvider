using FablesProvider.Core;
using FablesProvider.Core.Cover;
using FablesProvider.Core.Image;
using FablesProvider.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

int port = Environment.GetEnvironmentVariable("PORT") != null ? int.Parse(Environment.GetEnvironmentVariable("PORT")) : 80;

builder.WebHost.UseUrls("http://*:" + port);
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FablesDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors("AllowAny");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("books", (IRepository repository) => {
    return Results.Ok(new GetPagesQuery(repository).Handle());
});


app.MapGet("books/{id}", (int id, IRepository repository) => {
    return Results.Ok(new GetBookByIdQuery(repository).Handle(id));
});


app.MapGet("pages", (IRepository repository) => {
    return Results.Ok(new GetPagesQuery(repository).Handle());
});

app.MapGet("pages/{id}", (int id, IRepository repository) => {
    return Results.Ok(new GetBookByIdQuery(repository).Handle(id));
});

app.MapGet("images/{imageName}", (string imageName) => {
    return Results.Ok(new GetImageQuery().Handle(imageName));

});

app.UseHttpsRedirection();


app.Run();
