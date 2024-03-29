﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ancestry.Common.Models;
using Ancestry.Common.Repo;
using Ancestry.Common.Services;
using Ancestry.Common.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ancestry.Api
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
            services.AddOptions();
            services.Configure<DataFileSettings>(Configuration.GetSection("InputFileSettings"));

            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IJsonService, JsonService>();
            services.AddSingleton<IPeopleStore, PeopleStore>();
            services.AddSingleton<IPlaceStore, PlaceStore>();
            services.AddTransient<IPeopleRepo, PeopleRepo>();
            services.AddTransient<IPlaceRepo, PlaceRepo>();
            services.AddTransient<IPeopleService, PeopleService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
