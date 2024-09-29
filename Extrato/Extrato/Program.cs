
using Extrato.Data.Context;
using Microsoft.EntityFrameworkCore;
using Extrato.Data.Repositories;
using Extrato.Domain.Interface.Repositories;
using Extrato.Domain.Interface.Commons;
using Extrato.Services.AppServices;
using Extrato.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<TransacaoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransacaoConnection")));

builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
