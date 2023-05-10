using System.Reflection;
using BusinessLogicLayer.Anemic.Requests;
using MediatR;

namespace Presentation;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddMediatR(typeof(Startup));
        serviceCollection.AddMediatR(typeof(AggregateMessages));
        serviceCollection.AddMediatR(typeof(EndSession));
        serviceCollection.AddMediatR(typeof(GetReportsByDate));
        serviceCollection.AddMediatR(typeof(MarkProcessed));
    }
}