using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace aula2
{
    class Program
    {
        //dotnet add package Microsoft.AspNetCore.App --version 2.2.0
        //dotnet watch run
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel()
            // .Configure(app => {
            //     app.Run(context => context.Response.WriteAsync("Bem vindo!"));
            // })
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }

    internal class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async(context, next) => {
                await context.Response.WriteAsync("Trabalhando com classe StartUp");
            });
        }
    }
}
