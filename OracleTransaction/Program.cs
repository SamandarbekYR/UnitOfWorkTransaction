using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OracleTransaction.BusinessLogic.Interfaces;
using OracleTransaction.BusinessLogic.Interfaces.Prosedures;
using OracleTransaction.BusinessLogic.Services;
using OracleTransaction.BusinessLogic.Services.Prodedures;
using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IPaynet,PaynetService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserCardService, UsersCardService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("OracleConnection");
    options.UseOracle(connection);
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
