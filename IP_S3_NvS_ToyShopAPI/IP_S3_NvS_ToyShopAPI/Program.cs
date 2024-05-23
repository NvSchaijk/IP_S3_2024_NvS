using IP_Business;
using IP_Business.Components;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_DateLayer;
using IP_DateLayer.Repos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSpolicy", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:5173");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ToyShopAPIDBContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddScoped<IBrandRepo, BrandRepo>();
builder.Services.AddScoped<IBrandComponent, BrandComponent>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryComponent, CategoryComponent>();
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IItemComponent, ItemComponent>();
builder.Services.AddScoped<ICategory_ItemRepo, Category_ItemRepo>();


//JSON serializer
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
Options => Options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

app.UseCors("CORSpolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSpolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

