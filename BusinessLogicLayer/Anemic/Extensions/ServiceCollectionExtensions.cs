using BusinessLogicLayer.Anemic.Services;
using BusinessLogicLayer.Anemic.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Anemic.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ICreationService, CreationService>();
        collection.AddScoped<IAssignmentService, AssignmentService>();

        return collection;
    }
}