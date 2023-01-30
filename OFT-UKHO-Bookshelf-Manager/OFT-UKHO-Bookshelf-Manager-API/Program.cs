using Microsoft.EntityFrameworkCore;
using OFT_UKHO_Bookshelf_Manager.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped <IBookLibraryContext, BookLibraryContext> ();
builder.Services.AddDbContext<BookLibraryContext>(o => 
    o.UseSqlServer("Server=oft-book-library.database.windows.net; Database=BookLibrary; User Id=libraryadmin; Password=Admin123"));
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
