
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<FarmDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable
            ("SQL_CONNECTION_STRING")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
