using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace aula2
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
            host.Run();

        }
    }

    internal class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuaration)
        {
            _configuration = configuaration;
        }

        //Middlewares
        public void Configure(IApplicationBuilder app)
        {
            var ordem = string.Empty;
            app.Use(async(context, next) => {

                //Ordem 1
                ordem += "1";
                await next.Invoke();

                //Ordem 4
                ordem += "4";
                await context.Response.WriteAsync($"Ordem: {ordem}");
            });

            app.Use(async(context, next) => {

                //Ordem 2
                ordem += "2";
                await next.Invoke();

                //Ordem 3
                ordem += "3";
            });
        }
    }
}
