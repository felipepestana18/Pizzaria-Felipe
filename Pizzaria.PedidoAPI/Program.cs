using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pizzaria.ClienteAPI.Config;
using Pizzaria.PedidoAPI.Repository;
using Pizzaria.PedidoAPI.Services;
using Pizzaria.PedidoAPI.Services.IServices;
using Pizzaria.PizzaAPI.Model.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configuração do MySql
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
// necessário criar primeiro na model MySqlContext
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 15))));
// necessário criar primeiro na Config AutoMapper
// para trasformar VO em mapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


builder.Services.AddHttpClient<IPizzaService, PizzaService>(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:PizzaAPI"]));
//builder.Services.AddHttpClient<ICartService, CartService>(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CartApi"]));
//builder.Services.AddHttpClient<ICouponService, CouponService>(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CouponApi"]));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzaria.PizzaApi" });

});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// definido os requisitos de segurança 


// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();


app.MapControllers();

app.MapControllers();

app.Run();
