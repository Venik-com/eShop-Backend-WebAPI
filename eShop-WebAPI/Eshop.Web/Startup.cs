using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Eshop.Web.Data.EFModels;
using System;
using HotChocolate.AspNetCore;
using Eshop.Web.GraphQL.Customers;
using HotChocolate;
using Eshop.Web.GraphQL.DataLoader;
using Eshop.Web.GraphQL.Invoices;
using Eshop.Web.GraphQL.OrderItems;
using Eshop.Web.GraphQL.Models.OrderItems;
using Eshop.Web.GraphQL.CustomerPaymentMethod;
using Eshop.Web.GraphQL.Orders;
using Eshop.Web.GraphQL.Models.CustomerPaymentMethods;
using HotChocolate.AspNetCore.Playground;
using Eshop.Web.GraphQL.Payments;
using Eshop.Web.GraphQL.Products;
using Eshop.Web.GraphQL.Shipments;

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
                    .AddTypeExtension<InvoiceQueries>()
                    .AddTypeExtension<OrderItemQueries>()
                    .AddTypeExtension<CustomerPaymentMethodQueries>()
                    .AddTypeExtension<OrderQueries>()
                    .AddTypeExtension<PaymentQueries>()
                    .AddTypeExtension<ProductQueries>()
                    .AddTypeExtension<ShipmentQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<CustomerMutations>()
                    .AddTypeExtension<InvoiceMutations>()
                    .AddTypeExtension<OrderItemMutations>()
                    .AddTypeExtension<CustomerPaymentMethodMutations>()
                    .AddTypeExtension<OrderMutations>()
                    .AddTypeExtension<PaymentMutations>()
                    .AddTypeExtension<ProductMutations>()
                    .AddTypeExtension<ShipmentMutations>()
                .AddType<CustomerType>()
                .AddType<InvoiceType>()
                .AddType<OrderItemType>()
                .AddType<CustomerPaymentMethodType>()
                .AddType<OrderType>()
                .AddType<PaymentType>()
                .AddType<ProductType>()
                .AddType<ShipmentType>()
                .EnableRelaySupport()
                .AddFiltering()
                .AddSorting()
                .AddDataLoader<CustomerByIdDataLoader>()
                .AddDataLoader<InvoiceByIdDataLoader>()
                .AddDataLoader<OrderByIdDataLoader>()
                .AddDataLoader<OrderItemByIdDataLoader>()
                .AddDataLoader<CustomerPaymentMethodByIdDataLoader>()
                .AddDataLoader<PaymentByIdDataLoader>()
                .AddDataLoader<ProductByIdDataLoader>()
                .AddDataLoader<ShipmentByIdDataLoader>()
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

                // Для визуализации схемы вашего API GraphQL.
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
