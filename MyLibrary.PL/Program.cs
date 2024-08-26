using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLibrary.BLL.Configuration;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Services;
using MyLibrary.DAL.Data;
using MyLibrary.DAL.IRepositories;
using MyLibrary.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
// Add AutomapperProfile to the container.
var mappConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new LibraryProfile());
    });
IMapper mapper = mappConfig.CreateMapper();
services.AddSingleton(mapper);

//Add DbContext 
var connectionString = builder.Configuration.GetConnectionString("LibraryConnectionStrings");
services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

//Dependency registration
services.AddScoped<IAuthorRepository, AuthorRepository>();
services.AddScoped<IBookRepository, BookRepository>();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IAuthorService, AuthorService>();
services.AddScoped<IBookService, BookService>();
services.AddScoped<ICategoryService, CategoryService>();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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
