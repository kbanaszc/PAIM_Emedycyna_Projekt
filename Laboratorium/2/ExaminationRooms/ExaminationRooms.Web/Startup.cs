namespace ExaminationRooms.Web
{
    using ExaminationRooms.Domain;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Infrastructure;
    using ExaminationRooms.Web.Application;
    using ExaminationRooms.Web.Application.Commands;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
           
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExaminationRooms.Web", Version = "v1" });
            });

            //Miejsce, w którym okreœlamy co ma siê kryæ za poszczególnymi interfejsami.
            //Poni¿sze trzy linijki sprawi¹, ¿e kiedy zdefiniujemy kontruktor przyjmuj¹cy jako parametr jeden z poni¿szych interfejsów
            //framework automatycznie "wstzyknie" do niego wskazan¹ przez nas implementacjê
            services.AddSingleton<IExaminationRoomsRepository, ExaminationRoomsRepository>();
            services.AddTransient<IExaminationRoomQueriesHandler, ExaminationRoomQueriesHandler>();
            services.AddTransient<ICommandHandler<AddExaminationRoomCommand>, ExaminationRoomsCommandsHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laboratories.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
