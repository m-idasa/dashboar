using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using IOC;
//using UI.HubConfig;
using infrastructure.HubConfig;
using QuartzIntegrations.Core.Configurations;
using QuartzInfrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR();

// Add services
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddProblemDetails();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");

builder.Services.AddDbContext<AppDBContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
    },
    ServiceLifetime.Scoped
);

//builder.Services.AddSingleton<TimerManager>();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
        });
});

RegisterServices.ConfigureServices(builder.Services);

builder.Services.AddControllersWithViews().AddXmlDataContractSerializerFormatters();

builder.Services.Configure<JobSettings>(builder.Configuration.GetSection("JobSetting"));

JobRegistrationExtensions.RegisterBackgroundServices(builder.Services, builder.Configuration.GetSection("JobSetting").Get<JobSettings>() ?? new JobSettings());

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("Policy");

app.MapHub<ServiceHub>("/chathub");
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ServiceHub>("/servicehub");
});
*/
app.Run();
