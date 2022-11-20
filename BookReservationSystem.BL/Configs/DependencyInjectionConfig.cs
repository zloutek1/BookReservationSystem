using AutoMapper;
using BookReservationSystem.BL.Services;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.EFCore.UnitOfWork;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BookReservationSystem.BL.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping)));
        
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<BookService>();
        services.AddScoped<LibraryService>();
        services.AddScoped<IUnitOfWork, GenericUnitOfWork>();

        services.AddSingleton(provider => new Func<IUnitOfWork>(() => provider.GetService<IUnitOfWork>()!));
    }
}