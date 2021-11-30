using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Eshop.Web.Data.EFModels;
using System;
using Eshop.Web.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Eshop.Domain.Implementations.Services;
using Eshop.Domain.Contracts.IServices;
using Eshop.Web.GraphQL.Customers;
using System.Diagnostics;
using HotChocolate;
using Eshop.Web.GraphQL.DataLoader;
using Microsoft.AspNetCore.Http;

namespace Eshop.Web
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
            services.AddPooledDbContextFactory<EshopdbContext>(options =>
            {
                options
                .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            });


            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<CustomerQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    // Добавлять новые мутации для разных классов сюда,
                    // чтобы они они потом в коде объединились в 1 мутацию.
                    .AddTypeExtension<CustomerMutations>()
                .AddType<CustomerType>()
                .EnableRelaySupport()
                .AddFiltering()
                .AddSorting()
                .AddDataLoader<CustomerByIdDataLoader>()
                .AddDataLoader<OrderByIdDataLoader>()
                //.AddDataLoader<InvoiceByInvoiceNumberDataLoader>()
                //.AddDataLoader<PaymentByIdDataLoader>()
                //.AddDataLoader<ProductByIdDataLoader>()
                //.AddDataLoader<ShipmentByIdDataLoader>()
                //.AddDataLoader<RefProductTypeByProductTypeCodeDataLoader>()
                .AddInMemorySubscriptions();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            //services.AddAutoMapper(typeof(Startup));

            // TO DO: Добавить мои сервисы сюда.
            //services.AddScoped<CustomerService>();
            //services.AddScoped<IInvoiceService, InvoiceService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IShipmentService, ShipmentService>();s
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Не работает, прочитай
                // https://github.com/apollographql/apollo-tracing
                //app.UsePlayground(new PlaygroundOptions
                //{
                //    QueryPath = "/api",
                //    Path = "/Playground"
                //});

                //app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
                //{
                //    GraphQLEndPoint = "/graphql",
                //    Path = "/graphql-voyager"
                //});
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            // Погуглить зачем это.
            //app.UseWelcomePage();


            app.UseWebSockets();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");

            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapGraphQL()
                    .WithOptions(new GraphQLServerOptions
                     {
                         AllowedGetOperations = AllowedGetOperations.QueryAndMutation
                     });
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
