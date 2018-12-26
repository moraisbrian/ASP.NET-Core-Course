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
        //dotnet add package Microsoft.AspNetCore.App --version 2.2.0
        //dotnet watch run
        static void Main(string[] args)
        {
            //A nova forma de criação de host permite que a classe startup receba
            //como parametro um IConfiguration que é o appsettings.json
            var host = WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
            host.Run();

            //Forma antiga de criação de host
            /*
            var host = new WebHostBuilder()
            .UseKestrel()
            // .Configure(app => {
            //     app.Run(context => context.Response.WriteAsync("Bem vindo!"));
            // })
            .UseStartup<Startup>()
            .Build();

            host.Run();
            */
        }
    }

    internal class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuaration)
        {
            _configuration = configuaration;
        }
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async(context, next) => {
                await context.Response.WriteAsync(_configuration["Application"]);
            });
        }
    }
}
