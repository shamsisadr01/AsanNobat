using System.Runtime.CompilerServices;
using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.TodoLists.Queries.GetTodos;
using AsanNobat.Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AsanNobat.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private ILoggerFactory? _loggerFactory;
    private TypeAdapterConfig? _configuration;
    private IMapper? _mapper;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Minimal logger factory for tests
        _loggerFactory = LoggerFactory.Create(b => b.AddDebug().SetMinimumLevel(LogLevel.Debug));

        _configuration = new TypeAdapterConfig();

        _configuration.Scan(
            typeof(IApplicationDbContext).Assembly);

        var services = new ServiceCollection();

        services.AddSingleton(_configuration);
        services.AddScoped<IMapper, ServiceMapper>();

        var serviceProvider = services.BuildServiceProvider();

        _mapper = serviceProvider.GetRequiredService<IMapper>();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration!.Compile();
    }

    [Test]
    [TestCase(typeof(TodoList), typeof(TodoListDto))]
    [TestCase(typeof(TodoItem), typeof(TodoItemDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper!.Map(instance, source, destination);
    }

    private static object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return RuntimeHelpers.GetUninitializedObject(type);
    }


    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _loggerFactory?.Dispose();
    }
}
