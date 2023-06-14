using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Blog.Web.Controllers;
using Blog.Application.Services;
using AutoMapper;

namespace Blog.Web;

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
               webBuilder.ConfigureServices((IServiceCollection services) =>
               {
                   services.AddSingleton<IPostService, PostService>();
                   services.AddControllers();
                   var mappingConfig = new MapperConfiguration(mc =>
                   {
                       mc.AddProfile(new MappingProfile());
                   });

                   IMapper mapper = mappingConfig.CreateMapper();
                   services.AddSingleton(mapper);
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

