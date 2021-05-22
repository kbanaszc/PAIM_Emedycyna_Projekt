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

            //Miejsce, w kt�rym okre�lamy co ma si� kry� za poszczeg�lnymi interfejsami.
            //Poni�sze trzy linijki sprawi�, �e kiedy zdefiniujemy kontruktor przyjmuj�cy jako parametr jeden z poni�szych interfejs�w
            //framework automatycznie "wstzyknie" do niego wskazan� przez nas implementacj�
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
