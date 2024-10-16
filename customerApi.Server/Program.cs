
using CarApi.Business.Customer;
using CarApi.Business.Validators;
using CarApi.DAO.InMemory.Customer;
using CarApi.Domain.Models.Validators;
using CarApi.Domain.Services.Customer;
using CarApi.Server.Controllers;

namespace customerApi.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Setup DAO services
            builder.Services.AddSingleton<ICustomerDAO, CustomerDAO>();

            // Setup Validation services
            builder.Services.AddSingleton<ICustomerValidator, CustomerValidator>();
            builder.Services.AddSingleton<IPhoneValidator, RegexPhoneValidator>();
            builder.Services.AddSingleton<IEmailValidator, RegexEmailValidator>();

            // Setup domain services
            builder.Services.AddSingleton<ICustomerService, CustomerService>();

            builder.Services.AddControllers();

            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();
            
            app.MapControllers();

            app.UseCors(options => {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
