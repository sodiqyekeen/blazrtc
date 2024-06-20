using BlazRTC.Sample.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();

var app = builder.Build();



app.UseHttpsRedirection();

app.MapHub<BlazRtcHub>("/blazrtc");

app.Run();


