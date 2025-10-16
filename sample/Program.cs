using CQRS.Interface;
using CQRS.Sample.Behaviour;
using FluentValidation; // Add this using directive at the top of the file
using System.Reflection;

namespace CQRS.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /// Register CQRS services
            builder.Services.AddCQRS();

            // Register FluentValidation validators from the current assembly
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped(typeof(IRequestPipeline<,>), typeof(AuthorizationBehaviour<,>));
            builder.Services.AddScoped(typeof(IRequestPipeline<,>), typeof(ValidationBehavior<,>));

            // Automatically register all IRequestHandler implementations from the current assembly
            var assembly = Assembly.GetExecutingAssembly();
            builder.Services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            builder.Services.AddControllers();
            
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer(); // Enables API Explorer for both controllers and Minimal APIs
            builder.Services.AddSwaggerGen(); // Adds Swagger generation services            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); // Maps the OpenAPI specification document
                app.UseSwagger();
                app.UseSwaggerUI(); // Enables the interactive Swagger UI
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
