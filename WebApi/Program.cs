using Application;
using Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
// builder.Services.AddMvc()
//     .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddValidatorsFromAssemblyContaining<PersonRegisterRequestValidator>();

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
