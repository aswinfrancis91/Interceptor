using Castle.DynamicProxy;
using Hook;
using InterceptorAPI;
using InterceptorAPI.Model;

var builder = WebApplication.CreateBuilder(args);

//Info: Add services to the container. The below three lines are added extra to get  hook working
builder.Services.AddSingleton(new ProxyGenerator());
builder.Services.AddScoped<IInterceptor, HookInterceptor>();
builder.Services.AddProxiedScoped<IStudent, Student>();

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