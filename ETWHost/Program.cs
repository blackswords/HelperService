using ETWHost.Core.CommandMission;
using ETWHost.Core.Mission;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMissionManager, MissionManager>();

var ms = new MissionManager();
ms.CreateManagerCollection(new Command("git tfs", "quick-clone http://172.21.0.11/DefaultCollection $/FUNDAMENTAL_UTILITY ./repo"), 100000);

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