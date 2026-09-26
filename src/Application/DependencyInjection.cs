using System.Reflection;
using AsanNobat.Application.Common.Behaviours;
using AsanNobat.Application.TodoLists.Commands.CreateTodoList;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsanNobat.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        builder.Services.AddScoped<IMapper, ServiceMapper>();

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddMediator(options =>
        {
            options.Assemblies = [typeof(DependencyInjection)];

            options.PipelineBehaviors =
            [
                typeof(LoggingBehaviour<,>),
                typeof(UnhandledExceptionBehaviour<,>),
                typeof(AuthorizationBehaviour<,>),
                typeof(ValidationBehaviour<,>),
                typeof(PerformanceBehaviour<,>)
            ];

            options.ServiceLifetime = ServiceLifetime.Scoped;
        });
    }
}
