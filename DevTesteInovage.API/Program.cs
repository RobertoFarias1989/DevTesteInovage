using DevTesteInovage.API.Filters;
using DevTesteInovage.Application.Profiles;
using DevTesteInovage.Application.Services.Implementations;
using DevTesteInovage.Application.Services.Interfaces;
using DevTesteInovage.Application.Validators;
using DevTesteInovage.Core.Repositories;
using DevTesteInovage.Infrastructure;
using DevTesteInovage.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
       .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdatePurchaseInputValidator>());

var connectionString = builder.Configuration.GetConnectionString("DevTesteInovageCs");
builder.Services.AddDbContext<DevTesteInovageDbContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseItemRepository, PurchaseItemRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseItemService, PurchaseItemService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
