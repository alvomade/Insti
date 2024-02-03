
using Microsoft.EntityFrameworkCore;
using Insti.Context;
using Insti.Modules.Admin;
using Insti.Modules.Institution;
using Insti.Modules.AdminInstitution;
namespace Insti
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
            builder.Services.AddDbContext<InstiDb>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("insti"));
            });
            builder.Services.AddScoped<AdminServices>();
            builder.Services.AddScoped<InstitutionServices>();
            builder.Services.AddScoped<AdminInstitutionServices>();


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
