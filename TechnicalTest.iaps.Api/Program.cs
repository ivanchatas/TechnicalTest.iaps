using Microsoft.EntityFrameworkCore;
using TechnicalTest.iaps.Api.Middleware;
using TechnicalTest.iaps.Core.Services;
using TechnicalTest.iaps.Domain.Interfaces.Repositories;
using TechnicalTest.iaps.Domain.Interfaces.Services;
using TechnicalTest.iaps.Infrastructure;
using TechnicalTest.iaps.Infrastructure.Context;
using TechnicalTest.iaps.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TechnicalTestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<IDatabaseSeeder, DatabaseSeeder>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddTransient<IPaperService, PaperService>()
                .AddTransient<IAuthorService, AuthorService>()
                .AddTransient<ICategoryService, CategoryService>();

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

//using var serviceScope = app.Services.CreateScope();
//var initializers = serviceScope.ServiceProvider.GetServices<IDatabaseSeeder>();
//foreach (var initializer in initializers)
//{
//    initializer.Initialize();
//}


app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
