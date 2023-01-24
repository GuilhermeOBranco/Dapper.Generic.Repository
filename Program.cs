using LogMiddleware.Api.Attributes;
using LogMiddleware.Api.data.Implementation;
using LogMiddleware.Api.data.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRep, UsuarioRep>();

builder.Services.AddCors(x => {
    x.AddPolicy("AllowAll", cfg => {
       cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");


app.MapControllers();

app.Run();