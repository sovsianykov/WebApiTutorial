using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using apiTutorial.Controllers;
using apiTutorial.Interfaces;
using apiTutorial.Services;

namespace apiTutorial;

public class Program
{
    public static void Main(string[] args)
    {

       CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.ConfigureServices(services =>
               {
                   services.AddSingleton<IPostService, PostService>();
                   services.AddControllers();
                   services.AddSwaggerGen(c =>
                   {
                       c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFirstApi", Version = "v1" });
                   });
               }).Configure(app =>
               {
                   app.UseRouting();
                   app.UseSwagger();
                   app.UseSwaggerUI(c =>
                   {
                       c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstApi served simple Post model");
                   });
                   app.UseEndpoints(endpoints =>
                   {
                       endpoints.MapControllers();
                   });
               });
           });
}

