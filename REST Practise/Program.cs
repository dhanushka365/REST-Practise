
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using REST_Practise.Data;
using REST_Practise.Mappings;
using REST_Practise.Model.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using REST_Practise.Repositories;
using REST_Practise.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add automapper service
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//-----------------------------------------------------------------------------------------------------

builder.Services.AddMvc();

builder.Services.AddDbContext<ERPContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmpConnectionString")));

//builder.Services.AddDbContext<ERPAuthContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("EmpAuthConnectionString")));


builder.Services.AddScoped<IDepartmentRepository,SQLDepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddScoped<IProfileRepository, SQLProfileRepository>();
builder.Services.AddScoped<ISalaryRepository, SQLSalaryRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IRoleRepository, SQLRoleRepository>();

//Add Identity solution
builder.Services.AddIdentityCore<Profile>()
    .AddRoles<Role>()
    .AddTokenProvider<DataProtectorTokenProvider<Profile>>("EmpConnectionString")
    .AddEntityFrameworkStores<ERPContext>()
    .AddDefaultTokenProviders();
//-------------------------------------------------------------------------------------------------------

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

});
//-------------------------------------------------------------------------------------------------------
//Add authentication to the services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
//------------------------------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// use authentication settings
app.UseAuthentication();
//-------------------------------------------------------------------------------------------------------------
app.UseAuthorization();
//-------------------------------------------------------------------------------------------------------------
app.MapControllers();

app.Run();
