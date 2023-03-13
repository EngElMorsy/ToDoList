using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Reflection;
using System.Text;
using ToDo.BL.Helper;
using ToDo.BL.Interface;
using ToDo.BL.Interface.Users;
using ToDo.BL.Mapper;
using ToDo.BL.Repoistory;
using ToDo.BL.Services;
using ToDo.DAL.Database;
using ToDo.DAL.Extend; 


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation(C=> C.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Enhance Connection string 
var connectionstring = builder.Configuration.GetConnectionString("ApplicationConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer());
//AUTO MAPPER 
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
//Instance  
builder.Services.AddValidatorsFromAssemblyContaining<Validator>();

builder.Services.AddScoped<IToDoRep, ToDoRep>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUser, UserRep>();



builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
 builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>();

//password Configration identity microsoft 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
