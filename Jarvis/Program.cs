using Jarvis.Interfaces;
using Jarvis.Proxies;
using Jarvis.Services;
using Jarvis.Services.EventHandlingServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TokenService>();
builder.Services.AddHttpClient<ILineProxy, LineProxy>();

builder.Services.AddTransient<IEventHandleService, MessageHandleService>();
builder.Services.Decorate<IEventHandleService, FollowHandleService>();
builder.Services.Decorate<IEventHandleService, UnfollowHandleService>();

builder.Services.AddSingleton<IBotService, BotService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();