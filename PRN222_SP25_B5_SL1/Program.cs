using System.Net;
using System.Net.Sockets;
using PRN222_SP25_B5_SL1.Models_DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Prn222Sp25B5Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoadDB}/{action=Index}/{id?}");

app.Run();

//TcpListener tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any))