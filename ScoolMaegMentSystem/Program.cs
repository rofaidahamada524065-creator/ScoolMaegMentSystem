
using Microsoft.EntityFrameworkCore;
using ScoolMaegMentSystem.Data;
using ScoolMaegMentSystem.Mapping;
using ScoolMaegMentSystem.Model;
using ScoolMaegMentSystem.Repos.impelementation;
using ScoolMaegMentSystem.Repos.Interface;
using ScoolMaegMentSystem.UnitOfWorkk;

namespace ScoolMaegMentSystem
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
            builder.Services.AddDbContext<AppDbcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddAutoMapper(typeof(AllProfail));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IStudentCustom, StudentCustom>();
            builder.Services.AddScoped<ICourceCustom, CourceCustom>();
            builder.Services.AddScoped<IEnrollmentCustom, EnrollmentCustom>();
            builder.Services.AddScoped<IGenaricRepo<Teacher>, GenaricRepo<Teacher>>();
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
