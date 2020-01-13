using CQRSExample.Infrastructure;
using CQRSExample.ReadModels;
using CQRSExample.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRSExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // this datastore is just a simple in-memory database for this example/
            // in real life it could be SQL server or anything
            var dataStore = new DataStore();
            await dataStore.Insert(new ValueObject() { Id = 1, Value = "A" });
            await dataStore.Insert(new ValueObject() { Id = 2, Value = "B" });
            await dataStore.Insert(new ValueObject() { Id = 3, Value = "C" });
            services.AddSingleton<IDataStore>(dataStore);
            services.AddTransient<IWriteRepository, WriteRepository>();
            services.AddTransient<IReadRepository, ReadRepository>();
            services.AddTransient<ValuesModel, ValuesModel>();
            services.AddTransient<ValuesModel, ValuesModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}