
using Catalogue.API.Data.Interfaces;
using Catalogue.API.Data;
using Catalogue.API.Repositories.Interfaces;
using Catalogue.API.Repositories;
using Microsoft.OpenApi.Models;

namespace Catalogue.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<ICatalogueContext, CatalogueContext>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalogue.API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalogue.API v1"));
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}