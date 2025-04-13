using Domain;
using Domain.CQRS.CommandsHandlers;
using Domain.Repository;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace REST_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "miniProject", Version = "v1" });
            });

            services.AddDbContext<DataContext>(options =>

                options.UseInMemoryDatabase(Configuration.GetConnectionString("DefaultConnection"))

                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                //b => b.MigrationsAssembly("WebService"))
            );

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(PeopleCommandsHandlers).Assembly);
            });

            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddAutoMapper(typeof(LibraryMapper));
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();


            // Dodaj CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "miniProject v1"));
            }

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
