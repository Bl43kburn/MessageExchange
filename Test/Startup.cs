using BusinessLogicLayer.Anemic.Requests;
using DataAccessLayer.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab6.Test;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(typeof(AggregateMessages));
        services.AddMediatR(typeof(EndSession));
        services.AddMediatR(typeof(GetReportsByDate));
        services.AddMediatR(typeof(MarkProcessed));
        services.AddDataAccess(x => x.UseSqlite("Data Source=test.db"));
    }
}