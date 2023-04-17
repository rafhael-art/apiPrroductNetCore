using ApiProduct;
using ApiProduct.DbContexts;
using ApiProduct.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//Registra la connexion a la BD
var connectionString = builder.Configuration.GetConnectionString("ProductDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


//Registrar Automapper
IMapper mapper = MapppingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency Inyeccion
builder.Services.AddScoped<IProductRepository, ProductSQLRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

