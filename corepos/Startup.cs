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
using corepos.Models;

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
            services.AddMvc()
                .AddJsonOptions(options =>
                    options
                    .SerializerSettings
                    .ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddDbContext<PersonContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var connectionString = Configuration["connectionStrings:DefaultConnection"];
            services.AddDbContext<myPoSContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPOSRepository, POSRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            Mapper.Initialize(res =>
            {
                res.CreateMap<PosUser, PosUserViewDto>();
                res.CreateMap<PosUserCreateDto, PosUser>();
                res.CreateMap<PosUserUpdateDto, PosUser>();
                res.CreateMap<PersonViewDto, Person>();
                res.CreateMap<PersonUpdateDto, Person>();
                res.CreateMap<CustomerViewDto, Customer>();
            });

            app.UseCors("AllowAll");
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC didn't find anything!!");
            });
        }
    }
}
