using BookShop.DataAccess;
using BookShop.Models;
using BookShop.Services.BookRepo;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.//
builder.Services.AddDbContext<BookShopDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication("Jwt")
    .AddJwtBearer("Jwt",options => 
    {
        var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constant.Secret));
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer=Constant.Issuer,
            ValidAudience=Constant.Audience,
            IssuerSigningKey=key
        };
    });

//Policy to authorize all controllers without Authorization Controller
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ExcludeAuth", policy =>
//    policy.RequireAssertion(context =>
//    context.Resource is not AuthorizationFilterContext ||
//    ((AuthorizationFilterContext)context.Resource)
//    .ActionDescriptor
//    .DisplayName
//    .StartsWith("AuthorizationController", StringComparison.OrdinalIgnoreCase)));
//});

builder.Services.AddTransient<IBooksRepository,BooksRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
//builder.Services.AddControllers(options=>
//{
//    options.Filters.Add(new AuthorizeFilter("ExcludeAuth"));
//});

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

//builder.Services.AddLogging(loggingBuilder => {
//    loggingBuilder.AddSerilog();
//});

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

app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();
