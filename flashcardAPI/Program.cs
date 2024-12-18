
using flashcardAPI.Data;
using flashcardAPI.Interfaces;
using flashcardAPI.Repository;
using flashcardAPI.Services;
using flashcardsAPI.Interfaces;
using flashcardsAPI.Repository;
using flashcardsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace flashcardAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()    
                               .AllowAnyHeader();   
                    });
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddScoped<InterfaceRepositoryCard, RepositoryCard>();
            builder.Services.AddScoped<InterfaceServiceCard, ServiceCard>();

            builder.Services.AddScoped<InterfaceRepositoryFlash, RepositoryFlash>();
            builder.Services.AddScoped<InterfaceServiceFlash, ServiceFlash>();

            builder.Services.AddScoped<InterfaceRepositoryUser, RepositoryUser>();
            builder.Services.AddScoped<InterfaceServiceUser,  ServiceUser>();

            builder.Services.AddScoped<InterfaceRepositoryFlashCard, RepositoryFlashCard>();
            builder.Services.AddScoped<InterfaceServiceFlashCard, ServiceFlashCard>();

            builder.Services.AddScoped<InterfaceRepositoryTeste, RepositoryTeste>();
            builder.Services.AddScoped<InterfaceServiceTeste, ServiceTeste>();

            builder.Services.AddScoped<InterfaceRepositoryQuiz, RepositoryQuiz>();
            builder.Services.AddScoped<InterfaceServiceQuiz, ServiceQuiz>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowAll");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
