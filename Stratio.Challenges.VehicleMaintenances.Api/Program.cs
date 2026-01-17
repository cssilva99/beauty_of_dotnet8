using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Stratio.Challenges.VehicleMaintenances.Api.Services;
using Stratio.Challenges.VehicleMaintenances.Database;
using Stratio.Challenges.VehicleMaintenances.Database.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Secret Key
var key = Encoding.ASCII.GetBytes("My_Super_Awesome_Secret_Key_With_At_Least_23_Characters");


// The default JWT encription algorythm HS256
// demands at least 128 bits (16 bytes).
// However, in products environments it is recommended 
// one uses a 256 bits (32 bytes)

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();
// Since I'm having a connection problem in my publicly available AWS RDS
// I am simulating the Database Service
// I am injecting that "Mock" in here :
    
builder.Services.AddScoped<IAuthService, AuthService>();
    

    
// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MaintenancesContext>(builder => 
    builder.UseInMemoryDatabase("ExampleDb"));
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
