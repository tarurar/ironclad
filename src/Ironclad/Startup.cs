﻿// <copyright file="Startup.cs" company="Lykke">
// Copyright (c) Ironclad Contributors. All rights reserved.
// </copyright>

namespace Ironclad
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpOverrides;
    ////using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        ////public void ConfigureServices(IServiceCollection services)
        ////{
        ////}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $@"Hello World from {System.Runtime.InteropServices.RuntimeInformation.OSDescription}
[Version: {System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion}]")
                    .ConfigureAwait(false);
            });
        }
    }
}