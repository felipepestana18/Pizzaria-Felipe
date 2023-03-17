using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pizzaria.ClienteAPI.Config;
using Pizzaria.ClienteAPI.Model.Context;
using Pizzaria.ClienteAPI.Repository;


var builder = WebApplication.CreateBuilder(args);

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



builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzaria.ClienteAPI" });

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
