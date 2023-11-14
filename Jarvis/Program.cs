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
builder.Services.AddHttpClient<ILineProxy, LineProxy>(x=>
{
    x.BaseAddress = new Uri(builder.Configuration["HttpServer:line"]!);
});

builder.Services.AddSingleton<IBotService, BotService>();

builder.Services.AddTransient<IEventService, MessageService>();
builder.Services.Decorate<IEventService, FollowService>();
builder.Services.Decorate<IEventService, UnfollowService>();

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