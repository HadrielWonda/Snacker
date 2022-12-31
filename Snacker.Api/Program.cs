using System.Collections.Immutable;
using System.Net.Mime;
using System;
using Snacker.Api.Middleware;
using Snacker.Application;
using Snacker.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
builder.Services
.AddApplication();
.AddInfrastructure(builder.Configuration);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingsFilterAttributes>());
builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory,SnackerProblemDetailsFactory>();
}




var app = builder.Build();
{
app.UseExceptionHandler("/error");

app.Map("/error",{HttpContext httpContext} =>
//{
//    Exception? exception = httpContext.Features.Get<IExceptionHandlerFearure>()?.Error;

  //  return Results.Problem();
//}

)
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
}




