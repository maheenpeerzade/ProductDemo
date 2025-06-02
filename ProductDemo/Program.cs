
using Microsoft.EntityFrameworkCore;
using ProductDemo.Application.Mapping;
using ProductDemo.Infrastructure;
using ProductDemo.Infrastructure.Repository;

namespace ProductDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbConn")));

            builder.Services.AddControllers();
            builder.Services.AddScoped<ProductsRepository>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
