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
using corepos.Models.Product;
using corepos.Models.Sales;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;

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

            services.AddSwaggerGen(opt =>
            {
                opt.DescribeAllEnumsAsStrings();
                opt.SwaggerDoc("v1", new Info
                {
                    Title = "POS System",
                    Version = "2.0",
                    Contact = new Contact
                    {
                        Name = "ehsan munna"
                    },
                    Description = "My POS System"
                });
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

                res.CreateMap<ProductGroupCreateDto, PosUser>();
                res.CreateMap<PosUserUpdateDto, PosUser>();

                res.CreateMap<PersonViewDto, Person>();
                res.CreateMap<PersonUpdateDto, Person>();

                res.CreateMap<CustomerViewDto, Customer>();

                res.CreateMap<MeasurementUnit, MesurementUnitViewDto>();
                res.CreateMap<MesurementUnitCreateDto, MeasurementUnit>();

                res.CreateMap<Supplier, SupplierViewDto>();
                res.CreateMap<SupplierCreateDto, Supplier>();

                res.CreateMap<Product, ProductViewDto>();
                res.CreateMap<ProductCreateDto, Product>();

                res.CreateMap<SalesMain, SalesViewDto>();
                res.CreateMap<SalseCreateDto, SalesMain>();
            });


            app.UseCors("AllowAll");
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "api V1");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC didn't find anything!!");
            });
        }
    }
}
