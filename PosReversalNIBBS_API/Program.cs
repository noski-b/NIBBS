using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PosReversalNIBBS_API.Data;
using PosReversalNIBBS_API.Repositories.IRepository;
using PosReversalNIBBS_API.Repositories.Repository;

namespace PosReversalNIBBS_API
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

            //services cors
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>());

            builder.Services.AddDbContext<PosNibbsDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PosNibbsConnection"));
            });

            builder.Services.AddScoped<IExcelResponseRepository, ExcelResponseRepository>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseSwagger();
            app.UseSwaggerUI();

            //Cors config
          //  app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseCors("corsapp");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}