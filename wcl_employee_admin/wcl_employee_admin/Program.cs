using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using wcl_employee_admin.Data;
using System.Text;
using AutoMapper;
using System.Net;
using Microsoft.OpenApi.Models;
using System.Reflection;
using wcl_employee_admin.Repositories.AccountRepository;
using wcl_employee_admin.Repositories.MissPunchRepository;
using wcl_employee_admin.Repositories.VTOformRepository;
using wcl_employee_admin.Repositories.TimeOffRepository;
using wcl_employee_admin.Repositories.IncidentReportRepository;
using wcl_employee_admin.Repositories.InjuryReportRepository;
using wcl_employee_admin.Repositories.LunchCorrectionRepository;
using wcl_employee_admin.Repositories.EmployeeComplaintRepository;
using wcl_employee_admin.Repositories.TimeSheetRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 3;

    //fix Role Authenticate

}).AddRoles<IdentityRole>().AddEntityFrameworkStores<FormContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
        (builder.Configuration["JWT:Secret"])),
        RequireExpirationTime = true
    };
});



builder.Services.AddDbContext<FormContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("wclStore"));
}
);

builder.Services.AddAutoMapper(typeof(Program));

//life cycle DI : addsingleton , addtransient, addscope
builder.Services.AddScoped<IMissPunchFormRepository, MissPunchFormRepository>();
builder.Services.AddScoped<ITimeOffFormRepository, TimeOffFormRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IVTOFormRepository, VTOFormRepository>();
builder.Services.AddScoped<IIncidentReportFormRepository, IncidentReportFormRepository>();
builder.Services.AddScoped<IInjuryReportFormRepository, InjuryReportFormRepository>();
builder.Services.AddScoped<ILunchCorrectionFormRepository, LunchCorrectionFormRepository>();
builder.Services.AddScoped<IEmployeeComplaintRepository, EmployeeComplaintRepository>();
builder.Services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WCL Solution Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
 {
 new OpenApiSecurityScheme
 {
 Name = "Bearer",
 In = ParameterLocation.Header,
 Reference = new OpenApiReference
 {
 Id = "Bearer",
 Type = ReferenceType.SecurityScheme
 }
 },
 new List<string>()
 }
 });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseStaticFiles();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
