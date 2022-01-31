using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Entities.Constants;
using ProiectASP.Repositories.AngajatiRepository;
using ProiectASP.Repositories.CategorieRepository;
using ProiectASP.Repositories.ClientiRepository;
using ProiectASP.Repositories.ComenziRepository;
using ProiectASP.Repositories.DetaliiComandaRepository;
using ProiectASP.Repositories.FilamenteRepository;
using ProiectASP.Repositories.ImprimanteFilamenteRepository;
using ProiectASP.Repositories.ImprimanteRepository;
using ProiectASP.Repositories.ProduseRepository;
using ProiectASP.Repositories.SessionTokenRepository;
using ProiectASP.Repositories.UserRepository;
using ProiectASP.Seed;
using ProiectASP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:44308",
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProiectASP", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
            });

            services.AddDbContext<Context>(options =>
                options.UseSqlServer("Data Source=DESKTOP-H551OQK\\SQLEXPRESS;Initial Catalog=BDProiectASP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));


            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<SeedDb>();

            services.AddTransient<IProduseRepository, ProduseRepository>();
            services.AddTransient<ICategorieRepository, CategorieRepository>();
            services.AddTransient<IFilamentRepository, FilamentRepository>();
            services.AddTransient<IImprimantaRepository, ImprimantaRepository>();
            services.AddTransient<IImprimanteFilamentRepository, ImprimanteFilamentRepository>();
            services.AddTransient<IComenziRepository, ComenziRepository>();
            services.AddTransient<IAngajatiRepository, AngajatiRepository>();
            services.AddTransient<IDetaliiComandaRepository, DetaliiComandaRepository>();
            services.AddTransient<IClientiRepository, ClientiRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISessionTokenRepository, SessionTokenRepository>();


            services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoleType.Admin, policy => policy.RequireRole(UserRoleType.Admin));
                options.AddPolicy(UserRoleType.Client, policy => policy.RequireRole(UserRoleType.Client));
                options.AddPolicy(UserRoleType.Executant, policy => policy.RequireRole(UserRoleType.Executant));
                options.AddPolicy(UserRoleType.Proiectant, policy => policy.RequireRole(UserRoleType.Proiectant));

            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidIssuer = "test",
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismysecretkey")),
                    ValidateIssuerSigningKey = true,
                    // RoleClaimType = "Role"

                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = Helpers.SessionTokenValidator.ValidateSessionToken
                };
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, SeedDb seed, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProiectASP v1"));
            }

            app.UseCors(MyAllowSpecificOrigins);

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (Context, next) =>
            {
                var test = Context;
                await next();
            });

            try
            {
                seed.SeedRoles().Wait();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
    }
}