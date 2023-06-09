using MAF_Event_Center.Application;
using MAF_Event_Center.Application.Handlers;
using MAF_Event_Center.Application.Queries;
using MAF_Event_Center.Application.Services;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Infastructure.Data;
using MAF_Event_Center.Infastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MAF_Event_Center.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(typeof(Extensions));
            builder.Services.AddScoped<IRepository<Event>, EventRepository>();
            builder.Services.AddScoped<IRepository<Game>, GameRepository>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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