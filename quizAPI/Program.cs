using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quizAPI.Business;
using quizAPI.Interface;
using quizAPI.Model.Database;
using quizAPI.Model.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args);

IConfiguration configuration = configurationBuilder.Build();

builder.Services.AddDbContext<DBAlphaContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString(Const.DBConnectionString))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

builder.Services.AddScoped<IMembers, MembersBC>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiz v1");
    });
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Quiz v1"));
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
