using Quizo.API.Models.Config;
using Quizo.API.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureService(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


void ConfigureService(IServiceCollection services)
{
    services.Configure<QuizApiOptions>(builder.Configuration.GetSection("QuizApiOptions"));
    services.AddTransient<IQuizService, QuizService>();
    services.AddHttpClient<IQuizService, QuizService>();
}