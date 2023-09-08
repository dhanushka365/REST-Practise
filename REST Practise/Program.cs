using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using REST_Practise.Data;
using REST_Practise.Mappings;
using REST_Practise.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add automapper service
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddMvc();

builder.Services.AddDbContext<ERPContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmpConnectionString")));

builder.Services.AddDbContext<ERPAuthContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmpAuthConnectionString")));


builder.Services.AddScoped<IDepartmentRepository,SQLDepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddScoped<IProfileRepository, SQLProfileRepository>();
builder.Services.AddScoped<ISalaryRepository, SQLSalaryRepository>();


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
