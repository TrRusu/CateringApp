using System.Text.Json.Serialization;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using DAL.Seed;
using Business;
using Business.Interfaces;
using DAL.Handlers;
using DAL.Interfaces;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISessionHandler, SessionHandler>();
builder.Services.AddScoped<ISessionBusiness, SessionBusiness>();
builder.Services.AddScoped<IOrderHandler, OrderHandler>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IItemHandler, ItemHandler>();
builder.Services.AddScoped<IItemManager, ItemManager>();
builder.Services.AddScoped<ITableHandler, TableHandler>();
builder.Services.AddScoped<ITableManager, TableManager>();
builder.Services.AddScoped<IIngredientHandler, IngredientHandler>();
builder.Services.AddScoped<IIngredientManager, IngredientManager>();
builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.MaxDepth = 64;
    options.JsonSerializerOptions.IncludeFields = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

// CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
