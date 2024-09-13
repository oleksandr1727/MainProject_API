using Core.Interfaces;
using Core.MapperProfiles;
using Core.Service;
using Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using MainProject_API.Middlewares;
using System.Text.Json.Serialization;
using Data.Entitites;
using Microsoft.AspNetCore.Identity;
using MainProject_API.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LocalDb")!;
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //options.JsonSerializerOptions.MaxDepth = 0;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PetsDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddFluentValidationAutoValidation();
// enable client-side validation
builder.Services.AddFluentValidationClientsideAdapters();
// Load an assembly reference rather than using a marker type.
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<User, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<PetsDbContext>();

builder.Services.AddAutoMapper(typeof(AppProfile));
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
