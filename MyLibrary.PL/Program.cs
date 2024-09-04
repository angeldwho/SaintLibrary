using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyLibrary.BLL.Configuration;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Services;
using MyLibrary.DAL.Data;
using MyLibrary.DAL.IRepositories;
using MyLibrary.DAL.Repositories;
using MyLibrary.PL.DropDown;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
// Add AutomapperProfile to the container.

services.AddAutoMapper(typeof(LibraryProfile).Assembly);

//Add DbContext 
var connectionString = builder.Configuration.GetConnectionString("LibraryConnectionStrings");
services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

//Dependency registration
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

services.AddScoped<IAuthorRepository, AuthorRepository>();
services.AddScoped<IBookRepository, BookRepository>();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IAuthorService, AuthorService>();
services.AddScoped<IBookService, BookService>();
services.AddScoped<ICategoryService, CategoryService>();

services.AddScoped<IOperationFilter>(provider =>
{
    var myService = provider.GetRequiredService<IBookService>();
    return new BookDropdownOperationFilter(myService);
});

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.OperationFilter<BookDropdownOperationFilter>();
});

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
