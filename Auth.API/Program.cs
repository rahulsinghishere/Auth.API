
using Auth.API.Application.IServices;
using Auth.API.Application.Services;
using Auth.API.Core.Domain;
using Auth.API.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Auth.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AuthDBContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:AuthConString"]));
            builder.Services.AddScoped<IUserAuthService, UserAuthService>();
            builder.Services.AddIdentity<ApplicationUser, ApplicationUserRole>()
                .AddEntityFrameworkStores<AuthDBContext>()
                .AddDefaultTokenProviders();

            IdentityModelEventSource.ShowPII = true;

            builder.Services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
                {

                    opts.SaveToken = true;
                    opts.RequireHttpsMetadata = false;
                    //opts.Authority = builder.Configuration["JWT:Issuer"];
                    opts.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])),

                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:Audience"],

                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"]
                    };
                    //opts.Configuration = new OpenIdConnectConfiguration();
                }
            );
            builder.Services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
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

            app.UseCors(policyopts =>
            {
                policyopts.AllowAnyOrigin();
                policyopts.AllowAnyHeader();
                policyopts.AllowAnyMethod();
            });

            app.MapControllers();

            app.Run();
        }
    }
}

