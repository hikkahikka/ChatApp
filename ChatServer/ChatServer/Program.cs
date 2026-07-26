using Microsoft.EntityFrameworkCore;
using ChatServer.Hubs;
using ChatServer.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSignalR();

builder.Services.AddDbContext<ChatDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.MapHub<ChatHub>("/chat");

app.Run("http://localhost:5000");   