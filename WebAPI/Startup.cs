using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.DbContexts;
using WebAPI.Services;
using System;

namespace WebAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                  builder =>
                  {
                      builder.WithOrigins("http://localhost:8080");
                  });
            });

            // add db connection
            if (Configuration.GetValue<string>("DbConnectionString") != null) {
                services.AddDbContext<NpgDbContext>(options =>
                    options.UseNpgsql(Configuration.GetValue<string>("DbConnectionString")));
            } else {
                services.AddDbContext<NpgDbContext>(options =>
                    options.UseNpgsql(Environment.GetEnvironmentVariable("CONN_STRING")));
            }

            // add controllers
            services.AddControllers();

            // add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cen4721", Version = "v1" });
            });

            // configure DI for application services
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IDegreeService, DegreeService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<ITimeslotService, TimeslotService>();
            services.AddScoped<IDegreeCourseService, DegreeCourseService>();
            services.AddScoped<IStudentCompletedCourseService, StudentCompletedCourseService>();
            services.AddScoped<ICourseInstanceService, CourseInstanceService>();
            services.AddScoped<IStudentScheduleService, StudentScheduleService>();
            services.AddScoped<IRequirementTypeService, RequirementTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cen4721 v1"));
            } else {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cen4721 v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // use cors
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
