using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using corepos.Services;
using corepos.Entities;
using AutoMapper;

namespace corepos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddDbContext<PersonContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var connectionString = Configuration["connectionStrings:DefaultConnection"];
            services.AddDbContext<myPoSContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IPOSRepository, POSRepository>();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //Mapper.Initialize(res =>
            //{
            //    res.CreateMap<Entities.PosUser, Models.PosUserViewDto>()
            //        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
            //        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
            //        .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Person.Mobile))
            //        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Person.Address));
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC didn't find anything!!");
            });
        }
    }
}
