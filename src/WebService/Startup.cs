using Library.Domain;
using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Builders;
using Library.Domain.CommandsHandlers;
using Library.Domain.Repository;
using Library.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using static Library.Domain.Aggregates.PersonFactory;

namespace WebService
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

            services.AddScoped<ILibrary, Library.Domain.Services.Library>();
            services.AddScoped<IPeople, People>();
            services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("LibraryDB")
            );

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(PeopleCommandsHandlers).Assembly);
            });

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

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

            AddFirstBooks(app.ApplicationServices);
            AddFirstPersons(app.ApplicationServices);            
        }

        private void AddFirstBooks(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();

                context.AddAsync(BookBuilder.Given()
                    .SetTitle("Harry Potter i kamieñ Filozoficzny")
                    .SetAuthor("J.K. Rowling")
                    .SetReleaseDate(DateTime.Parse("26.06.1997"))
                    .SetDescription("Opowieœæ o m³odym czarodzieju")
                    .Build()
                );
                context.SaveChanges();
                context.Books.Add(BookBuilder.Given()
                    .SetTitle("Lalka")
                    .SetAuthor("Boles³aw Prus")
                    .SetReleaseDate(DateTime.Parse("9.02.1887 "))
                    .SetDescription("Powieœæ spo³eczno-obyczajowa której g³ównym bohaterem jest Stanis³aw Wokulski")
                    .Build()
                );
                context.SaveChanges();
                context.Books.Add(BookBuilder.Given()
                    .SetTitle("Harry Potter i komnata tajemnic")
                    .SetAuthor("J.K. Rowling")
                    .SetReleaseDate(DateTime.Parse("26.06.1998"))
                    .SetDescription("Kolejna czêœæ opowieœci o m³odym czarodzieju")
                    .SetPreviousBookPart(context.Books.Where(b => b.Title == "Harry Potter i kamieñ Filozoficzny").FirstOrDefault())
                    .Build()
                );
                context.SaveChanges();
            }
        }

        private void AddFirstPersons(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();

                PersonCreatorDelegate guestCreator = User.CreateUser;
                var guestFactory = new PersonFactory(guestCreator);
                PersonCreatorDelegate workerCreator = Worker.CreateWorker;
                var workerFactory = new PersonFactory(workerCreator);

                context.Persons.Add(workerFactory.CreatePerson("Zuzanna", "Kowalska", "W1234", "zkowalska"));
                context.Persons.Add(guestFactory.CreatePerson("Janusz", "Kowalski", "G1234", null));
                context.Persons.Add(guestFactory.CreatePerson("Antoni", "Nowak", "G4321", null));
                context.SaveChanges();
            }
        }
    }
}
