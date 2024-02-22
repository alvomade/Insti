
using Microsoft.EntityFrameworkCore;
using Insti.Context;
using Insti.Modules.Admin;
using Insti.Modules.Institution;
using Insti.Modules.AdminInstitution;
using static Insti.Middlewares.HandleError;
using Insti.Middlewares;
using Insti.Queries;
using insti.Queries;
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
           
                options.UseSqlServer(builder.Configuration.GetConnectionString("insti")),
                ServiceLifetime.Scoped
            );
        
            builder.Services.AddScoped<AdminServices>();
            builder.Services.AddScoped<InstitutionServices>();
            builder.Services.AddScoped<AdminInstitutionServices>();

            builder.Services.AddScoped<AdminQueries>();
            builder.Services.AddScoped<AdminMutations>();

            builder.Services.AddGraphQLServer()
            .AddQueryType<AdminQueries>()
            .AddMutationType<AdminMutations>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                        
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseMiddleware<HandleError>();

            app.UseRouting();

         
            app.MapControllers();
            app.MapGraphQL("/graphql");

            app.Run();
        }
    }
}
