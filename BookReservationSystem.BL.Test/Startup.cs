using BookReservationSystem.BL.Configs;
using Microsoft.Extensions.DependencyInjection;

namespace BookReservationSystem.BL.Test;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        DependencyInjectionConfig.ConfigureServices(services);
    }
}