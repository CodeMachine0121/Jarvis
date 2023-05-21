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

var app = builder.Build();

{
    builder.Services.AddTransient<IEventHandleService, MessageHandleService>();
    builder.Services.Decorate<IEventHandleService, FollowHandleService>();
    builder.Services.Decorate<IEventHandleService, UnfollowHandleService>();


    builder.Services.AddHttpClient<ILineProxy, LineProxy>(x=> x.BaseAddress = new Uri("http://localhost:5217"));
    
    builder.Services.AddTransient<IBotService, BotService>();
    builder.Services.AddTransient<TokenService>(); 
}

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