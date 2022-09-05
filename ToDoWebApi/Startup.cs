using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoWebApi.Middleware;
using FluentValidation.AspNetCore;
using ToDoWebApi.FluentValidation;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Swashbuckle.AspNetCore;

namespace ToDoWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/api/Account");
                });
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IToDoService), typeof(ToDoService));
            services.AddAutoMapper(typeof(AppMapping));
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ToDoContext>(options => options.UseSqlite(connection));
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterModelValidator>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginModelValidation>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ToDoValidator>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }
            app.UseMiddleware<ErrorExceptionMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
