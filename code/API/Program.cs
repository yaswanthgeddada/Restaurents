using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Restaurents.API.Extensions;
using Restaurents.API.Middlewares;
using Restaurents.Application.Extensions;
using Restaurents.Domain.Entities;
using Restaurents.Infrastructure.Data;
using Restaurents.Infrastructure.Extensions;
using Serilog;
using Serilog.Events;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentationExtension();
builder.Services.AddInfrasctuctureDI(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCors();



var app = builder.Build();

// var scope = app.Services.CreateScope();
// var seeder = scope.ServiceProvider.GetRequiredService<IRestaurentsSeeder>();
// await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandelingMiddleware>();
app.UseMiddleware<LongProcessingRequestsMiddleware>();


app.UseSerilogRequestLogging();

app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseHttpsRedirection();

app.MapGroup("api/identity").WithTags("api/identity").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
