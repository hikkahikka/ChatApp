using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleChatClient
{
    public class ChatService : IAsyncDisposable
    {
        private readonly string _url;
        private HubConnection? _connection;
        public event Action<string, string>? OnMessageReceived;
        public ChatService(string url)
        {
            _url = url;
        }
        public async Task LeaveChatAsync(UserConnection userConnection)
        {
            if (_connection != null)
            {
                try
                {
                    await _connection.InvokeAsync("LeaveChat", userConnection);
                }
                finally
                {
                    await _connection.DisposeAsync();
                    _connection = null;
                }

            }
        }
        public async Task SendMessageAsync(UserConnection userConnection, string message)
        {
            if (_connection != null)
            {
                await _connection.InvokeAsync("SendMessage", userConnection, message);
            }
        }
        public  async Task GetConnectionAsync(UserConnection userConnection)
        {
            if (_connection == null)
            {
                _connection = new HubConnectionBuilder()
                    .WithUrl(_url)
                    .WithAutomaticReconnect()
                    .Build();
                RegisterHandlers(_connection);
                await _connection.StartAsync();
            }
            await _connection.InvokeAsync("JoinChat", userConnection);
        }
        private void RegisterHandlers(HubConnection connection)
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });
        }
        public ValueTask DisposeAsync()
        {
            return _connection?.DisposeAsync() ?? ValueTask.CompletedTask;
        }
    }
}
