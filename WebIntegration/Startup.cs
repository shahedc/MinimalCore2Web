using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebIntegration.Services;

namespace WebIntegration
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                if (context.Request.Path.Value.Contains("checkprime"))
                {
                    int numberToCheck;
                    try
                    {
                        numberToCheck = int.Parse(context.Request.QueryString.Value.Replace("?", ""));
                        var primeService = new PrimeService();
                        if (primeService.IsPrime(numberToCheck))
                        {
                            await context.Response.WriteAsync($"{numberToCheck} is prime!");
                        }
                        else
                        {
                            await context.Response.WriteAsync($"{numberToCheck} is NOT prime!");
                        }
                    }
                    catch
                    {
                        await context.Response.WriteAsync("Pass in a number to check in the form /checkprime?5");
                    }
                }
                else
                {
                    await context.Response.WriteAsync("Hello World!");
                }
            });
        }
    }
}
