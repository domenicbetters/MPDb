using Microsoft.EntityFrameworkCore;
using MovieDbBackend.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:5001/api/MotionPictures",
                                                 "https://localhost:5002")
                                                 .AllowAnyHeader()
                                                 .AllowAnyMethod();
                      });
});



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MotionPictureContext>(opt =>
    opt.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MovieDatabase;Integrated Security=True"));
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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
