using API.CommandQuery.Command.Customer;
using API.CommandQuery.Command.Order;
using API.CommandQuery.Command.Product;
using API.CommandQuery.Query.Customer;
using API.CommandQuery.Query.Order;
using API.CommandQuery.Query.Product;
using Microsoft.EntityFrameworkCore;
using Order.Data.Data;
using Order.Data.Interfaces;
using Order.Data.Repository;
using Order.Services.Interface;
using Order.Services.MapperProfile;
using Order.Services.Services;

namespace API.CQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<IProductCommand, ProductCommand>();
            builder.Services.AddScoped<IProductQuery, ProductQuery>();
            builder.Services.AddScoped<ICustomerCommand, CustomerCommand>();
            builder.Services.AddScoped<ICustomerQuery, CustomerQuery>();
            builder.Services.AddScoped<IOrderCommand, OrderCommand>();
            builder.Services.AddScoped<IOrderQuery, OrderQuery>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddControllers();
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