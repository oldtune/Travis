using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Travis.Configurations;

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
            services.AddHttpContextAccessor();

            services.AddOptions<CodeConfig>(nameof(CodeConfig));

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

            //https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0
            services.AddCors(corsOption =>
                corsOption.AddDefaultPolicy(corsPolicy =>
                    corsPolicy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));
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
