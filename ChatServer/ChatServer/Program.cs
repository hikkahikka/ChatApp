using ChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
var app = builder.Build();

app.MapHub<ChatHub>("/chat");
app.Run("http://localhost:5000");
