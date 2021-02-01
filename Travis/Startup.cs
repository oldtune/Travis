using Infracstructure.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sharedkernel.Configs;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using Travis.Configurations;
using Travis.Filters;
using Travis.Middlewares;

namespace Travis
{
    public class Startup
    {
        public IConfiguration Configuration { set; get; }
        public IWebHostEnvironment Environment { set; get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddHttpContextAccessor();

            services.AddGrpc();
            services.AddGrpcReflection();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "Travis api",
                    Title = "Document title",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Email = "tvddaman@gmail.com",
                        Name = "Do Tran"
                    }
                });
            });

            services.AddOptions<JwtValidationConfig>(nameof(JwtValidationConfig));

            var jwtValidationConfigs = new JwtValidationConfig();
            Configuration.GetSection(nameof(JwtValidationConfig)).Bind(jwtValidationConfigs);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtValidationConfigs.KeyBytes),
                    ValidateIssuer = jwtValidationConfigs.ValidateIssuer,
                    ValidateAudience = jwtValidationConfigs.ValidateAudience,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                };
            });

            //https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0
            services.AddCors(corsOption =>
                corsOption.AddDefaultPolicy(corsPolicy =>
                    corsPolicy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));

            string connectionString = Configuration.GetConnectionString(SettingContants.ConnectionStrings.UserDbConnectionString);
            services.AddDbContextPool<UserDbContext>(option => option.UseSqlServer(connectionString));

            //services.AddTransient<LoggingContextMiddleware>();

            services.AddAuthentication()
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });

            services.AddHttpClient();

            services.Configure<FetchOptions>(Configuration.GetSection(nameof(FetchOptions)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            //app.UseFactoryActivatedMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<GreeterService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Meow Meow' Meow Meow Meow");
                });

                if (env.IsDevelopment())
                {
                    endpoints.MapGrpcReflectionService();

                }
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocumentTitle = "User API";
                c.DocExpansion(DocExpansion.Full);
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
