
using GameStatisticsVolleball.Models;
using GameStatisticsVolleball.Repositories;
using Microsoft.EntityFrameworkCore;
using GameStatisticsVolleball.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using GameStatisticsVolleball.Models.DTO;
using System.Text;

namespace GameStatisticsVolleball
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<JwtConfiguration>(
               builder.Configuration.GetSection("Jwt"));

            var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            // Add services to the container.


            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddControllers();

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<APIDBContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
           
            builder.Services.AddScoped<IPlayerMatchStatsRepository, PlayerMatchStatsRepository>();
            builder.Services.AddScoped<IMatchRepository, MatchRepository>();
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
            builder.Services.AddScoped<IPositionRepository, PositionRepository>();


           

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
